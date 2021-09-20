using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Item_SO item;

    public int ItemAmount { get; set; }
    private string itemTitle;
    [SerializeField] private string goalTitle;
    private void Start()
    {
        ItemAmount = item.itemAmount;
        itemTitle = item.itemTitle;
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
