using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        
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
}
