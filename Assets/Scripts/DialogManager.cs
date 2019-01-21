using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text dialogText;
    public Text nameText;
    public GameObject dialogBox;
    public GameObject nameBox;

    public string[] dialogLines;

    public int currentLine;

    void Start()
    {
        dialogText.text = dialogLines[currentLine];   
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogBox.activeInHierarchy)
        {
            //is it being pressed
            if (Input.GetButtonUp("Fire1"))
            {
                currentLine++;

                dialogText.text = dialogLines[currentLine];
            }
        }

    }
}
