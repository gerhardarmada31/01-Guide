using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class ItemDescription : MonoBehaviour
{
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text itemDescription;

    private void OnEnable()
    {
        InventoryEvent.currentInventoryEvent.onItemDescription += ItemUpdateText;
    }

    //Event that came from ItemIcon the updates the name and description
    private void ItemUpdateText(string _name, string _description)
    {
        itemName.SetText(_name);
        itemDescription.SetText(_description);
    }

    private void OnDisable()
    {
        InventoryEvent.currentInventoryEvent.onItemDescription -= ItemUpdateText;

    }
}
