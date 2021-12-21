using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InventoryEvent : MonoBehaviour
{
    public static InventoryEvent currentInventoryEvent;

    private void Awake()
    {
        currentInventoryEvent = this;
    }

    public event Action<bool> onInventoryUpdateUI;
    public event Action<Equipment_SO, bool> onEquipPlayer;
    public event Action<bool> onPlayerItemNotify;
    public event Action<string> onNameItemNotify;
    public event Action<int> onPlayerSPUpgrade;

    public void InventoryUpdateUI(bool isAdd)
    {
        onInventoryUpdateUI?.Invoke(isAdd);
    }

    public void EquipItemPlayer(Equipment_SO _item, bool _hasHat)
    {
        onEquipPlayer?.Invoke(_item, _hasHat);
    }

    public void InputItemNotify(bool _isItemNotify)
    {
        onPlayerItemNotify?.Invoke(_isItemNotify);
    }

    public void ItemNotify(string _itemName)
    {
        onNameItemNotify?.Invoke(_itemName);
    }

    public void PlayerSPUpgrade(int _spPlusAmount)
    {
        onPlayerSPUpgrade?.Invoke(_spPlusAmount);
    }
}
