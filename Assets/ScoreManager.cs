using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; 

public class ScoreManager : MonoBehaviour
{


    public Text ScoreText;
    private int score = 0;


    // 初期化
    void Start()
    {
        score = 0;
        SetScore();
}

    void OnCollisionEnter(Collision collision)
    {
    string objectTag = collision.gameObject.tag;

    if(objectTag == "LargeStarTag")
    {
        score += 300;
     }
        else if (objectTag == "SmallStarTag")
        {
            score += 0;
        }
        else if (objectTag == "SmallCloudTag")
    {
        score -= 20;
    }
    else if (objectTag == "LargeCloudTag")
    {
        score -= 50;
    }
    else
    {
            score += 0;
    }
    SetScore();
}
    void SetScore()
    {

        // テキストの表示を入れ替える
        ScoreText.text = string.Format("Score;{0}", score);
    }

    // 更新
    void Update()
    {


    }
}
