using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FPSInput : MonoBehaviour
{
    /*
    This script handles the input of the player. It allows the player to jump around,
    and if they double jump, they can fly up into the air.

    I will add the functionality to move around and walk through the environment, 
    as well as reset the player position to the middle so you can use world controls
    */
    
    
    public CharacterController controller; 
    public GroundedCheck groundedBox; //the gameobject on the player that holds its grounded trigger
    private Vector3 playerVelocity; //the velocity of the player that is used to move the character control
    public float jumpHeight = 1.0f; //set publicly. the multiplier that sets the jump height
    public float gravityValue = -9.81f; //set publicly. the multiplier that sets the player gravity, how fast they fall

    public bool flying; //the bool that sets the current state of the player, changed by StateChange() if DoubleSpaceCheck() is running true
    [HideInInspector]
    public bool spaceClickCheck; //this bool is true for a short period after the jump button is pressed, if pressed again while true the player starts flying

    private void Start()
    {

    }

    void Update()
    {
        if (flying) //depending on the flying bool, run the state function that handles the character controls
        {
            Flying();
        }
        else if (!flying)
        {
            Jumping();
        }

        StateChange(spaceClickCheck); //checks if the double clicked space is checked, takes in a bool value that allows the double click to happen
    }

    public void Jumping() //this state is when the player is walking around on the ground and jumping
    {
        if (groundedBox.grounded && playerVelocity.y < 0) //if the player is on the ground, dont keep adding gravity
        {
            playerVelocity.y = 0f;
        }

        if (Input.GetKeyDown("space")) //if the space bar is clicked, start the DoubleSpaceCheck()
        {
            StartCoroutine(DoubleSpaceCheck());

            if (groundedBox.grounded) //if the player is on the ground, preform a jump
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }
        }

        playerVelocity.y += gravityValue * Time.deltaTime; //sets the player velocity Y value to the public gravity value

        controller.Move(playerVelocity * Time.deltaTime); //moves the player with the controller using the velocity value
    }

    public void Flying() //this state is when the player is flying
    {
        if (Input.GetKeyDown("space")) //if the player presses space, only start DoubleSpaceCheck() on one frame
        {
            StartCoroutine(DoubleSpaceCheck());
        }

        if (Input.GetKey("space")) //moves the player upwards if the spacebar is held down
        {
            playerVelocity.y = 6;
        }
        else if (Input.GetKey("left ctrl")) //moves the player downwards if the left control is held down
        {
            playerVelocity.y = -6;
        }
        else //if nothing is held, the player stays still
        {
            playerVelocity.y = 0;
        }

        controller.Move(playerVelocity * Time.deltaTime); //moves the player with the controller using the velocity value
    }

    public void StateChange(bool canChange) //called from Update(). if the state can be changed, depending on DoubleSpaceCheck(), and the spacebar is pressed, the state changes
    {
        if (canChange && Input.GetKeyDown("space"))
        {
            flying = !flying;
        }
    }

    public IEnumerator DoubleSpaceCheck() //if this is called, sets the spaceClickCheck as true, allowing StateChange() to change the state
    {
        yield return new WaitForSeconds(0.05f);

        spaceClickCheck = true;

        yield return new WaitForSeconds(0.5f);

        spaceClickCheck = false;
    }
}
