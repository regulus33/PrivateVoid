using System.Collections;
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
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2") || Input.GetKeyDown(KeyCode.M))
        {
            ToggleMenu();
            Assemble();
            //need to close item menu as well if its open when toggling
            //if its open we can just assume that its time to close here
            if(ItemMenu.instance.menuDisplay.activeInHierarchy)
            {
                ItemMenu.instance.ExitMenu();
            }
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
        PlayerController.instance.enabled = !PlayerController.instance.enabled ;
        shouldAssemble = !shouldAssemble;
        AudioManager.instance.PlayUI(1);
      
    }
    private void ResetFirstSelected()
    {

        //set should bleep to false just so this non human interaction doesnt make noise
        // optionsObjects.
 
        enableBleeps(false);
        EventSystem es = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        es.SetSelectedGameObject(null);
        es.SetSelectedGameObject(es.firstSelectedGameObject);
        enableBleeps(true);
        

    }

    private void enableBleeps(bool should)
    {
        int childrenCount =  optionsObjects.transform.childCount;
        for(int i = 0; i < childrenCount; i++)
        {
            optionsObjects.transform.GetChild(i).GetComponent<BleepOnSelect>().shouldBleep = should;  
        }
    }

    public void CloseMenu()
    {
        shouldAssemble = false;
        theMenu.SetActive(false);
        //todo get rid of the extra part here
        PlayerController.instance.enabled = true;
        PlayerController.instance.canMove = true;
    }

    public void Exit(){
        CloseMenu();
        ItemMenu.instance.ExitMenu();
    }


}
