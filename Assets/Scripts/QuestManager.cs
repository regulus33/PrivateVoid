﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public string[] questMarkerNames;
    public bool[] questMarkersComplete;

    public static QuestManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        questMarkersComplete = new bool[questMarkerNames.Length];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log(CheckIfComplete("quest test"));
            MarkQuestComplete("quest test");
            MarkQuestIncomplete("fight the demon");
        }

        if(Input.GetKeyDown(KeyCode.O))
        {   
            Debug.Log("o");
            SaveQuestData();
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            LoadQuestData();
        }
    }

    public int GetQuestNumber(string questToFind)
    {
        for(int i=0; i < questMarkerNames.Length; i++ )
        {
            if(questMarkerNames[i] == questToFind)
            {
                return i ;
            }
        }
        Debug.LogError("Quest: " + questToFind + " does not exist");
        return 0;
    }

    public bool CheckIfComplete(string questToCheck)
    {   //if zero, there is no quest with this name
        if(GetQuestNumber(questToCheck) > 0)
        {
            return questMarkersComplete[GetQuestNumber(questToCheck)];
        }
        return false;
    }

    public void MarkQuestComplete(string questToMark)
    {
        questMarkersComplete[GetQuestNumber(questToMark)] = true;
    }

    public void MarkQuestIncomplete(string questToMark)
    {
        questMarkersComplete[GetQuestNumber(questToMark)] = false; 
    }

    public void UpdateLocalQuestObjects()
    {
        //find all items with quest object script attached to them 
        QuestObjectsActivator [] questObjects = FindObjectsOfType<QuestObjectsActivator>();

        if(questObjects.Length > 0)
        {
            for(int i = 0; i < questObjects.Length; i++)
            {
                questObjects[i].CheckCompletion();
            }
        }
    }

    public void SaveQuestData()
    {
      Debug.Log("save");
      for(int i=0; i < questMarkerNames.Length; i++)
      {
          if(questMarkersComplete[i] == true)
          {
              PlayerPrefs.SetInt("QuestMarker_" + questMarkerNames[i], 1);
          } else {
              PlayerPrefs.SetInt("QuestMarker_" + questMarkerNames[i], 0);
          }
      }
    }

    public void LoadQuestData()
    {
        Debug.Log("Load");
        for(int i=0; i < questMarkerNames.Length; i++)
        {
            int valueToSet = 0;
            if(PlayerPrefs.HasKey("QuestMarker_" + questMarkerNames[i]))
            {
                valueToSet = PlayerPrefs.GetInt("QuestMarker_" + questMarkerNames[i]);
            }

            if(valueToSet == 0)
            {
                questMarkersComplete[i] = false;
            } else 
            {
                questMarkersComplete[i] = true;
            }

        }
    }
}
