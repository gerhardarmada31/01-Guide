using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{

    //Equipment SO

    //Clicked send an event on the hatSlot to equip the object
    //Event needs to have a bool and Equipment SO.

    [SerializeField] private Equipment_SO equipItem;


    public void OnClickEquip()
    {
        InventoryEvent.currentInventoryEvent.EquipItemPlayer(equipItem,true);
    }

}
