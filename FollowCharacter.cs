using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    Vector3 vector;

    public GameObject target;

    public float followSpeed;

    // Start is called before the first frame update
    void Start()
    {
        vector = target.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            target.transform.position - vector,
            Time.deltaTime * followSpeed);
    }
}
