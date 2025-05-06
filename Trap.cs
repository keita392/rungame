using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Trap : MonoBehaviour
{
    public int flag;

    public GameObject player;

    CharacterController controller;
    Animator animator;

    Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        controller = player.GetComponent<CharacterController>();
        animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(flag == 1)
        {
            animator.SetBool("Run", false);
            moveDirection = new Vector3(0, -1 * Time.deltaTime, -1);
            controller.Move(moveDirection);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit");

            controller.enabled = false;

            Vector3 fall = player.transform.position - new Vector3(0, 20, 0);
            player.transform.position = fall;

            controller.enabled = true;

            flag = 1;
        }
    }
}
