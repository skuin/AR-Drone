using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

#if UNITY_EDITOR
// Set up touch input propagation while using Instant Preview in the editor.
    using Input = GoogleARCore.InstantPreviewInput;
#endif

public class TouchMgr : MonoBehaviour
{
    private Camera ARCamera; // ARCore 카메라
    public GameObject placeObject; // 터치 시 평면에 생성할 프리팹

    // Start is called before the first frame update
    void Start()
    {
        // ARCore Device 프리팹 하위에 있는 카메라를 찾고 변수에 할당
        ARCamera = GameObject.Find("First Person Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    public void Update()
    {
        // 터치 없을 땐 무시
        //if (Input.touchCount == 0) return;

        // 첫번째 터치 정보 추출
        //Touch touch = Input.GetTouch(0);


        Touch touch;
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }


        // ARCore에서 제공하는 RaycastHit
        TrackableHit hit;

        // 검출 대상을 평면 또는 Feature Point로 한정
        TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon |
            TrackableHitFlags.FeaturePointWithSurfaceNormal;

        // 터치한 지점으로 레이 발사
        if(touch.phase == TouchPhase.Began
            && Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
        {
            // 객체를 고정할 앵커 생성
            var anchor = hit.Trackable.CreateAnchor(hit.Pose);
            // 객체를 생성
            GameObject obj = Instantiate(placeObject, hit.Pose.position,
                Quaternion.identity, anchor.transform);

            // 생성한 객체가 사용자 쪽을 바라보도록 회전값 계산
            var rot = Quaternion.LookRotation(ARCamera.transform.position
                - hit.Pose.position);
            // 사용자 쪽 회전값 적용
            obj.transform.rotation = Quaternion.Euler(ARCamera.transform.position.x,
                rot.eulerAngles.y, ARCamera.transform.position.z);
        }
    }
}
