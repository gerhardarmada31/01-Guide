using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Item_SO item;

    public int ItemAmount { get; set; }
    private string itemID;

    [Header("QuestName")]
    [SerializeField] private string goalTitle;
    private bool isItemPicked;
    private void Start()
    {
        if (item == null)
        {
            Debug.LogError("Item is empty");
        }
        ItemAmount = item.itemAmount;
        itemID = item.itemID;
        TargetEventSystem.currentTarget.onConfirmTargetSelect += ObjectConfirmed;
    }

    private void ObjectConfirmed(GameObject obj, GameObject playerObj, int currentSp)
    {
        Debug.Log("DESTROY OBJ");
        if (obj == this.gameObject)
        {
            if(!String.IsNullOrEmpty(goalTitle))
            {
             GoalEvent.currentGoalEvent.GoalItem(goalTitle);
             Debug.Log("GOAL TITLE IS SENT FROM ITEM");
            }
            // GoalEvent.currentGoalEvent.AmountUpdate()
            Destroy(this.gameObject);
        }
    }

    private void OnDisable()
    {
        TargetEventSystem.currentTarget.onConfirmTargetSelect -= ObjectConfirmed;
    }
}
