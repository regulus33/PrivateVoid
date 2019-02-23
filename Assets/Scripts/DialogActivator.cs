using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    public bool triggerDialog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ShouldShowDialog())
        {
            ActivateDialog();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
       Debug.Log(collision.tag);
       if(collision.tag =="Player")
       {
        triggerDialog = true;
       }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
       if(collision.tag =="Player")
       {
        triggerDialog = false;
       }
    }

    private bool ShouldShowDialog()
    {
        if (triggerDialog && Input.GetButtonUp("Fire1"))
        {
            return true;
        }
        return false;
    }

    private void ActivateDialog()
    {
        DialogManager.instance.dialogBox.SetActive(true);
        PlayerController.instance.canMove = false;
    }

}
