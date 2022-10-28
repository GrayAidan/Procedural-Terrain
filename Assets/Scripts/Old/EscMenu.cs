using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscMenu : MonoBehaviour
{
    /*
    Handles the opening and closing of the escape menu, which shows the world controls
    */

    private bool menuOpen; //Value that determines if the menus is open or not. also used to set the menu as "active"

    private Text escapeMenuText; //The text component that this object is attached to.

    private void Start()
    {
        escapeMenuText = GetComponent<Text>(); //gets the text component
        SetActivity(); //makes sure the menu starts off as the players state
    }

    private void OnDisable()
    {
        menuOpen = false; //closes the menu every time the player goes out of the editable zone in the world. this gameobject goes inactive.
    }

    // Update is called once per frame
    void Update()
    {
        if (!menuOpen)
        {
            escapeMenuText.text = "(Esc) Show World Controls"; //when the menu is closed, this text is displayed at the top
        }
        if (menuOpen)
        {
            escapeMenuText.text = "(Esc) Close"; //when the menu is open, this text is displayed at the top
        }

        EscapeCheck(); //this is here to constantly check if escape is pushed down
    }

    public void SetActivity() //called from Update() through EscapeCheck(). this handles setting the items in the menu to whatever the current activity is dependant on the bool
    {
        for(int i = 0; i < transform.childCount; i++) //for every child attached to this gameobject
        {
            transform.GetChild(i).gameObject.SetActive(menuOpen); //set its activity according to the current menuOpen bool
        }
    }

    public void EscapeCheck() //called from Update(). Checks if the escape button is pushed down, as well as setting the activity.
    {
        if (Input.GetKeyDown("escape")) 
        {
            menuOpen = !menuOpen; //if the escape key is pressed, set the menuOpen bool to its opposite.
        }

        SetActivity();
    }
}
