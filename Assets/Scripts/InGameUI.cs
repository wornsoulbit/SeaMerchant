using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour {
    const int MAIN_MENU_BUILD_INDEX = 0;
    const int LEVEL_1_BUILD_INDEX = 1;
    const int LEVEL_2_BUILD_INDEX = 2;
    const int LEVEL_3_BUILD_INDEX = 3;

    public void TransitionToNextLevel() {
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            if (SceneManager.GetActiveScene().buildIndex < LEVEL_3_BUILD_INDEX && SceneManager.GetActiveScene().buildIndex > MAIN_MENU_BUILD_INDEX) //If is not last Scene (Level 1, and Level 2)
            {
                //Transition to the next level.
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if (SceneManager.GetActiveScene().buildIndex == LEVEL_3_BUILD_INDEX) // If is last Scene (Level 3 only)
            {
                //Display "Game Completed" 

                ReturnToMainMenu(); //<--Placeholder
            }
        }
    }

    public void EnableDeveloperShortcuts() {
        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            ReturnToMainMenu();
        }
    }

    public void ReturnToMainMenu() {
        SceneManager.LoadScene(MAIN_MENU_BUILD_INDEX);
    }

    /*
     * Placeholder "Update()" method (Remove before deploying)
     */
    public void Update() {

        //DEBUGGING - Transition to next level
        TransitionToNextLevel();

        //PLACEHOLDER
        EnableDeveloperShortcuts();
    }
}
