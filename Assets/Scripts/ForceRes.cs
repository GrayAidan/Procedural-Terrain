using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceRes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
