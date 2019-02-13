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
        if(!initialCheckDone)
        {
            initialCheckDone = true;

            CheckCompletion();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckCompletion()
    {
        if(QuestManager.instance.CheckIfComplete(questToCheck))
        {
            objectToActivate.SetActive(activeIfComplete);
        }
    }

}
