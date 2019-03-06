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
    public bool dialogShown;
    public static InventoryManager instance;
    //dont let user input while typing.
    private bool typing = false;


    void Start()
    {
        instance = this;
        itemText.text = dialogLines[currentLine];   
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogBox.activeInHierarchy)
        {
           tickThroughDialog();
        }

    }
  
    //animation
    public IEnumerator TypeText(string message)
    {
        typing = true;
        // wipe text blank before next print
        itemText.text = "";
        //Split each char into a char array
		foreach (char letter in message.ToCharArray()) 
		{
            AudioManager.instance.PlayVox(bleepSound);
			//Add 1 letter each
			itemText.text += letter;
			yield return 0;
			yield return new WaitForSeconds(letterPaused);
		}
         typing = false;
        
	}

    private void tickThroughDialog()
    {
        //is user clicking? and no animation is happening and dialog box is active
         if (Input.GetButtonUp("Fire1") && !typing && dialogBox.activeInHierarchy)
         {
            // We are at last index, set box false
            if (currentLine >= dialogLines.Length)
            {
                dialogBox.SetActive(false);
                PlayerController.instance.canMove = true;
                dialogBox.SetActive(false);
                dialogShown = true;
            }
            // we are still deep in the dialog loop, check if name and type lines!
            else
            {
                // itemText.text = dialogLines[currentLine];
                StartCoroutine (TypeText(dialogLines[currentLine]));
            }

             currentLine++;
        }
    }

    

}
