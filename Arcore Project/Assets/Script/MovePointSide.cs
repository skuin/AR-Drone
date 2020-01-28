using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePointSide : MonoBehaviour
{
    private float xPos = 0;
    private Vector3 firstPos;
    private GameObject obstacle;

    public float barSpeed = 0.1f;

    private bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        obstacle = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (obstacle.GetComponent<Transform>().localPosition.x >= 2.3f){
            flag = true;
            //barSpeed *= -1f;
        }
        
        else if(obstacle.GetComponent<Transform>().localPosition.x <= -2.3f)
        {
            flag = false;
            //barSpeed *= -1f;
        }
        
        //obstacle.GetComponent<Transform>().Translate(barSpeed,0,0);
        

        if(flag == false)
        {
            //xPos += 0.1f;
            obstacle.GetComponent<Transform>().Translate(barSpeed,0,0);
        }
        else
        {
            //xPos -= 0.1f;
            obstacle.GetComponent<Transform>().Translate(-barSpeed,0,0);
        }
    }
}
