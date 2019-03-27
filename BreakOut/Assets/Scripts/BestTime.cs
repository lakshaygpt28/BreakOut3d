using UnityEngine;
using UnityEngine.UI;

public class BestTime : MonoBehaviour
{
    public Text bestTime;
    // Start is called before the first frame update
    void Start()
    {
        bestTime = GetComponent<Text> ();
        bestTime.text = "BEST TIME : " + PlayerPrefs.GetFloat("HighScore", 0).ToString("0.0");
    }
    
}
