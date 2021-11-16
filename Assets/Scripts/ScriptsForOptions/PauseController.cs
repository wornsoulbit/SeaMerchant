using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{

    GameObject hud;
    GameObject restart;
    GameObject quit;
    GameObject options;
    GameObject optionsMenu;

    bool paused;
    bool isMounted;
    bool isOptionsActive;

    // Start is called before the first frame update
    void Start()
    {
        // Assigning UI elements so that they can be modified.
        hud = GameObject.Find("HUD");
        restart = GameObject.Find("Restart");
        quit = GameObject.Find("Quit");
        options = GameObject.Find("Options");
        optionsMenu = GameObject.Find("OptionsMenu");

        // Deactivating UI elements.
        PauseMenuUiControl(false);
        optionsMenu.SetActive(false);

        // Local vars to keep track if the player is on the boat or 
        // if the game is paused.
        isMounted = false;
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
        isMounted = GameObject.FindGameObjectWithTag("Boat").GetComponent<BoatController>().isMounted;

        // If the player pressed escape key and is not on the boat the game will
        // either pause or unpause.
        if (Input.GetKeyDown(KeyCode.Escape) && !isMounted)
        {
            if (paused)
            {
                UnPause();
                PauseMenuUiControl(false);
                Debug.Log("Un-pause");
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = false;
            }
            else
            {
                Pause();
                PauseMenuUiControl(true);
                Debug.Log("Pause");
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

    /// <summary>
    /// Controls which UI elements are active in the game scene. 
    /// </summary>
    /// <param name="isActive">Activation state of a UI element.</param>
    private void PauseMenuUiControl(bool isActive)
    {
        hud.SetActive(!isActive);
        options.SetActive(isActive);
        restart.SetActive(isActive);
        quit.SetActive(isActive);
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
