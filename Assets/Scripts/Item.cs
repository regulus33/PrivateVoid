using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemType;
    public bool used;
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

    void OntriggerEnter2D(Collider2D collision) 
    {
       if(Input.GetKeyUp("Fire1") && collision.tag == "Player")  
        PickupItem();
    }

    void OntriggerExit2D()
    {
        if(used)
        {
            gameObject.SetActive(false);
        }
    }

    public void PickupItem()
    {
       
        if(PlayerController.instance.AddItem(itemType))
        {
            used = true;
        }
        

    }
}
