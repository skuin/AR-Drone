using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HorizonJoystick : MonoBehaviour
{
    public Transform player;
    public Transform stick;

    private Vector3 stickFirstPos;  // 조이스틱 첫 위치
    private Vector3 JoyVec;         // 조이스틱의 벡터(방향)
    private float radius;           // 조이스틱 배경의 반지름
    private bool moving;

    // Start is called before the first frame update
    void Start()
    {
        radius = GetComponent<RectTransform>().sizeDelta.y * 0.5f;
        stickFirstPos = stick.transform.position;

        // 캔버스 크기에 대한 반지름 조절
        float canvas = transform.parent.GetComponent<RectTransform>().localScale.x;
        radius *= canvas;

        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
            player.transform.Translate(Vector3.forward * Time.deltaTime);// * 10f);
    }

    public void Drag(BaseEventData _data)
    {
        moving = true;

        PointerEventData data = _data as PointerEventData;
        Vector3 pos = data.position;


        // 조이스틱을 이동시킬 방향 구함
        JoyVec = (pos - stickFirstPos).normalized;

        // 조이스틱의 처음 위치와 터치하고 있는 위치의 거리
        float dis = Vector3.Distance(pos, stickFirstPos);

        // 거리가 반지름보다 작으면 조이스틱을 현재 터치하는 곳으로 이동
        if (dis < radius)
            stick.position = stickFirstPos + JoyVec * dis;
        // 거리가 반지름보다 크면 반지름 크기만큼
        else
            stick.position = stickFirstPos + JoyVec * radius;

        player.eulerAngles = new Vector3(0, Mathf.Atan2(JoyVec.x, JoyVec.y) * Mathf.Rad2Deg, 0);

        //stick.position = new Vector3(stick.position.x, stickFirstPos.y, stick.position.z);
    }

    public void DragEnd()
    {
        stick.position = stickFirstPos; // 스틱을 원래 위치로
        JoyVec = Vector3.zero;

        moving = false;
    }
}
