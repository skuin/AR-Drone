using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePointUpRotation : MonoBehaviour
{
    private GameObject obstacle;

    public float barSpeed = 1f;

    private bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        obstacle = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (obstacle.GetComponent<Transform>().localRotation.z >= 360f){
            obstacle.GetComponent<Transform>().localEulerAngles = new Vector3(0,0,0);
        }
        else{
            obstacle.GetComponent<Transform>().Rotate(new Vector3(0, 0, barSpeed));
        }
        
    }
}
