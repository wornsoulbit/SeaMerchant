using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{
    public GameObject textDisplay;
    public GameObject timeLeftText;
    public GameObject countDownText;

    public int secondsLeft = 0;
    public bool takingAway = false;

    private void Start()
    {
        textDisplay.GetComponent<Text>().text = secondsLeft.ToString();
    }

    private void Update()
    {
        // Updating the seconds.
        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }

        // Prompting Game Over screen if there is no time left.
        if (secondsLeft == 0)
        {
            PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("DeathScreen");
        }

    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (secondsLeft < 10)
        {

            textDisplay.GetComponent<Text>().text = secondsLeft.ToString();
        }
        else
        {
            textDisplay.GetComponent<Text>().text = secondsLeft.ToString();

        }
        takingAway = false;
    }

}