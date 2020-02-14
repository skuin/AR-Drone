using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PassTrigger : MonoBehaviour
{
    public GameObject LightObj;
    
    bool checkGetScore = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 장애물 통과시 호출
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Renderer renderer = LightObj.GetComponent<Renderer>();
            renderer.material.color = Color.green;
            // 트리거 위에있으면 여러번 점수가 획득 되는것을 막기위해
            if(!checkGetScore){
                GameManager.instance.UpgradeScore();
                checkGetScore = true;
            }
        }
    }
}
