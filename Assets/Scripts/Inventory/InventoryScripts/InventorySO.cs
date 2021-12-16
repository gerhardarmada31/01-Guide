using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;


[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Inventory")]
public class InventorySO : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();




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
            InventoryEvent.currentInventoryEvent.ItemNotify(_item.itemNameUI);
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