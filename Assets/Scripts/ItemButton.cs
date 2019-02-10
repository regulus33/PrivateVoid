﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemButton : MonoBehaviour
{
    public Image buttonImage;
    public Text amountText;
    public int buttonValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Press()
    {   
        Debug.LogError("Pressed!");
        //is clicked button containing equipped based on index comparison
        if(GameManager.instance.itemsHeld[buttonValue] != "")
        {
             GameMenu.instance.SelectItem(GameManager.instance.GetItemDetails(GameManager.instance.itemsHeld[buttonValue]));
        }
    }
}
