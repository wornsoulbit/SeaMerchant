using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float originalHeight = 3f;
    public float crouchHeight = 1.5f;
    public bool viewBob;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Animator damg;

    Vector3 velocity;
    bool isGrounded;

    public Camera playerCamera;
    public bool canMovePlayer;
    bool paused;
    bool isMounted;

    GameObject hud;
    GameObject pauseMenu;

    private void Start()
    {
        canMovePlayer = true;
        paused = false;
        isMounted = false;
        hud = GameObject.Find("HUD");
        pauseMenu = GameObject.Find("PauseMenu");
        pauseMenu.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        PauseUnPause();

        if (canMovePlayer)
        {
            // Checks if the player is on the ground.
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            // Pushes the player to the ground
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            // 'Sprint' key. Moves player faster
            if (Input.GetKey("left shift"))
            {
                speed = 15f;
            }
            else
            {
                speed = 12f;
            }

            // Crouch
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                controller.height = crouchHeight;
                speed = 8f;
            }
            else if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                controller.height = originalHeight;
                speed = 12f;
            }

            // Inputs for player movement forward and right
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            // Where the player will move in the transform
            Vector3 move = transform.right * x + transform.forward * y;
            controller.Move(move * speed * Time.deltaTime);

            // Jump
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            // Adds gravity to the player.
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

    }

    private void PauseUnPause()
    {
        isMounted = GameObject.FindGameObjectWithTag("Boat").GetComponent<BoatController>().isMounted;

        if (Input.GetKeyDown(KeyCode.Escape) && !isMounted)
        {
            if (paused)
            {
                UnPause();
                Debug.Log("Un-pause");
                hud.SetActive(true);
                pauseMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Pause();
                Debug.Log("Pause");
                hud.SetActive(false);
                pauseMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
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
