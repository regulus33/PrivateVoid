using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private bool canPickUp;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        if(canPickUp && Input.GetButtonDown("Fire1") && PlayerController.instance.canMove)
        {
          AcceptItem();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canPickUp = true;
        }
    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canPickUp = false;
        }
    }

    public void AcceptItem()
    {
        PlayerController.instance.AddItem(GetComponent<Item>().itemType);
        Destroy(gameObject);

    }
}