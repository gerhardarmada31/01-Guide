using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EquipmentObject", menuName = "Inventory/Items/Equipment")]
public class Equipment_SO : Item_SO
{
    // public int plusHP;
    // public int plusAtk;
    // public int plusSP;
    // public int plusSPRate;

    public GameObject EquipPrefab;

    public void Awake()
    {
        type = ItemType.EQUIPMENT;
    }
}
