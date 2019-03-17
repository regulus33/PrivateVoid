using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EssentialsLoader : MonoBehaviour
{
    public GameObject player;
    public GameObject audioManager;
    public GameObject eventSystem;
    public GameObject itemMenu;
    public GameObject playerMenu;
    public GameObject playerData; 
    public GameObject itemDialogBox; 

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerController.instance == null)
        {
            //what is this clone thing all about? 
            PlayerController clone = Instantiate(player).GetComponent<PlayerController>();
            PlayerController.instance = clone;
        }

        if(AudioManager.instance == null)
        {
            AudioManager.instance = Instantiate(audioManager).GetComponent<AudioManager>();            
        }

        if(ItemMenu.instance == null)
        {
            ItemMenu.instance  = Instantiate(itemMenu).GetComponent<ItemMenu>();
        }

        
        if(PlayerMenu.instance == null)
        {
            PlayerMenu.instance = Instantiate(playerMenu).GetComponent<PlayerMenu>();
        }

        if(!GameObject.FindWithTag("itemDialogBox"))
        {
           Instantiate(itemDialogBox);
        }

        if(!GameObject.Find("EventSystem"))
        {
           Instantiate(eventSystem);

        }

        // if(PlayerData.instance == null)
        // {
        //     PlayerData.instance = Instantiate(playerData).GetComponent<PlayerData>();
        //     Debug.LogError("[PlayerData] PlayerData destroyed somehow.");            
        // }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
