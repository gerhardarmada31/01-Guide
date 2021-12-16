using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Item_SO item;

    public int ItemAmount { get; set; }
    private string itemID;
    [SerializeField] private string goalTitle;
    private void Start()
    {
        ItemAmount = item.itemAmount;
        itemID = item.itemID;
    }

    private void ObjectConfirmed(GameObject obj, GameObject playerObj, int currentSp)
    {
        if (obj == this.gameObject)
        {
            // GoalEvent.currentGoalEvent.AmountUpdate()
            Destroy(this.gameObject);           
        }
    }

    private void OnDisable()
    {
         TargetEventSystem.currentTarget.onConfirmTargetSelect -= ObjectConfirmed;
    }
}
