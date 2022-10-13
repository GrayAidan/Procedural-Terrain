using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    /*
    Class that handles the rotation of the camera pertaining to the mouse.
    */

    public enum RotationAxes //changes the axis that the camera will rotate on
    {
        mouseXAndY = 0,
        mouseX = 1,
        mouseY = 2
    }
    

    public RotationAxes axes = RotationAxes.mouseXAndY; //publicly set
    public float sensitivityHor = 9.0f; //publicly set. the sensitivity of the mouse rotation
    public float sensitivityVert = 9.0f;
    public float minVert = -45.0f; //publicly set. the vertical rotation is clamped to a certain angle
    public float maxVert = 45.0f;
    private float _rotationX = 0f; //the rotation that is used to move the camera

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.mouseX) //If the enum is set, it choses which axis is able to rotate
        {
            //Hor Rotation
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }
        else if (axes == RotationAxes.mouseY)
        {
            //Ver Rotation
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

            transform.localEulerAngles = new Vector3(_rotationX, transform.localEulerAngles.y, 0);
        }
        else
        {
            //Ver & Hor Rotation
            float _rotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityHor;
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }

    }
}
