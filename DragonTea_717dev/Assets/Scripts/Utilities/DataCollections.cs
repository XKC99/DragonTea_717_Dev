using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemDetails
{
    public int itemID;
    public string itemChineseName;
    public ItemName itemName;
    public Sprite itemicon;
    public Sprite itemOnWorldSprite;
    public string itemDescription;
    public int itemUseTimes;
    public bool canDropped;
    public bool canUsed;

}
