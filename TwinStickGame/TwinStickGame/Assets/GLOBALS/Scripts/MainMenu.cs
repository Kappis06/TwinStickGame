using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject helpScreen;
    public GameObject creditsScreen;

    public EventSystem eventSystem;
    public GameObject playButton;
    public GameObject helpReturnButton;
    public GameObject creditsReturnButton;



    void Start()
    {
        mainMenu.SetActive(true);
        helpScreen.SetActive(false);
        creditsScreen.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Help()
    {
        helpScreen.SetActive(true);
        mainMenu.SetActive(false);
        eventSystem.SetSelectedGameObject(helpReturnButton);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Credits()
    {
        creditsScreen.SetActive(true);
        mainMenu.SetActive(false);
        eventSystem.SetSelectedGameObject(creditsReturnButton);
    }

    public void GoBack()
    {
        mainMenu.SetActive(true);
        helpScreen.SetActive(false);
        creditsScreen.SetActive(false);
        eventSystem.SetSelectedGameObject(playButton);
    }
}
