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

        if(UIFade.instance == null)
        {
          UIFade.instance = Instantiate(UIScreen).GetComponent<UIFade>();
        }

        if(PlayerController.instance == null)
        {
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
            Instantiate(audioMan);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
