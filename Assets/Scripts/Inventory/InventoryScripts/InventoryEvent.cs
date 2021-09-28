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

    public void InventoryUpdateUI(bool isAdd)
    {
        onInventoryUpdateUI?.Invoke(isAdd);
    }
}
