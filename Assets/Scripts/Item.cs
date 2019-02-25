using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemType = "thing";
    public bool used;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OntriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "Player")
        {
            if(PlayerController.instance.AddItem(itemType));
            {
                used = true;
            }
        }
    }

    void OntriggerExit2D()
    {
        if(used)
        {
            gameObject.SetActive(false);
        }
    }

    public int JustForTest(int argument)
    {
        return argument * 3;
    }
}
