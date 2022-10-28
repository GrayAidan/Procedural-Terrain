using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCheck : MonoBehaviour
{
    /*
    Sets the grounded state if the grounded trigger is touching a collision box tagged or labeled as ground
    */
    
    public bool grounded; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            grounded = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            grounded = false;
            
        }
    }
}
