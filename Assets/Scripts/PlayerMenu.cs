using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMenu : MonoBehaviour
{
    public Text hpText;
    public Text wisdomText;
    public Text willText;
    public Text withdrawText;

    public GameObject theMenu;

    public bool shouldAssemble = false;
    public static PlayerMenu instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
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
        }
        theMenu.SetActive(shouldAssemble);
    }

    public void ToggleMenu()
    {
        Debug.Log("toggleing");
        shouldAssemble = !shouldAssemble;
    }


}
