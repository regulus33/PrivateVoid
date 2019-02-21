using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    public string transitionName;
    // Start is called before the first frame update
    void Start()
    {
        //If I am the area entrance object for x area name (there will often be several), then warp player to here
        if (PlayerController.instance.areaTransitionName == transitionName)
        {
            PlayerController.instance.transform.position = transform.position;
        }

        
        UIFade.instance.FadeFromBlack();
        GameManager.instance.fadingBetweenAreas = false;

    }

    // Update is called once per frame
    void Update()
    {
         
    }
}
