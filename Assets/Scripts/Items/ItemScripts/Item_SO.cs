using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    KEY,
    EQUIPMENT,
    DEFAULT
}

public abstract class Item_SO : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    
    [TextArea(15,20)]
    public string description;

}