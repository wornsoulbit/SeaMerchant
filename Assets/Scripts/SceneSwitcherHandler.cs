using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcherHandler : MonoBehaviour
{
    void Start()
    {

        // Unlocking the cursor after scene change.
        Cursor.visible = true;
        Screen.lockCursor = false;
    }

    public void RestartLevel()
    {
        string sceneName = PlayerPrefs.GetString("lastLoadedScene");
        SceneManager.LoadScene(sceneName);
        PlayerPrefs.SetInt("lastLevel", SceneManager.GetActiveScene().buildIndex);
        /*SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);*/
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
