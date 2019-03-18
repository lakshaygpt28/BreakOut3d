using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody rb;
    private bool ballInPlay = false;
    public float ballInitialVelocity = 500f;

    // Use this for initialisation
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        GameManage.instance.gameStart = false;
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.name == "DeadZone")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ballInPlay == false)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(ballInitialVelocity / 2, 0, ballInitialVelocity);
            GameManage.instance.gameStart = true;
            
        }

    }

}
