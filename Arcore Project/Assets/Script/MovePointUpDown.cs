using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePointUpDown : MonoBehaviour
{
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
        if (obstacle.GetComponent<Transform>().localPosition.y >= 2.3f){
            flag = true;
        }
        
        else if(obstacle.GetComponent<Transform>().localPosition.y <= -2.3f)
        {
            flag = false;
        }
        
        //obstacle.GetComponent<Transform>().Translate(barSpeed,0,0);
        

        if(flag == false)
        {
            obstacle.GetComponent<Transform>().Translate(0,barSpeed,0);
        }
        else
        {
            obstacle.GetComponent<Transform>().Translate(0,-barSpeed,0);
        }
    }
}
