using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetTransform : MonoBehaviour
{
    public GameObject drone;
    public Camera mainCamera;
    public Camera FPCamera;

    Transform startPos;
    Vector3 startRot;

    bool cameraMode = false;

    public void CameraChange()
    {
        if (cameraMode==false){
            Debug.Log("Third mode");
            FPCamera.enabled = true;
            mainCamera.enabled = false;
            cameraMode = true;
        }
        else{
            Debug.Log("First mode");
            FPCamera.enabled = false;
            mainCamera.enabled = true;
            cameraMode = false;
        }
    }
    public void OnResetButton()
    {
        //drone.GetComponent<Transform>().rotation = Quaternion.identity; 
        drone.GetComponent<Transform>().position = new Vector3(0,0,0);
        drone.GetComponent<Transform>().rotation = Quaternion.identity;
        Debug.Log("reset button clicked!");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
