using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    //public GameObject brickParticle; //effect for removing bricks;
    public AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponentInParent<AudioSource> ();   
    }

    void OnCollisionExit()
    {
        Debug.Log("collision");
        audioSource.Play();
        //Instantiate(brickParticle, transform.position, Quaternion.identity);
        
        GameManage.instance.DestroyBrick();
        Destroy(gameObject);
    }
}
