using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public float letterPaused = 0.01f;
    public Text itemText;
    public GameObject dialogBox;
    public string[] dialogLines;
    public int bleepSound = 2;
    private int currentLine = 0;
    public string itemDisplayName;
    public static InventoryManager instance;
    //dont let user input while typing.
    public bool itemCanAdd;
    private bool shown;


    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
    
        if(shown && (Input.GetButtonDown("Click1") || Input.GetKeyDown(KeyCode.N)))
        {
            ExitMenu();
        }
    }
  


    public void SwitchOn()
    {
        dialogBox.SetActive(true);
        shown = true;
    }

    public void AcceptItem()
    {
        itemText.text = "Added " + itemDisplayName;
    }

    public void RejectItem()
    {
        itemText.text = "Its a " + itemDisplayName +". Cant add, get rid of some stuff if you wan't it that bad.";
    }

    public void ExitMenu()
    {
        dialogBox.SetActive(false);
    }

    

}
