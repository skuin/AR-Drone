using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    public GameObject stage;


    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(true);
        stage.SetActive(false);
    }

    public void OnClickSelectStageButton()
    {
        stage.SetActive(true);
        menu.SetActive(false);
        Debug.Log("Stage Button Click");
    }

    public void OnClickExitButton()
    {
        Application.Quit();
        Debug.Log("Exit Button Click");
    }

    public void OnClickBackButton()
    {
        menu.SetActive(true);
        stage.SetActive(false);
        Debug.Log("Back Button Click");
    }

    public void OnClickStage1Button()
    {
        SceneManager.LoadScene("Stage1");
        Debug.Log("Stage1 Button Click");
    }
    
    public void OnClickStage2Button()
    {
        SceneManager.LoadScene("Stage2");
        Debug.Log("Stage2 Button Click");
    }

    public void OnClickFreeStageButton()
    {
        SceneManager.LoadScene("FreeStage");
        Debug.Log("FreeStage Button Click");
    }
}
