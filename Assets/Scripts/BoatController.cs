using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BoatController : MonoBehaviour {
	[Space(15)]
	public float speed = 300.5f;
	public float steerSpeed = 2000.0f;
	public float movementThreshold = 2.0f;

	public GameObject wheel;
	public GameObject player;
	public GameObject interactImage;
	public GameObject hammer;
	public GameObject loadingScreen;
	public Vector3 cameraStartPosition;

	public bool isMounted;
	public Slider slider;

	private bool end = false;

	// Update is called once per frame
	void Update()
	{

		// Distance between the player and steering wheel
		float distance = Vector3.Distance(player.transform.position, wheel.transform.position);

		// Radius of the steering wheel
		float radius = wheel.GetComponent<Interactable>().radius;
		// Debug.Log(distance);

		if (distance < radius)
		{
            if (!isMounted)
			{
				interactImage.SetActive(true);
			}

			// If the "E" key is pressed
			if (Input.GetKeyDown(KeyCode.E) && !isMounted)
			{
				interactImage.SetActive(false);
				// Disables character movement
				player.GetComponent<PlayerController>().canMovePlayer = false;
				Debug.Log("Got ON the steering wheel");
				isMounted = true;
				player.transform.SetParent(this.transform);

				// hides hammer
				hammer.SetActive(false);
			}
			// If the "Escape" key is pressed
			else if (Input.GetKeyDown(KeyCode.E) && isMounted)
			{
                // Re-enables the character movement
                player.GetComponent<PlayerController>().canMovePlayer = true;
				Debug.Log("Got OFF the steering wheel");
				isMounted = false;
				player.transform.SetParent(null);

				//unhides hammer
				hammer.SetActive(true);
			}
			else{
				//suck my balls
			}
        }
        else
        {
			interactImage.SetActive(false);
		}


		// When mounted, the boat controls are enabled.
		if (isMounted)
		{
			Movement();
			Steer();
			EndLevelCheck();
		}
	}

    void Movement()
	{
		float verticalInput = 0.0f;

		// If the "W" key is held down. The boat goes forward quickly.
		if (Input.GetKey(KeyCode.W))
		{
			verticalInput = Input.GetAxis("Vertical") * -3.5f;

		}

		// If the "S" key is held down. The boat goes back slowly.
		if (Input.GetKey(KeyCode.S))
		{
			verticalInput = Input.GetAxis("Vertical") * -1.5f;
		}

		transform.Translate(0.0f, 0.0f, verticalInput * Time.deltaTime * movementThreshold);
	}

	void Steer()
	{
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
		{
			float horizontalInput = Input.GetAxis("Horizontal");
			transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * (steerSpeed * 15));
		}

	}

	void EndLevelCheck()
    {
		float distance = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("EndOfLevel").transform.position);

		switch (SceneManager.GetActiveScene().buildIndex)
		{
			case 2:
				if (distance < 40f)
				{
					NextLevelLoad();
				}
				break;
			case 3:
				if (distance < 100f)
				{
					NextLevelLoad();
				}
				break;
		}
        
    }

    void NextLevelLoad()
    {
		if (SceneManager.GetActiveScene().buildIndex < 4 && !end)
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
            end = true;
            Debug.Log("End of level");
        }
    }

    IEnumerator LoadLevel(int levelIndex)
	{
		Debug.Log("Starting Level Transisition");
		/*musicTransition.SetTrigger("Start");*/

		AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);

		loadingScreen.SetActive(true);

		while (!operation.isDone)
		{
			slider.value = operation.progress;
			yield return null;
		}
	}
}
