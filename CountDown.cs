using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public Text CountText;
    float countdown = 3f;
    int count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(count >= 0)
        {
            countdown -= Time.deltaTime;
            count = (int)countdown;
            CountText.text = count.ToString();
        }
        else
        {
            CountText.text = "";
        }
    }
}
