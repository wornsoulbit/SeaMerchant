using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour {
	[Space(15)]
	public float speed = 300.5f;
	public float steerSpeed = 2000.0f;
	public float movementThreshold = 2.0f;

	public GameObject wheel;
	public GameObject player;
	public GameObject interactImage;
	public Camera playerCamera;
	public Vector3 cameraStartPosition;

	bool isMounted;

    // Update is called once per frame
    void Update()
	{

		// Distance between the player and steering wheel
		float distance = Vector3.Distance(player.transform.position, wheel.transform.position);

		// Radius of the steering wheel
		float radius = wheel.GetComponent<Interactable>().radius;
		Debug.Log(distance);

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
			}

			// If the "Escape" key is pressed
			if (Input.GetKeyDown(KeyCode.Escape) && isMounted)
			{
				// Re-enables the character movement
				player.GetComponent<PlayerController>().canMovePlayer = true;
				Debug.Log("Got OFF the steering wheel");
				isMounted = false;
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
		player.transform.position = new Vector3(wheel.transform.position.x, wheel.transform.position.y, wheel.transform.position.z + 0.5f);
	}

	void Steer()
	{
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
		{
			float horizontalInput = Input.GetAxis("Horizontal");
			transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * (steerSpeed * 15));
			player.transform.position = new Vector3(wheel.transform.position.x, wheel.transform.position.y, wheel.transform.position.z + 0.5f);
			/*player.transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * steerSpeed);*/
		}

	}
}
