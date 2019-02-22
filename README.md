# RPGZ


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

