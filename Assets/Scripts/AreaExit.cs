using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    public string areaToLoad;

    public string areaTransitionName;
    //entry point, set to whatever current value of entrance is here, this logically puts us into the next world. We leave to where we entered from.
    public AreaEntrance theEntrance;
    private bool shouldLoadAfterFade;

    public float waitToLoad = 1f;

    // Start is called before the first frame update
    void Start()
    {
        theEntrance.transitionName = areaTransitionName;
    }

    // Update is called once per frame
    void Update()
    {
         //makes sure area loads after black fade
        if (shouldLoadAfterFade)
        {
            waitToLoad -= Time.deltaTime;
            if(waitToLoad <= 0f)
            {
                shouldLoadAfterFade = false;
                SceneManager.LoadScene(areaToLoad);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag == "Player") 
       {
           //SceneManager.LoadScene(areaToLoad);
            shouldLoadAfterFade = true;
            UIFade.instance.FadeToBlack();
       }
        //because playercontroller is set to public static there can only ever be one instance, handy for accessing globally
        //this is for entering and exiting scenes.
        PlayerController.instance.areaTransitionName = areaTransitionName;

    }
}
