using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;


[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Inventory")]
public class InventorySO : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    private ItemType spiritType = ItemType.SPIRIT;



    public void AddItem(Item_SO _item, int _amount)
    {
        bool hasItem = false;

        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            //CALL THE EVENT FOR THE NOTIFICATION ITEM HERE
            //MAKE a boolean inside ITEM_SO to check if item has already picked.

            if (!_item.itemPickedUp)
            {
                InventoryEvent.currentInventoryEvent.ItemNotify(_item.itemNameUI);
                _item.itemPickedUp = true;
            }

            //Check if the Item is spirit type, then send an event.
            if (_item.type == spiritType)
            {
                Debug.Log("This is a spiritType");
                InventoryEvent.currentInventoryEvent.PlayerSPUpgrade(_item.itemAmount);
            }
            Container.Add(new InventorySlot(_item, _amount));
        }
    }

    public void RemoveItem(Item_SO _item, int _amount)
    {
        Container.Remove(new InventorySlot(_item, _amount));
    }
}

[System.Serializable]
public class InventorySlot
{
    public Item_SO item;
    public int amount;

    //Constructor
    public InventorySlot(Item_SO _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}