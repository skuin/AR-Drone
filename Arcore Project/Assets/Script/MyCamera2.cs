using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera2 : MonoBehaviour
{
    public GameObject drone;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = drone.transform.position - drone.transform.forward * 8.0f;
        // 드론 기준으로 카메라 좀 위로 올려야함
    }

    // Update is called once per frame
    void Update()
    {
        // 카메라가 드론의 일정거리 뒤에서 쫓아온다
    }
}
