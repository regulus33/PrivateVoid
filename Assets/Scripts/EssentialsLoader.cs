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

        if(!GameObject.Find("EventSystem"))
        {
           Instantiate(eventSystem);

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFirstSelectedOnEventSystem(GameObject setter)
    {
        EventSystem es = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        //clear it before it does anything 
        es.SetSelectedGameObject(null);
        es.SetSelectedGameObject(setter);  
    }
}
