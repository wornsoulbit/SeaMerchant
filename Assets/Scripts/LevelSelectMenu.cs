using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectMenu : MonoBehaviour {
    const int LEVEL_1_BUILD_INDEX = 2;
    const int LEVEL_2_BUILD_INDEX = 3;
    const int LEVEL_3_BUILD_INDEX = 4;

    public Animator transition;
    public Animator musicTransition;

    public float transistionTime = 1f;

    public GameObject LoadingScreen;
    public Slider slider;

    public void StartLevel1() {
        StartCoroutine(LoadLevel(LEVEL_1_BUILD_INDEX));
        Debug.Log("Loading Level 1");
    }

    public void StartLevel2()
    {
        StartCoroutine(LoadLevel(LEVEL_2_BUILD_INDEX));
    }

    public void StartLevel3()
    {
        StartCoroutine(LoadLevel(LEVEL_3_BUILD_INDEX));
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadMainMenu()
    {
        StartCoroutine(LoadLevel(0));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        Debug.Log("Starting Level Transisition");
        /*musicTransition.SetTrigger("Start");*/

        yield return new WaitForSeconds(transistionTime);

        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);

        LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            slider.value = operation.progress;
            yield return null;
        }
    }
}
