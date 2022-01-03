using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ItemIcon : MonoBehaviour, ISelectHandler
{
    [SerializeField] private Item_SO item;
    private string itemName;
    private string itemDescription;
    private string itemAmount;

    private void Awake()
    {
        itemAmount = item.itemAmount.ToString();
        itemName = item.itemNameUI;
        itemDescription = item.description;
    }

    //Sends an event to the Item description
    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log(this.gameObject.name);
        InventoryEvent.currentInventoryEvent.ItemDescription(itemName, itemDescription);
    }
}
