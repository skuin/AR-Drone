using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject pointCloud;
    public GameObject planeGenerator;

    GameObject scoreObj;
    Text scoreTxt;
    public static int mScore = 0;
    void Awake()
    {
        if (instance == null) instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        pointCloud.SetActive(true);
        planeGenerator.SetActive(true);

        scoreObj = GameObject.Find("Collision");
        scoreTxt = scoreObj.GetComponent<Text>();
        scoreTxt.text = "Collision Count : " + mScore.ToString();
    }

    public void UpgradeScore()
    {
        mScore += 100;
        scoreTxt.text = "Score : " + mScore.ToString();
    }

    public void DowngradeScore()
    {
        mScore += 1;
        scoreTxt.text = "Collision Count : " + mScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
