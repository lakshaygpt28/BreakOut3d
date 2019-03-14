using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMovement : MonoBehaviour
{
    //public Rigidbody rb;
    public float speed = 1;
    public float leftBorder = -10, rightBorder = 10;
    private Vector3 playerPos = new Vector3(0, 1, -21);

    void Update()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        playerPos = new Vector3(Mathf.Clamp(xPos, -12.5f, 12.5f), 1, -21);
        transform.position = playerPos;
    }
}
