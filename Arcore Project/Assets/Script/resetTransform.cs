using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetTransform : MonoBehaviour
{
    public GameObject drone;
    public Camera mainCamera;
    public Camera FPCamera;
    public Camera TPCamera;

    Transform startPos;
    Vector3 startRot;

    bool cameraMode = false;
    int cameraMode2 = 0;

    public void CameraChange()
    {
        // if (cameraMode==false){
        //     Debug.Log("Third mode");
        //     FPCamera.enabled = true;
        //     mainCamera.enabled = false;
        //     cameraMode = true;
        // }
        // else{
        //     Debug.Log("First mode");
        //     FPCamera.enabled = false;
        //     mainCamera.enabled = true;
        //     cameraMode = false;
        // }
        
        if (cameraMode2==0){
            Debug.Log("main mode");
            FPCamera.enabled = true;
            mainCamera.enabled = false;
            TPCamera.enabled = false;
            cameraMode2 = 1;
        }
        else if(cameraMode2 ==1 ){
            Debug.Log("First mode");
            FPCamera.enabled = false;
            mainCamera.enabled = false;
            TPCamera.enabled = true;
            cameraMode2 = 2;
        }
        else if(cameraMode2 == 2 ){
            Debug.Log("third mode");
            FPCamera.enabled = false;
            mainCamera.enabled = true;
            TPCamera.enabled = false;
            cameraMode2 = 0;
        }

    }
    public void OnResetButton()
    {
        drone.GetComponent<Transform>().position = new Vector3(0,0,0);
        drone.GetComponent<Transform>().rotation = Quaternion.identity;
        Debug.Log("reset button clicked!");
    }

    public void OnMenuButton()
    {

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
