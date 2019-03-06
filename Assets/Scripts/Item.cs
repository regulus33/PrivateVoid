using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemType;
    // Start is called before the first frame update
    public static Item instance;


    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ShowDialog()
    {
        InventoryManager.instance.dialogBox.SetActive(true);
        PlayerController.instance.canMove = false;
    }

}
