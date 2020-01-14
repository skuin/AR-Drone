using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using UnityEngine.UI;

#if UNITY_EDITOR
// Set up touch input propagation while using Instant Preview in the editor.
using Input = GoogleARCore.InstantPreviewInput;
#endif

public class TouchMgr : MonoBehaviour
{
    public static TouchMgr touchMgr;

    private Camera ARCamera; // ARCore 카메라
    public GameObject placeObject; // 터치 시 평면에 생성할 프리팹

    public bool createObj = false;
    public bool UICreate = false;

    public Canvas UIcanvas;
    public GameObject PlaneGenerator;
    public GameObject TrackManager;
    public GameObject DronePrefab;


    // Start is called before the first frame update
    void Start()
    {
        touchMgr = this;
        // ARCore Device 프리팹 하위에 있는 카메라를 찾고 변수에 할당
        ARCamera = GameObject.Find("First Person Camera").GetComponent<Camera>();
        UIcanvas = GameObject.FindGameObjectWithTag("UI").GetComponent<Canvas>();
        //UIcanvas.enabled = false;
        PlaneGenerator = GameObject.Find("Plane Generator");
        TrackManager = GameObject.Find("TrackManager");
        DronePrefab = GameObject.Find("DronePrefab");
    }

    // Update is called once per frame
    public void Update()
    {
        Debug.Log("\n createObj is " + createObj);
        //Debug.Log("\n UIcanvas is " + UIcanvas);
        Debug.Log("\n UIcanvas enabled is " + UIcanvas.enabled);
        Debug.Log("\n PlaneGenerator active is " + PlaneGenerator.activeSelf);
        Debug.Log("\n TrackManager active is " + TrackManager.activeSelf);
        Debug.Log("\n DronePrefab active is " + DronePrefab.activeSelf);

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



        if (createObj == false && UICreate == false)
        {
            // 터치한 지점으로 레이 발사
            if (touch.phase == TouchPhase.Began
                && Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
            {
                TrackManager.SetActive(true);
                DronePrefab.SetActive(true);

                //// 객체를 고정할 앵커 생성
                //var anchor = hit.Trackable.CreateAnchor(hit.Pose);
                //// 객체를 생성
                //GameObject obj = Instantiate(placeObject, hit.Pose.position,
                //    Quaternion.identity, anchor.transform);

                //// 생성한 객체가 사용자 쪽을 바라보도록 회전값 계산
                //var rot = Quaternion.LookRotation(ARCamera.transform.position
                //    - hit.Pose.position);
                //// 사용자 쪽 회전값 적용
                //obj.transform.rotation = Quaternion.Euler(ARCamera.transform.position.x,
                //    rot.eulerAngles.y, ARCamera.transform.position.z);

                createObj = true;
                touch.phase = TouchPhase.Ended;
            }
        }
        else if (createObj == true && UICreate == false)
        {
            // UI도 클릭 후에 활성화
            UIcanvas.enabled = true;
            Debug.Log("\n\n UI Activity : " + GameObject.Find("UI").activeInHierarchy);
            Debug.Log("\n\n");

            // 조이스틱에 플레이어 연결
            //LeftJoystick.leftJoy.player = PlayerMgr.playermgr.SettingPlayerTrandform();
            //RightJoystick.rightJoy.player = PlayerMgr.playermgr.SettingPlayerTrandform();

            PlaneGenerator.SetActive(false);
            Debug.Log("\n\n Plane Generator Activity : " + PlaneGenerator.activeInHierarchy);
            Debug.Log("\n\n");

            UICreate = true;
        }
        else if (createObj == true && UICreate == true)
        {

        }
    }

}
