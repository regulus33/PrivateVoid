using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupItem : MonoBehaviour
{
    public GameObject itemDialog;

    public Text dialogText;
    public GameObject dialogBox;

    public bool timeToGetDialogGoing;

    public float letterPaused = 0.1f;

    public bool typing = false;

    public string[] dialogLines;

    public int currentLine = 0;

    public bool used = false;

    public Sprite openedSprite; 

    public bool canPickUp = false;

    // Start is called before the first frame update
    void Start()
    {
        dialogText.text = dialogLines[currentLine];  
    }

    // Update is called once per frame
    void Update()
    {
    if(!used && canPickUp)
    { 
        if(Input.GetButtonDown("Fire1") && PlayerController.instance.canMove)
        {
          if(AcceptItem())
          { 
              dialogBox.SetActive(true);
              timeToGetDialogGoing = true; 
              
          } else {

          }
        }
        if(timeToGetDialogGoing)
        {
            Debug.Log("time to get dialog going ran");
            TickThroughDialog();
        }
      }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canPickUp = true;
        }
    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canPickUp = true;
        }   
    }

    public bool AcceptItem()
    {
     
        if(PlayerController.instance.CanAddItem(GetComponent<Item>().itemType))
        {
            return true;
        } else {
            return false;
        } 

    }

     public IEnumerator TypeText(string message)
    {
        typing = true;
        // wipe text blank before next print
        dialogText.text = "";
        //Split each char into a char array
		foreach (char letter in message.ToCharArray()) 
		{
            AudioManager.instance.PlayCoins(0);
			//Add 1 letter each
			dialogText.text += letter;
			yield return 0;
			yield return new WaitForSeconds(letterPaused);
		}
         typing = false;
        
	}

     public void TickThroughDialog()
    {
        Debug.Log("TickThroughDialog");  
        //is user clicking? and no animation is happening and dialog box is active
            Debug.Log("" + (Input.GetButtonUp("Fire1")));
         if (!typing && dialogBox.activeInHierarchy && (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.M)))
         {
           Debug.Log("THE END OF DIALOG PART IS RUNNING");    
            // We are at last index, set box false
            if (currentLine >= dialogLines.Length)
            {
                //open present, make bleep sound and close dialog boxxx
                dialogBox.SetActive(false);
                PlayerController.instance.canMove = true;
                AudioManager.instance.PlayUI(0);
                gameObject.GetComponent<SpriteRenderer>().sprite = openedSprite;
                PlayerController.instance.AddItem(GetComponent<Item>().itemType);
                currentLine = 0;
                used = true;

            }
            // we are still deep in the dialog loop, check if name and type lines!
            else
            {
                Debug.Log("THE COROUTINE PART IS RUNNING");               // dialogText.text = dialogLines[currentLine];
                StartCoroutine (TypeText(dialogLines[currentLine]));
            }

             currentLine++;
        }
    }
}