﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    public string transitionName;
    // Start is called before the first frame update
    void Start()
    {
        //if player's transition name happens to be this one    
        if (PlayerController.instance.areaTransitionName == transitionName)
        {
            PlayerController.instance.transform.position = transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
