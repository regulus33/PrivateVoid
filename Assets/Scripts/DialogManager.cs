using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public float letterPaused = 0.01f;
    public Text dialogText;
    public Text nameText;
    public GameObject dialogBox;
    public string[] dialogLines;

    public int currentLine;
    public bool justStarted;

    public static DialogManager instance;


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
            if (Input.GetButtonUp("Fire1"))
            {
                if (!justStarted)
                {

                    currentLine++;
                    // SPEACH IS ENDING 
                    if (currentLine >= dialogLines.Length)
                    {
                        dialogBox.SetActive(false);

                    }
                    else
                    {
                        CheckIfName();
                        // dialogText.text = dialogLines[currentLine];
                        StartCoroutine (TypeText(dialogLines[currentLine]));
                    }

                }
                else
                {
                    justStarted = false;
                }
            }
        }

    }

    public void ShowDialog(string[] newLines, bool isPerson)
    {
        dialogLines = newLines;

        currentLine = 0;

        CheckIfName();

        dialogText.text = dialogLines[currentLine];
        dialogBox.SetActive(true);

        justStarted = true;
        //only make little box for people active when person is true(youre talking and not inspecting)
    }

    public void CheckIfName()
    {   //syntax for my name switching
        Debug.Log(dialogLines[currentLine].StartsWith("n-"));
        Debug.Log(dialogLines[currentLine]);
        if (dialogLines[currentLine].StartsWith("n-"))
        {   //this line is not dialog, its the name
            nameText.text = dialogLines[currentLine].Replace("n-","");
            currentLine++;
        }
    }
    //animation
    public IEnumerator TypeText(string message)
    {
        // wipe text blank before next print
        dialogText.text = "";
        //Split each char into a char array
		foreach (char letter in message.ToCharArray()) 
		{
			//Add 1 letter each
			dialogText.text += letter;
			yield return 0;
			yield return new WaitForSeconds(letterPaused);
		}
        
	}

    

}
