using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result_Score : MonoBehaviour
{
    public Text ScoreText;
    double score;

    // Start is called before the first frame update
    void Start()
    {
        score = Score.getscore();
        ScoreText.text = "ScoreÅF" + score.ToString("F1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
