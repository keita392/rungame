using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move_Result : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");

        Vector3 player_p = player.transform.position;

        if(player_p.y < -100)
        {
            SceneManager.LoadScene("Result");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Result");
    }
}
