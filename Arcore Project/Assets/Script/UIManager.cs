using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager UIMgr;

    public GameObject UI;
    //public GameObject LeftJoy;
    //public GameObject RightJoy;
    //public GameObject ResetPos;
    //public GameObject CameraChange;
    //public GameObject Dir;
    //public GameObject TimerPanel;
    //public GameObject ValuePanel;
    //public GameObject MenuButton;

    // Start is called before the first frame update
    void Start()
    {
        UIMgr = this;

        UI = GameObject.Find("UI");
        //LeftJoy = GameObject.Find("LeftJoystickBackImage");
        //RightJoy = GameObject.Find("RightJoystickBackImage");
        //ResetPos = GameObject.Find("ResetPos");
        //CameraChange = GameObject.Find("CameraChange");
        //Dir = GameObject.Find("Dir");
        //TimerPanel = GameObject.Find("TimerPanel");
        //ValuePanel = GameObject.Find("ValuePanel");
        //MenuButton = GameObject.Find("MenuButton");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetEnableFalse()
    {
        int count = UI.transform.childCount;

        for(int i = 0; i < count; ++i)
        {
            int childcount = UI.transform.GetChild(i).childCount;

            for (int j = 0; j < childcount; ++j)
            {
                if (UI.transform.GetChild(i).GetChild(j).GetComponent<Image>() != null)
                {
                    UI.transform.GetChild(i).GetChild(j).GetComponent<Image>().enabled = false;
                }

                if (UI.transform.GetChild(i).GetChild(j).GetComponent<Text>() != null)
                {
                    UI.transform.GetChild(i).GetChild(j).GetComponent<Text>().enabled = false;
                }
            }

            if (UI.transform.GetChild(i).GetComponent<Image>() != null)
            {
                UI.transform.GetChild(i).GetComponent<Image>().enabled = false;
            }

            if (UI.transform.GetChild(i).GetComponent<Text>() != null)
            {
                UI.transform.GetChild(i).GetComponent<Text>().enabled = false;
            }
        }
    }

    public void SetEnableTrue()
    {
        int count = UI.transform.childCount;

        for (int i = 0; i < count; ++i)
        {
            int childcount = UI.transform.GetChild(i).childCount;

            for (int j = 0; j < childcount; ++j)
            {
                if (UI.transform.GetChild(i).GetChild(j).GetComponent<Image>() != null)
                {
                    UI.transform.GetChild(i).GetChild(j).GetComponent<Image>().enabled = true;
                }

                if (UI.transform.GetChild(i).GetChild(j).GetComponent<Text>() != null)
                {
                    UI.transform.GetChild(i).GetChild(j).GetComponent<Text>().enabled = true;
                }
            }

            if (UI.transform.GetChild(i).GetComponent<Image>() != null)
            {
                UI.transform.GetChild(i).GetComponent<Image>().enabled = true;
            }

            if (UI.transform.GetChild(i).GetComponent<Text>() != null)
            {
                UI.transform.GetChild(i).GetComponent<Text>().enabled = true;
            }
        }
    }
}
