using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FPSInput : MonoBehaviour
{
    public CharacterController controller;
    public GroundedCheck groundedBox;
    private Vector3 playerVelocity;
    public float playerSpeed = 2.0f;
    public float playerWalkSpeed = 2.0f;
    public float playerSprintSpeed = 9.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;

    private void Start()
    {
    }

    void Update()
    {
        if (groundedBox.grounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = transform.TransformDirection(move);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if(Input.GetKey("left shift") && groundedBox.grounded)
        {
            playerSpeed = playerSprintSpeed;
        }
        else
        {
            playerSpeed = playerWalkSpeed;
        }

        // Changes the height position of the player..
        if (Input.GetKeyDown("space") && groundedBox.grounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            groundedBox.grounded = false;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;

        controller.Move(playerVelocity * Time.deltaTime);
    }
}
