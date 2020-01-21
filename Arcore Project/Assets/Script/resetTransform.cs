using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resetTransform : MonoBehaviour
{
    public GameObject drone;
    public Camera mainCamera;
    public Camera FPCamera;
    public Camera TPCamera;

    public Image panelImage;
    public Text FCTxt;
    public Text TCTxt;
    public Text FixCTxt;
    Transform startPos;
    Vector3 startRot;

    bool cameraMode = false;
    int cameraMode2 = 0;

    public void CameraChange()
    {
        if (cameraMode2==0){
            Debug.Log("main mode");
            FPCamera.enabled = true;
            mainCamera.enabled = false;
            TPCamera.enabled = false;
            cameraMode2 = 1;
            StartCoroutine("ChangeCameraText");
        }
        else if(cameraMode2 ==1 ){
            Debug.Log("First mode");
            FPCamera.enabled = false;
            mainCamera.enabled = false;
            TPCamera.enabled = true;
            cameraMode2 = 2;
            StartCoroutine("ChangeCameraText");
        }
        else if(cameraMode2 == 2 ){
            Debug.Log("third mode");
            FPCamera.enabled = false;
            mainCamera.enabled = true;
            TPCamera.enabled = false;
            cameraMode2 = 0;
            StartCoroutine("ChangeCameraText");
        }

    }

    IEnumerator ChangeCameraText()
    {
        panelImage.enabled = true;
        if(cameraMode2 == 1)
        {
            FCTxt.enabled = true;
        }
        else if (cameraMode2 == 2)
        {
            TCTxt.enabled = true;
        }
        else if(cameraMode2 == 0)
        {
            FixCTxt.enabled = true;
        }
        yield return new WaitForSeconds(2.0f);

        panelImage.enabled = false;
        FCTxt.enabled = false;
        TCTxt.enabled = false;
        FixCTxt.enabled = false;
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
