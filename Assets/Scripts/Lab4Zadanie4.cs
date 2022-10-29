using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab4Zadanie4 : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 5.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public Transform player;
    public float sensitivity = 2f;
    private float mouseXMove = 0.0f;
    private float mouseYMove = 0.0f;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        controller.slopeLimit = 50.0f;
        controller.stepOffset = 0.5f;
        controller.minMoveDistance = 0f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        mouseXMove += Input.GetAxis("Mouse X") * sensitivity;
        mouseYMove -= Input.GetAxis("Mouse Y") * sensitivity;
        mouseYMove = Mathf.Clamp(mouseYMove, -90f, 90f);

        transform.eulerAngles = new Vector3(mouseYMove, mouseXMove, 0);
    }

    void FixedUpdate()
    {
        
    }
}
