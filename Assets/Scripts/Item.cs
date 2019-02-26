using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemType;
    // Start is called before the first frame update
    public static Item instance;

    private bool canPickUp;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(canPickUp && Input.GetButtonDown("Fire1"))
        {
           ShowDialog();
        }
        if(InventoryManager.instance.dialogShown)
        {
            PickupItem();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag == "Player")
       {
           canPickUp = true;
       }
    }

    public void PickupItem()
    {
        Debug.Log("ran");
        if(PlayerController.instance.AddItem(itemType))
        {
            RemoveItem();
        }
    }

    public void ShowDialog()
    {
        InventoryManager.instance.dialogBox.SetActive(true);
        PlayerController.instance.canMove = false;
    }

    public void RemoveItem()
    {
        gameObject.SetActive(false);
    }
}
