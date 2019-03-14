using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadDude : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameManage.instance.LoseLife();
    }
}
