using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftJoystick : MonoBehaviour
{
    public DroneMovement player;
    public Transform stick;

    private Vector3 stickFirstPos;  // 조이스틱 첫 위치
    private Vector3 JoyVec;         // 조이스틱의 벡터(방향)
    private float radius;           // 조이스틱 배경의 반지름
    private bool moving;
    Rigidbody playerrigi;
    DroneMovement playerdronM;
    
    // Start is called before the first frame update
    void Start()
    {
        radius = GetComponent<RectTransform>().sizeDelta.y * 0.5f;
        stickFirstPos = stick.transform.position;

        // 캔버스 크기에 대한 반지름 조절
        float canvas = transform.parent.GetComponent<RectTransform>().localScale.x;
        radius *= canvas;

        moving = false;
        playerrigi = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
        playerdronM = GameObject.FindWithTag("Player").GetComponent<DroneMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            // 왼쪽의 조이스틱
            // 앞뒤는 움직이고 양 옆은 회전

             if (JoyVec.y > 0.7)
            {
                player.GetComponent<DroneMovement>().customFeed_downward = 0;
                player.GetComponent<DroneMovement>().customFeed_upward = JoyVec.y;
            }
            else if(JoyVec.y == 0)
            {
                player.GetComponent<DroneMovement>().customFeed_downward = 0;
                player.GetComponent<DroneMovement>().customFeed_upward = 0;
            }
            
            else if(JoyVec.y < -0.7){
                player.GetComponent<DroneMovement>().customFeed_downward = 0;
                player.GetComponent<DroneMovement>().customFeed_upward = 0;
                player.GetComponent<DroneMovement>().customFeed_downward = -JoyVec.y;
            }

             if (JoyVec.x > 0.7)
            {
                player.GetComponent<DroneMovement>().customFeed_rotateRight = JoyVec.x;
            }
            else if(JoyVec.x == 0)
            {
                player.GetComponent<DroneMovement>().customFeed_rotateLeft = 0;
                player.GetComponent<DroneMovement>().customFeed_rotateRight = 0;
            }
            else if (JoyVec.x < -0.7)
            {
                player.GetComponent<DroneMovement>().customFeed_rotateLeft = -JoyVec.x;

            }
        }
        else
        {
            player.GetComponent<DroneMovement>().customFeed_upward = 0;
            player.GetComponent<DroneMovement>().customFeed_downward = 0;
            player.GetComponent<DroneMovement>().customFeed_rotateLeft = 0;
            player.GetComponent<DroneMovement>().customFeed_rotateRight = 0;
        }
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
    }

    public void DragEnd()
    {
        stick.position = stickFirstPos; // 스틱을 원래 위치로
        JoyVec = Vector3.zero;

        moving = false;
    }
}
