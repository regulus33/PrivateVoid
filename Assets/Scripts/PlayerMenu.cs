﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMenu : MonoBehaviour
{
    public Text hpText;
    public Text wisdomText;
    public Text willText;
    public Text withdrawText;

    public GameObject optionsObjects;
    public GameObject theMenu;

    public bool shouldAssemble = false;
    public static PlayerMenu instance;

    // public GameObject[] options;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        ExtractUIOptions();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2") || Input.GetKeyDown(KeyCode.M))
        {
            ToggleMenu();
            Assemble();
        }
    }

    public void updateHP()
    {
        
        hpText.text = PlayerData.instance.hp.ToString(); 
    }

    public void updateWisdom()
    {
        wisdomText.text = PlayerData.instance.wisdom.ToString(); 
    }

    public void updateWill()
    {
        willText.text = PlayerData.instance.will.ToString(); 
    }

    public void updateWithdrawal()
    {
        withdrawText.text = PlayerData.instance.withdrawal.ToString(); 
    }


    public void Assemble()
    {
        if(shouldAssemble)
        {
            updateHP();
            updateWill();
            updateWithdrawal();
            updateWisdom();
            PlayerController.instance.canMove = false;
        }
        theMenu.SetActive(shouldAssemble);
        //THE FIRST SELECTED BUTTON NEEDS TO RESET BECAUSE ITEM IS INACTIVE BEFORE.
        ResetFirstSelected();
        if(!shouldAssemble){
            PlayerController.instance.canMove = true;
        }
    }

    public void ToggleMenu()
    {
        Debug.Log("toggleing");
        shouldAssemble = !shouldAssemble;
    }

    public GameObject[,] ExtractUIOptions()
    {
        int childCount = optionsObjects.transform.childCount;
        GameObject[] optionsChildren = new GameObject[childCount];
        for(int i = 0; i < childCount; i++)
        {
            optionsChildren[i] = optionsObjects.transform.GetChild(i).gameObject;
        }
        GameObject[,] matrixItems = new GameObject[childCount,2];
         matrixItems[0,0] = optionsChildren[0]; 
         matrixItems[0,1] = optionsChildren[1]; 
         matrixItems[1,0] = optionsChildren[2]; 
         matrixItems[1,1] = optionsChildren[3]; 

        return matrixItems;
    }


    private void ResetFirstSelected()
    {
        EventSystem es = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        es.SetSelectedGameObject(null);
        es.SetSelectedGameObject(es.firstSelectedGameObject);
    }

    public void CloseMenu()
    {
        shouldAssemble = false;
        theMenu.SetActive(false);
        PlayerController.instance.canMove = true;
    }

    public void Exit(){
        CloseMenu();
        ItemMenu.instance.ShowMenu();
    }
   



}
