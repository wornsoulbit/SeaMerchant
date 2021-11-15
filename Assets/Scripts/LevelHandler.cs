using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{
    GameObject optionsMenu;
    GameObject optionButton;
    GameObject restart;
    GameObject quit;

    void Start()
    {
        optionsMenu = GameObject.Find("OptionsMenu");
        optionButton = GameObject.Find("Options");
        restart = GameObject.Find("Restart");
        quit = GameObject.Find("Quit");
    }

    void Update()
    {
        
    }

    public void RestartCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Options()
    {
        restart.SetActive(false);
        quit.SetActive(false);
        optionButton.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
