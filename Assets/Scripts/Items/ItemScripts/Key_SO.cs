using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New KeyItem", menuName ="Inventory/Items/Key")]
public class Key_SO : Item_SO
{
    private void Awake()
    {
        type = ItemType.KEY;
    }
}
