using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerController.instance == null)
        {
            //what is this clone thing all about? 
            PlayerController clone = Instantiate(player).GetComponent<PlayerController>();
            PlayerController.instance = clone;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
