using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class resetTransform : MonoBehaviour
{
    public GameObject drone;    // 드론
    public Camera mainCamera;   // 고장 카메라
    public Camera FPCamera;     // 1인칭 카메라
    public Camera TPCamera;     // 3인칭 카메라

    public Image panelImage;    // 카메라 종류나타낼 패널
    public Text FCTxt;      // 1인칭 카메라 텍스트
    public Text TCTxt;      // 3인칭 카메라 텍스트
    public Text FixCTxt;    // 고정 카메라 텍스트
    Transform startPos;     // 처음 드론위치 저장
    Vector3 startRot;

    int cameraMode = 0;     // 카메라 인칭 모드 ( 고정 - 1인칭 - 3인칭 )

    // 카메라 모드 설정
    public void CameraChange()
    {
        if (cameraMode==0){
            Debug.Log("main mode");
            FPCamera.enabled = true;
            mainCamera.enabled = false;
            TPCamera.enabled = false;
            cameraMode = 1;
            StartCoroutine("ChangeCameraText");
        }
        else if(cameraMode ==1 ){
            Debug.Log("First mode");
            FPCamera.enabled = false;
            mainCamera.enabled = false;
            TPCamera.enabled = true;
            cameraMode = 2;
            StartCoroutine("ChangeCameraText");
        }
        else if(cameraMode == 2 ){
            Debug.Log("third mode");
            FPCamera.enabled = false;
            mainCamera.enabled = true;
            TPCamera.enabled = false;
            cameraMode = 0;
            StartCoroutine("ChangeCameraText");
        }

    }

    // 카메라 종류 텍스트 출력 
    IEnumerator ChangeCameraText()
    {
        panelImage.enabled = true;
        if(cameraMode == 1)
        {
            FCTxt.enabled = true;
        }
        else if (cameraMode == 2)
        {
            TCTxt.enabled = true;
        }
        else if(cameraMode == 0)
        {
            FixCTxt.enabled = true;
        }
        yield return new WaitForSeconds(2.0f);

        panelImage.enabled = false;
        FCTxt.enabled = false;
        TCTxt.enabled = false;
        FixCTxt.enabled = false;
    }

    // 리셋버튼 클릭시 포지션, 로테이션초기화
    public void OnResetButton()
    {
        drone.GetComponent<Transform>().position = new Vector3(0,0,0);
        drone.GetComponent<Transform>().rotation = Quaternion.identity;
        Debug.Log("reset button clicked!");
    }

    // X 버튼 클릭시 메뉴로 돌아감
    public void OnMenuButton()
    {
        SceneManager.LoadScene("Menu");
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
