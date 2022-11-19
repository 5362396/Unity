using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab6Zadanie4 : MonoBehaviour
{
    private Vector3 playerVelocity;
    private float jumpHeight = 3f;
    private float gravityValue = -9.81f;
    private GameObject player;
    private CharacterController controller;
    private bool groundedPlayer;
    private int changeState;
    void Start()
    {
        changeState = 0;
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<CharacterController>();
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y > 9)
        {
            changeState = 0;
            playerVelocity.y = 0f;
        }

        if (changeState == 1)
        {
            if (groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }
            controller.Move(playerVelocity * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            changeState = 1;
        }
    }
}
