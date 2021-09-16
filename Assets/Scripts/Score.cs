using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI highScoretext;
    float score;
    int highScore;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;

    }
    // Update is called once per frame
    void Update()
    {
        if (Timer.count == 0)
        {
            score += Time.deltaTime * 1;
            highScore = (int)score;
            scoretext.text = "Score: " + highScore.ToString();

            if (PlayerPrefs.GetInt("score") <= highScore)
            {
                PlayerPrefs.SetInt("score", highScore);
            }
            highScoretext.text = "High Score: " + PlayerPrefs.GetInt("score").ToString();

        }
    }
}
    
    

