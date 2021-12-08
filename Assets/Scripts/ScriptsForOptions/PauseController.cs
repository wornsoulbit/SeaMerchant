using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    // Pause Menu objects.
    GameObject hud;
    GameObject restart;
    GameObject mainMenu;
    GameObject options;
    GameObject optionsMenu;

    bool paused;
    bool isOptionsActive;

    public Animator transition;
    public float transistionTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // Assigning UI elements so that they can be modified.
        hud = GameObject.Find("HUD");
        restart = GameObject.Find("Restart");
        mainMenu = GameObject.Find("MainMenu");
        options = GameObject.Find("Options");
        optionsMenu = GameObject.Find("OptionsMenu");

        // Deactivating UI elements.
        PauseMenuUiControl(false);
        optionsMenu.SetActive(false);

        // Local vars to keep track if the the game is paused.
        isOptionsActive = false;
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        PauseUnPause();
    }

    private void PauseUnPause()
    {
        // Checks if the player is mounted on the boat.
        bool isMounted = GameObject.FindGameObjectWithTag("Boat").GetComponent<BoatController>().isMounted;

        // If the player pressed escape key and is not on the boat the game will
        // either pause or unpause.
        if (Input.GetKeyDown(KeyCode.Escape) && !isMounted)
        {
            if (paused)
            {
                UnPause();
                PauseMenuUiControl(false);
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = false;
            }
            else
            {
                Pause();
                PauseMenuUiControl(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    public void OptionsMenu()
    {
        PauseMenuUiControl(false);
        optionsMenu.SetActive(true);
        isOptionsActive = true;
    }
    
    public void RestartCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        Debug.Log("Starting Level Transisition");
        /*musicTransition.SetTrigger("Start");*//*

        yield return new WaitForSeconds(transistionTime);

        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);


        while (!operation.isDone)
        {
            yield return null;
        }*/
        SceneManager.LoadScene(levelIndex);

        yield return null;
    }

    /// <summary>
    /// Controls which UI elements are active in the game scene. 
    /// </summary>
    /// <param name="isActive">Activation state of a UI element.</param>
    private void PauseMenuUiControl(bool isActive)
    {
        hud.SetActive(!isActive);
        options.SetActive(isActive);
        restart.SetActive(isActive);
        mainMenu.SetActive(isActive);
        options.SetActive(isActive);

        if (isOptionsActive)
        {
            optionsMenu.SetActive(false);
            isOptionsActive = false;
        }
    }

    void Pause()
    {
        Time.timeScale = 0;
        paused = true;
    }

    void UnPause()
    {
        Time.timeScale = 1;
        paused = false;
    }


}
