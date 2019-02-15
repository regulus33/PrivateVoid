using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject cameraFocus;

    public bool focusTime = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveCamera();
    }


    public void moveCamera()
    {
        if(focusTime) {
            CameraController.instance.ChangeTarget(cameraFocus);  
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        focusTime = true;
    }

}
