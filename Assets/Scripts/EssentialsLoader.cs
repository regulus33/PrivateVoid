using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    public GameObject UIScreen;
    public GameObject player;
    public GameObject gameMan;
    public GameObject playerLoadStart;
    public GameObject questMan;
    public GameObject audioMan;
    // Start is called before the first frame update
    void Start()
    {
        //still no idea what this does
        if(UIFade.instance == null)
        {
        //seems like it has something to do with fading lol
          UIFade.instance = Instantiate(UIScreen).GetComponent<UIFade>();
        }
        
        if(PlayerController.instance == null)
        {
            //what is this clone thing all about? 
            PlayerController clone = Instantiate(player).GetComponent<PlayerController>();
            PlayerController.instance = clone;
            PlayerController.instance.transform.position = new Vector3(playerLoadStart.transform.position.y, playerLoadStart.transform.position.x, 0f);
        }

        if(GameManager.instance == null)
        {
            Instantiate(gameMan);
        }

        if(QuestManager.instance == null)
        {
            Instantiate(questMan);
        }
        
        if(AudioManager.instance == null)
        {
            AudioManager clone = Instantiate(audioMan).GetComponent<AudioManager>();
            AudioManager.instance = clone;

        }

        if(GameMenu.instance == null)
        {
             GameMenu.instance = Instantiate(UIScreen).GetComponent<GameMenu>();
        }

        if(DialogManager.instance == null)
        {
             DialogManager.instance = Instantiate(UIScreen).GetComponent<DialogManager>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
