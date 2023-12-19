using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Pause"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
