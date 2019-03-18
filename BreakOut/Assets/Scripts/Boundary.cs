using UnityEngine;

public class Boundary : MonoBehaviour
{
    public AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter()
    {
        Debug.Log("collision");
        audioSource.Play();
    }
}
