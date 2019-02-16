using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObjectsActivator : MonoBehaviour
{
    public GameObject objectToActivate;

    public string questToCheck;

    public bool activeIfComplete;

    private bool initialCheckDone;
    // Start is called before the fi    rst frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        if(!initialCheckDone)
        {   //WTF is this here???? figure it out!
            // initialCheckDone = true;

            CheckCompletion();
        }
    }

    public void CheckCompletion()
    {
        if(QuestManager.instance.CheckIfComplete(questToCheck))
        {
            objectToActivate.SetActive(activeIfComplete);
        }
    }

}
