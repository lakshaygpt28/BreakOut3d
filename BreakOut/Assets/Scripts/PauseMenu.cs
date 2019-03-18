using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    bool ispaused;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ispaused = !ispaused;
            Debug.Log(ispaused);
        }
        if (ispaused)
        {
            ActivateMenu();
        } else if (pauseMenuUI.active)
        {
            DeactivateMenu();
        }
    }

    void ActivateMenu()
    {
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
    }
     public void DeactivateMenu()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        ispaused = false;
    }
}
