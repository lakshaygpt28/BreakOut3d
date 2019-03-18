using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    public int lives = 3;
    public int bricks = 10;
    public float resetDelay = 1f;
    public Text livesText;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject bricksPrefab;
    public GameObject skate;
    public GameObject deathParticals;
    public static GameManage instance = null;
    public GameObject ball;


    private GameObject cloneSkate;

    

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
        Setup();
    }

    public void Setup()
    {
        cloneSkate = Instantiate(skate, skate.transform.position, skate.transform.rotation) as GameObject;
        Instantiate(bricksPrefab, bricksPrefab.transform.position, Quaternion.identity);       
    }

    void CheckGameOver()
    {
        if (bricks < 1)
        {
            youWon.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }
        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }
    }

    void Reset()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(Application.loadedLevel);
    }
    
    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives;
        Destroy(cloneSkate);
        Destroy(ball);
        Invoke("SetupSkate", resetDelay);
        CheckGameOver();
    }

    void SetupSkate()
    {
        cloneSkate = Instantiate(skate, skate.transform.position, skate.transform.rotation) as GameObject;
    }

    public void DestroyBrick()
    {
        bricks--;
        CheckGameOver();
    }
}
