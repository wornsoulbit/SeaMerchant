using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : MonoBehaviour {
    const int LEVEL_1_BUILD_INDEX = 2;
    const int LEVEL_2_BUILD_INDEX = 3;
    const int LEVEL_3_BUILD_INDEX = 4;

    public void StartLevel1() {
        SceneManager.LoadScene(LEVEL_1_BUILD_INDEX);
    }

    public void StartLevel2()
    {
        SceneManager.LoadScene(LEVEL_2_BUILD_INDEX);
    }

    public void StartLevel3()
    {
        SceneManager.LoadScene(LEVEL_3_BUILD_INDEX);
    }
}
