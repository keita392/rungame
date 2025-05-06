using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    float countdown = 3f;
    int count;

    const int MinLane = -20;
    const int MaxLane = 20;
    const float LaneWidth = 1.0f;

    CharacterController controller;

    Animator animator;

    Vector3 moveDirection = Vector3.zero;

    int targetLane;

    public float gravity;
    public float speedZ;
    public float speedX;
    public float speedJump;
    public float accelerationZ;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
            count = (int)countdown;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                MoveToLeft();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                MoveToRight();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            float acceleratedZ = moveDirection.z + (accelerationZ * Time.deltaTime);
            moveDirection.z = Mathf.Clamp(acceleratedZ, 0, speedZ);

            float ratioX = (targetLane * LaneWidth - transform.position.x) / LaneWidth;
            moveDirection.x = ratioX * speedX;

            moveDirection.y -= gravity * Time.deltaTime;

            Vector3 globalDirection = transform.TransformDirection(moveDirection);
            controller.Move(globalDirection * Time.deltaTime);

            if (controller.isGrounded)
            {
                moveDirection.y = 0;
            }

            animator.SetBool("Run", moveDirection.z > 0.0f);
        }
    }

    public void MoveToLeft()
    {
        if (controller.isGrounded && targetLane > MinLane)
        {
            targetLane -= 20;
        }
    }

    public void MoveToRight()
    {
        if (controller.isGrounded && targetLane < MaxLane)
        {
            targetLane += 20;
        }
    }

    public void Jump()
    {
        if (controller.isGrounded)
        {
            moveDirection.y = speedJump;
            animator.SetTrigger("Jump");
        }
    }

  
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.tag == "obstacle")
        {
            controller.enabled = false;

            Vector3 back = transform.position - new Vector3(0, 0, 50);
            transform.position = back;
            moveDirection.z = -speedZ;
            animator.SetTrigger("Idle");

            controller.enabled = true;

            Score.reducescore();
        }
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Fall"))
        {
            controller.enabled = false;

            Vector3 fall = transform.position - new Vector3(0, 20, 0);
            transform.position = fall;

            controller.enabled = true;

            flag = 1;
        }
    }
    */
}
