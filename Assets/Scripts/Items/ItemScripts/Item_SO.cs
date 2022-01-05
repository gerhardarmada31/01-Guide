using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    KEY,
    EQUIPMENT,
    DEFAULT,
    SPIRIT
}

public abstract class Item_SO : ScriptableObject
{
    public GameObject uiPrefab;
    public ItemType type;
    public string itemNameUI;
    public string itemID;
    public bool itemPickedUp;
    public int itemAmount = 1;
    [TextArea(15, 20)]
    public string description;

}