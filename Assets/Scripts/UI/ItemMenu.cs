using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenu : MonoBehaviour
{
    //this is not data this is a socket to put the data in, we will loop through premade ui elements that child this gameobject and populate them with item strings.
    public GameObject items;

    public GameObject menuDisplay;

    public static ItemMenu instance;

    private bool shouldShow = false;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject[] ExtractUIItems()
    {
        int childCount = items.transform.childCount;
        GameObject[] itemsChildren = new GameObject[childCount];
        for(int i = 0; i < childCount; i++)
        {
            itemsChildren[i] = items.transform.GetChild(i).gameObject;
        }
        
        return itemsChildren;
    }
    
    public void ShowMenu()
    {
            shouldShow = !shouldShow;
            menuDisplay.SetActive(shouldShow);
            PopulateItems();
    }

    public void PopulateItems()
    {
        
        ClearItemsFromPreviousState();
        GameObject[] itemsToModify = ExtractUIItems();   
        for(int i=0; i < PlayerData.instance.itemList.Count; i++)
        {
            itemsToModify[i].GetComponent<UnityEngine.UI.Text>().text = DisplayText(PlayerData.instance.itemList[i]);
        }
    }

    public void ClearItemsFromPreviousState()
    {
        GameObject[] itemsToModify = ExtractUIItems();   
        for(int i=0; i < itemsToModify.Length; i++)
        {
            itemsToModify[i].GetComponent<UnityEngine.UI.Text>().text = "";
        }

    }

    public string DisplayText(string itemName)
    {
        return itemName.Replace("_", " ");
    }

    public void Press(GameObject item)
    {
     string text = item.GetComponent<UnityEngine.UI.Text>().text;
     string itemId = MakeComputerFormat(text);
     PlayerData.instance.UseItem(itemId);
    //  RemoveItemFromMenu(item);
     //update menu with new stats after consuming the item.
     PlayerMenu.instance.Assemble();
     //repopulate items array so you dont have random blank spaces

    }

    public void ExitMenu()
    {
        shouldShow = false;
        menuDisplay.SetActive(false);

    }

    // public void RemoveItemFromMenu(GameObject item){
    //     item.GetComponent<UnityEngine.UI.Text>().text = "";
    // }

    public string MakeComputerFormat(string name)
    {
        return name.Replace(" ","_");
    }
   
}
