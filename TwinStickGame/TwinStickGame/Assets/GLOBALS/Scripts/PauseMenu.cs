using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject healtUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
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
    void pause () //8:00 video brackeys
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
//<<<<<<< HEAD
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScreen");
    }
//=======
//>>>>>>> parent of 7ac093a (Merge branch 'main' of https://github.com/Kappis06/TwinStickGame)
}
