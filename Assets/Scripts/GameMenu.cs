using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public GameObject theMenu;
    //for switching 
    public GameObject[] windows;

    private CharStats[] playerStats;
    public Text[] nameText, hpText, mpText, levlText, expText;
    public Slider[] expSlider; 
    public Image[] charImage;
    public GameObject[] charStatHolder;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (theMenu.activeInHierarchy)
            {
                //theMenu.SetActive(false);
                //GameManager.instance.gameMenuOpen = false; 
                CloseMenu();

            }
            else
            {
                theMenu.SetActive(true);
                UpdateMainStats();
                GameManager.instance.gameMenuOpen = true;
            }
        }
    }

    public void UpdateMainStats()
    {

        playerStats = GameManager.instance.playerStats; 
        for(int i = 0; i < playerStats.Length; i++) 
        {
            //if the player object these stats belong to is actively in the game 
            if(playerStats[i].gameObject.activeInHierarchy)
            {
                
                //get his stat UI container activated
                charStatHolder[i].SetActive(true);
                //hook up player stats with UI display
                nameText[i].text = playerStats[i].charName;
                hpText[i].text = "HP: " + playerStats[i].currentHP + "/" + playerStats[i].maxHP;
                mpText[i].text = "MP: " + playerStats[i].currentMP + "/" + playerStats[i].maxMP;
                levlText[i].text = "MP: " + playerStats[i].playerLevel;
                expText[i].text = "" + playerStats[i].currentEXP + "/" + playerStats[i].expToNextLevel[playerStats[i].playerLevel];
                expSlider[i].maxValue = playerStats[i].expToNextLevel[playerStats[i].playerLevel];
                expSlider[i].value = playerStats[i].currentEXP;
                charImage[i].sprite = playerStats[i].charImage;

            } else {

                charStatHolder[i].SetActive(false);

            }
        }
    }

    public void ToggleWindow(int windowNumber)
    {
        Debug.Log("touched");
        for(int i = 0; i < windows.Length; i++)
        {
            if(i == windowNumber)
            {
                windows[i].SetActive(!windows[i].activeInHierarchy);
            } else 
            {
                windows[i].SetActive(false);
            }
        }
    }

    public void CloseMenu()
    {
        //reset window state
        for(int i = 0; i < windows.Length; i++)
        {
            windows[i].SetActive(false);
        }

        theMenu.SetActive(false);
        GameManager.instance.gameMenuOpen = false;
    }
}
