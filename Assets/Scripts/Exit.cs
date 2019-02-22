using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public string nextArea;

    public string nextPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            WarpIfExit();
        }
    }

    private void WarpIfExit()
    {
        SceneManager.LoadScene(nextArea);
        SetPlayerPosition();
    }

    private void SetPlayerPosition()
    {
      PlayerController.instance.nextPosition = nextPosition;
    }

}
