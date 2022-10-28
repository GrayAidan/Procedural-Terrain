using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWorldMove : MonoBehaviour
{
    /*
    This class handles all of the controls to change the terrain noise. It doesnt allow the player to use these controls if the player is too low,
    and changes the text at the top of the screen to let the player know that they need to fly higher to use.
    */
    public PerlinNoise _pn; //set publicly. the perlin noise script of the terrain
    public Transform player; //set publicly. the players transform used to find its height
    public GameObject UICanvas; //set publicly. the canvas gameobject

    public float speed; //set publicly. the speed at which the controls changes the different settings

    // Update is called once per frame
    void Update()
    {
        if(player.position.y <= 20) 
        {
            UICanvas.transform.GetChild(1).gameObject.SetActive(false); //the text to tell the player they can open the menu
            UICanvas.transform.GetChild(2).gameObject.SetActive(true);//the text to tell the player they can't open the menu
        }
        else //if the player is below 20 units, the player is not able to use the controls below this point, and will tell the player using the UI
        {
            WorldControl();
            UICanvas.transform.GetChild(1).gameObject.SetActive(true);
            UICanvas.transform.GetChild(2).gameObject.SetActive(false);
        }

    }

    public void WorldControl()
    {
        if (Input.GetKey("a")) //WASD controls to change the offet of noise. GetKey so that you can hold it down.
        {
            _pn.offsetX += speed;
        }
        else if (Input.GetKey("d"))
        {
            _pn.offsetX -= speed;
        }

        if (Input.GetKey("w"))
        {
            _pn.offsetY += speed;
        }
        else if (Input.GetKey("s"))
        {
            _pn.offsetY -= speed;
        }

        if (Input.GetKey("r")) //R and F keys are meant to raise and lower the depth of the terrain noise
        {
            _pn.depth += speed;
        }
        else if (Input.GetKey("f"))
        {
            _pn.depth -= speed;
        }

        if (Input.GetKey("t")) //T and G keys are meant to raise and lower the scale of the terrain noise
        {
            _pn.scale += speed;
        }
        else if (Input.GetKey("g"))
        {
            _pn.scale -= speed;
        }
    }
}
