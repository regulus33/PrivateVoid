

<img src="./project-logo.png" width="404" height="200"/>

# A 2d rpg about our inner world. The Private Void

## Dev Docs:

## Traveling between scenes:

Each scene has at least one of: 
* North 
* West 
* South 
* East 

Tied to an entrance. 

Exit objects have 2 public strings:

* nextArea: Scene to Load
* nextPosition: Which entrance to Load


nextArea is passed to Unity Scene Manager and nextPosition is stuck to PlayerController.instance and retrieved by the area recieving them.

```
  private void SetPlayerPosition()
  {
    PlayerController.instance.areaTransitionName = nextPosition;
  }
```

## Dialog Management

Dialog manager scripts are attached to the objects they are meant to provide speach for. Two components:

* Dialog Manager - Holds the actual text state and displays / animates it on the gameobjects (text box and name) that you provide as public variables.
* Dialog Activator - Simpley add this on top of Dialog Manager to trigger an activation of the DialogBox on the DialogManager which sets off the whole click loop of dialog. Listens for on trigger enter. 

To display Names in Dialog Manger, use 'n-'
