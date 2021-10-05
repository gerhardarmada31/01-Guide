using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatSlot : MonoBehaviour
{
    public Equipment_SO hatItem;
    private GameObject previousHat;
    private GameObject currentHat;
    private bool hasHat = false;


    // Start is called before the first frame update
    void Start()
    {
        if (hatItem != null)
        {
            Instantiate(hatItem.EquipPrefab, this.transform);

        }
        InventoryEvent.currentInventoryEvent.onEquipPlayer += EquipHat;
    }

    private void EquipHat(Equipment_SO equipSO, bool _hasHat)
    {
        if (hasHat == false)
        {
            hasHat = _hasHat;
            hatItem = equipSO;
            currentHat = Instantiate(equipSO.EquipPrefab, this.transform);
        }
        else if (hatItem == equipSO)
        {
            Destroy(currentHat);
            hasHat = false;
        }


        if (hatItem != equipSO)
        {
            Destroy(currentHat);
            currentHat = Instantiate(equipSO.EquipPrefab, this.transform);
        }
        // else if()
        // if the pastHat is not the same destroy the past hat and equip the new one

    }

    // public void EquipHat()
    // {
    //     Instantiate(hatItem.EquipPrefab, this.transform);
    // }
}
