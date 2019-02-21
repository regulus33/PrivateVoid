# At the World’s Edge - technical documentation

# Main components:

## CameraController 
  	Follows player character location, keeps character inside game map bounds and changes targets for cinematics. 

## UICanvas
   Has many subcomponents but we attach all the scripts to this object who will control menu, dialog etc. Many of UI Canvases sub scripts will stop player movement based on the SetActive(bool) status of a UICanvas > GameObject.  This var is set on the PlayerController by the GameManager. 


```c#
  //GameManager:30
        if (gameMenuOpen || dialogActive || fadingBetweenAreas || shopActive)
        {
            
            PlayerController.instance.canMove = false;
        }
        else
        {
            PlayerController.instance.canMove = true;
        }
```
 