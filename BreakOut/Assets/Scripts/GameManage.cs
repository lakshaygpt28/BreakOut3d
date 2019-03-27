using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    public int lives = 3;
    public int bricks = 10;
    public float time = 0f;
    public float resetDelay = 1f;
    public bool gameStart = false;
    public Text livesText;
    public Text timeText;
    public Text scoreText;
    //public Text highscoreText;
    public Text bestTime;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject bricksPrefab;
    public GameObject skate;
    public GameObject deathParticals;
    public static GameManage instance = null;
    public GameObject ball;


    private GameObject cloneSkate;

    private const string URL = "/api/newscore";
    //private const string token = "abcdefghijklmnopqrstuvwxyz";
    string tokens = "not_input";



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
        //bestTime.text = "BEST TIME : " + PlayerPrefs.GetFloat("HighScore", 0).ToString("0.0");
        Setup();
    }
    public void ctrl(string text)
    {
        tokens = text;
    }
    void Update()
    {
        if (gameStart)
        {
            time += Time.deltaTime;
            timeText.text = "Time : " + time.ToString("0.0");
        }
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
            Request();
            gameStart = false;
            //scoreText.text = "SCORE : " + time.ToString("0.0");
            //bestTime.text = "BEST TIME : " + PlayerPrefs.GetFloat("HighScore", 0).ToString("0.0");
            scoreText.text = "SCORE : " + time.ToString("0.0");
            youWon.SetActive(true);
            Time.timeScale = .25f;
            //Invoke("Reset", resetDelay);
        }
        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            //Invoke("Reset", resetDelay);
        }
    }

    public void Reset()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(Application.loadedLevel);
    }
    
    public void LoseLife()
    {
        lives--;
        gameStart = false;
        livesText.text = "Lives: " + lives;
        Destroy(cloneSkate);
        Destroy(ball);
        CheckGameOver();
        if (lives >= 1 && bricks >= 1)
        {
            Invoke("SetupSkate", resetDelay);
        }
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

    public void Request()
    {
        WWWForm form = new WWWForm();

        Dictionary<string, string> headers = form.headers;

        form.AddField("score", time.ToString("0.00"));
        form.AddField("tokens", tokens);

        byte[] rawFormData = form.data;

        WWW request = new WWW(URL, rawFormData, headers);
    }
}
