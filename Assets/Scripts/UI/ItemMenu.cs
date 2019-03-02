using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenu : MonoBehaviour
{
    //this is not data this is a socket to put the data in, we will loop through premade ui elements that child this gameobject and populate them with item strings.
    public GameObject items;

    public static ItemMenu instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        PopulateItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject[] PopulateItems()
    {
        int childCount = items.transform.childCount;
        GameObject[] itemsChildren = new GameObject[childCount];
        for(int i = 0; i < childCount; i++)
        {
            itemsChildren[i] = items.transform.GetChild(i).gameObject;
        }
        
        return itemsChildren;
    }
}

            // itemToModify.GetComponent<UnityEngine.UI.Text>().text =  