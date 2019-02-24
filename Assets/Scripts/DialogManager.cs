using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public float letterPaused = 0.01f;
    public Text dialogText;
    public Text nameText;
    public bool isPerson;
    public GameObject dialogBox;
    public string[] dialogLines;
    public int voiceSound = 0;
    private int currentLine = 0;
    public bool justStarted;

    public static DialogManager instance;
    //dont let user input while typing.
    private bool typing = false;


    void Start()
    {
        instance = this;
        dialogText.text = dialogLines[currentLine];   
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogBox.activeInHierarchy)
        {
           tickThroughDialog();
        }

    }

    public void CheckIfName()
    {   //syntax for my name switching
        if (dialogLines[currentLine].StartsWith("n-"))
        {   //this line is not dialog, its the name
            nameText.text = dialogLines[currentLine].Replace("n-","");
            currentLine++;
        }
    }
    //animation
    public IEnumerator TypeText(string message)
    {
        typing = true;
        // wipe text blank before next print
        dialogText.text = "";
        //Split each char into a char array
		foreach (char letter in message.ToCharArray()) 
		{
            AudioManager.instance.PlayVox(voiceSound);
			//Add 1 letter each
			dialogText.text += letter;
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
                currentLine = 0;

            }
            // we are still deep in the dialog loop, check if name and type lines!
            else
            {
                CheckIfName();
                // dialogText.text = dialogLines[currentLine];
                StartCoroutine (TypeText(dialogLines[currentLine]));
            }

             currentLine++;
        }
    }

    

}
