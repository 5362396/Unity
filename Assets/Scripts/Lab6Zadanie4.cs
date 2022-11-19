using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab6Zadanie4 : MonoBehaviour
{
    private Vector3 playerVelocity;
    private float jumpHeight = 3f;
    private float gravityValue = -9.81f;
    public CharacterController controller;
    private bool groundedPlayer;
    private int xd;
    void Start()
    {
        xd = 0;
    }

    void Update()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<CharacterController>();
        
        Debug.Log(playerVelocity.y);
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y > 9)
        {
            xd = 0;
            playerVelocity.y = 0f;
        }

        if (xd == 1)
        {
            Debug.Log("jestem tu");
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
            xd = 1;
        }
    }
}
