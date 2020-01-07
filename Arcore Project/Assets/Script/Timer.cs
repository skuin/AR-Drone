using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [HideInInspector]
    public float timer;

    private float timeMin;
    private float timeSec;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
        timeSec += Time.deltaTime;

        if (timeSec > 60.0f)
        {
            timeMin += 1;
            timeSec -= 60.0f;
        }

        string timestr = "";
        timestr = "" + timeSec.ToString("00.00");
        timestr = timestr.Replace(".", ":");
        GetComponent<Text>().text = "Time : " + timeMin + ":" + timestr;
    }
}
