using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneDirection : MonoBehaviour
{
    public GameObject drone;

    Quaternion rot;

    void Awake()
    {
        //this.transform.rotation = new Quaternion(0, drone.GetComponent<Transform>().rotation.y + 90f, 0, 0);
        this.transform.localRotation = Quaternion.Euler(0,-90, 0);
        
    }
    // Update is called once per frame
    void Update()
    {
        //this.transform.Rotate(new Vector3(0,drone.GetComponent<Transform>().rotation.y,0));
        this.transform.rotation = drone.GetComponent<Transform>().rotation;
    }
}
