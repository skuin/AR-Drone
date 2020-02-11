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
    GameObject collCountObj;
    Text scoreTxt;
    Text collCountTxt;
    public static int mScore = 0;
    public static int mCollisionCount = 0;
    void Awake()
    {
        if (instance == null) instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        pointCloud.SetActive(true);
        planeGenerator.SetActive(true);

        scoreObj = GameObject.Find("ScoreTextPanel");
        scoreTxt = scoreObj.GetComponent<Text>();
        scoreTxt.text = "Score : " + mScore.ToString();

        collCountObj = GameObject.Find("Collision");
        collCountTxt = collCountObj.GetComponent<Text>();
        collCountTxt.text = "Collision Count : " + mCollisionCount.ToString();
    }

    public void UpgradeScore()
    {
        mScore += 100;
        scoreTxt.text = "Score : " + mScore.ToString();
    }

    public void DowngradeScore()
    {
        if(mScore > 0)
            mScore -= 20;
        scoreTxt.text = "Score : " + mScore.ToString();

        mCollisionCount += 1;
        collCountTxt.text = "Collision Count : " + mCollisionCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
