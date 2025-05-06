using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    public static double score = 0;
    public GameObject player;
    float initialPosition;
    float lastPosition;
    float countdown = 3f;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = player.transform.position.z;
        lastPosition = initialPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
        else
        {
            float currentPosition = player.transform.position.z;
            float distanceTravelled = Mathf.Max(currentPosition - lastPosition, 0); // ˆÚ“®‹——£‚ª•‰‚É‚È‚é‚Ì‚ð–h‚®
            score += distanceTravelled / 2;
            lastPosition = currentPosition;
            ScoreText.text = "Score: " + score.ToString("F1");
        }
    }

    public static double getscore()
    {
        return score;
    }

    public static void resetscore()
    {
        score = 0;
    }

    public static void reducescore()
    {
        score -= 100;
    }

    public static void addscore()
    {
        score += 20;
    }
}
