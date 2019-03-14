using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    //public GameObject brickParticle; //effect for removing bricks;

    void OnCollisionEnter()
    {
        Debug.Log("collision");
        //Instantiate(brickParticle, transform.position, Quaternion.identity);
        GameManage.instance.DestroyBrick();
        Destroy(gameObject);
    }
}
