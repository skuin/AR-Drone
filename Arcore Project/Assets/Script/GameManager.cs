using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글톤

    public GameObject pointCloud;   // 평면 인식을 하는 point
    public GameObject planeGenerator;   // 화면에 표시할 평면

    GameObject scoreObj;    // Hierichy에 배치된 'ScoreTextPanel' Text Object
    GameObject collCountObj;    // Hierichy에 배치된 'Collision' Text Object
    Text scoreTxt;  // 'ScoreTextPanel' Text Object의 component 중 text 저장
    Text collCountTxt;  // 'Collision' Text Obj의 componetn 중 text 저장
    public static int mScore = 0;   // 점수
    public static int mCollisionCount = 0; // 충돌 횟수
    void Awake()
    {
        // 싱글톤
        if (instance == null) instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        pointCloud.SetActive(true);
        planeGenerator.SetActive(true);

        // 오브젝트 할당
        scoreObj = GameObject.Find("ScoreTextPanel");
        scoreTxt = scoreObj.GetComponent<Text>();
        scoreTxt.text = "Score : " + mScore.ToString();

        collCountObj = GameObject.Find("Collision");
        collCountTxt = collCountObj.GetComponent<Text>();
        collCountTxt.text = "Collision Count : " + mCollisionCount.ToString();
    }

    // 점수 증가
    public void UpgradeScore()
    {
        mScore += 100;
        scoreTxt.text = "Score : " + mScore.ToString();
    }


    // 점수 감소 및 충돌 횟수 증가
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
