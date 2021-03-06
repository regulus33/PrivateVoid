﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int hp = 100;
    public int wisdom = 0;
    public int withdrawal = 0;
    public int will = 0;
    public int maxHp = 100;
    public int maxWithdraw = 100; 
    public int porkChopImpact = 20;
    public int intWithdrawalImpact = 10;
    public List<string> itemList = new List<string>();

    public int exp; 

    public static PlayerData instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addHp(int hpToAdd)
    {   if(hpToAdd + hp <= maxHp)
        {
            hp += hpToAdd;
        }
        
    }

    public void deferWithdrawal(int amount)
    {
        if((withdrawal - amount)> 0)
        {
            withdrawal -= amount;
        } else {
            withdrawal = 0;
        }
    }

    public void UseItem(string itemName)
    {
        if(itemName == "pork_chop")
        {
            addHp(porkChopImpact);
            RemoveItem(itemName);
        }
        if(itemName == "pill_bottle")
        {
            deferWithdrawal(intWithdrawalImpact);
            RemoveItem(itemName);
        }

    }

    public void RemoveItem(string itemName)
    {
        //it needs to clear here, I guess c# can't always be relied on to run synchronously
        //I was populating the menu out of sync with the player data even when having populateItems() run 
        //explicitly after calling  PlayerData.instance.UseItem(itemId);
        itemList.Remove(itemName);
        ItemMenu.instance.PopulateItems();
    }
    

    // public void SortItems() 
    // {
    //     bool itemAfterSpace = true;

    //     while(itemAfterSpace)
    //     {
    //         itemAfterSpace = false;
    //         //dont go outside arr range
    //         for (int i = 0; i < itemList.Count - 1; i++)
    //         {
    //             if(itemList[i] == "")
    //             {
    //                 //parallel these a
    //                 itemList[i] = itemList[i + 1];
    //                 itemList[i + 1] = "";
    //                  //parallel these b
    //                 // numberOfItems[i] = numberOfItems[i + 1];
    //                 // numberOfItems[i + 1] = 0;
    //                 //did we move an item? If yes, we need to keep the while loop
    //                 if(itemList[i] != "") 
    //                 {
    //                     itemAfterSpace = true;
    //                 }

    //             }
    //         }
    //     }
    // }

}
