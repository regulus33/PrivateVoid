 <img src="./project-logo.png" width="604"/>

#Z-DOCS 

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

```c#
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

## Items menu
* Don't forget to assign the UI panel child of ItemMenu to the script!!!

For now Items menu is a UI object with a child GameObject with panels and buttons etc. To interact with the items menu use right click or tap "M" on keyboard. 

The main thing here to document is that items takes a 
```c#
public GameObject items;
```
which is actually just a refualr `GameObject` whose children are `Text` objects. This method 

```c#

    public GameObject[] ExtractUIItems()
    {
        int childCount = items.transform.childCount;
        GameObject[] itemsChildren = new GameObject[childCount];
        for(int i = 0; i < childCount; i++)
        {
            itemsChildren[i] = items.transform.GetChild(i).gameObject;
        }
        
        return itemsChildren;
    }
 ```
 
 and this method 
 
 ```c#
   public void PopulateItems()
    {
        GameObject[] itemsToModify = ExtractUIItems();   
        for(int i=0; i < PlayerData.instance.itemList.Count; i++)
        {
            itemsToModify[i].GetComponent<UnityEngine.UI.Text>().text = PlayerData.instance.itemList[i];
        }
    }
```

will 
a) drill down into the children of the items gameobject and gran the Text items we need to inject text into and
b) pull data from the PlayerData object and inject that into those Item Text boys. 


## Items! Adding and Using etc. 
This one is complicated and can certainly be improved but here's what we have so far.
