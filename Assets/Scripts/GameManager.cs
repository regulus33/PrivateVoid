﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CharStats[] playerStats;

    public bool gameMenuOpen, dialogActive, fadingBetweenAreas;

    public string[] itemsHeld; //this and below reference eachother
    public int[] numberOfItems;
    public Item[] referenceItems; 
    public int currentGold;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
       //no empty spaces 
        SortItems();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameMenuOpen || dialogActive || fadingBetweenAreas)
        {
            PlayerController.instance.canMove = false;
        }
        else
        {
            PlayerController.instance.canMove = true;
        }

        if(Input.GetKeyDown(KeyCode.J))
        {
            AddItem("Health Potion");
            AddItem("Bronze Armor");

            RemoveItem("Mana Potion");
            RemoveItem("Silver Sword");
        }
    }

    public Item GetItemDetails(string itemToGrab) 
    {
        for(int i=0; i < referenceItems.Length; i++)
        {
            if(referenceItems[i].itemName.Trim() == itemToGrab.Trim()){
                return referenceItems[i];
            }
        }
        return null; 
    }

    public void SortItems() 
    {
        bool itemAfterSpace = true;

        while(itemAfterSpace)
        {
            itemAfterSpace = false;
            //dont go outside arr range
            for (int i = 0; i < itemsHeld.Length - 1; i++)
            {
                if(itemsHeld[i] == "")
                {
                    //parallel these a
                    itemsHeld[i] = itemsHeld[i + 1];
                    itemsHeld[i + 1] = "";
                     //parallel these b
                    numberOfItems[i] = numberOfItems[i + 1];
                    numberOfItems[i + 1] = 0;
                    //did we move an item? If yes, we need to keep the while loop
                    if(itemsHeld[i] != "") 
                    {
                        itemAfterSpace = true;
                    }

                }
            }
        }
    }

      public void AddItem(string itemToAdd) 
    {
        int newItemPosition = 0;
        bool foundSpace = false;

        for(int i = 0; i < itemsHeld.Length; i++)
        {
            if(itemsHeld[i] == "" || itemsHeld[i] == itemToAdd) 
            {
                newItemPosition  = i;
                i = itemsHeld.Length;
                foundSpace = true;
            }
        }

        if(foundSpace)
        {
            bool itemExists = false;
            for(int i = 0; i < referenceItems.Length; i++) 
            {
                if(referenceItems[i].itemName == itemToAdd)
                {
                    itemExists = true;

                    i = referenceItems.Length;
                }
            }
            if(itemExists)
            {
                itemsHeld[newItemPosition] = itemToAdd;
                numberOfItems[newItemPosition]++;
            } else {
                Debug.LogError(itemToAdd + "  Does not exist");
            }
        }
        //update the view and sort items
        GameMenu.instance.ShowItems();
    }

    public void RemoveItem(string itemToRemove)
    {
        bool foundItem = false;
        int itemPosition = 0;

        for(int i=0; i < itemsHeld.Length; i++) 
        {
            if(itemsHeld[i] == itemToRemove)
            {
                foundItem = true;
                itemPosition = i;
                //found item break loop
                i = itemsHeld.Length;

            }

            if(foundItem)
            {
              numberOfItems[itemPosition]--;
              if(numberOfItems[itemPosition] <= 0)
              {
                itemsHeld[itemPosition] = "";
              }
               GameMenu.instance.ShowItems();
            } else {
                Debug.LogError("coulnt find item: " + itemToRemove);
            }

        }
    }
}
