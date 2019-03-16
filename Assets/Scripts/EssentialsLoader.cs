using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    public GameObject player;
    public GameObject audioManager;
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


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
