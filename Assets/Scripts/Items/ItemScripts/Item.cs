using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, ITargetInfo
{
    public Item_SO item;

    public int ItemAmount { get; set; }
    private string itemID;

    [Header("Sp Checks")]
    [SerializeField] protected int spChecklvl1;
    [SerializeField] protected int spChecklvl2;

    [Header("Target Info")]
    [SerializeField] protected string targetName;
    [SerializeField] protected string targetAct01;
    [SerializeField] protected string targetAct02;

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
            if (!String.IsNullOrEmpty(goalTitle))
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

    public void GetTargetInfo(out string _targetName, out string act01, out string act02, out int spReq01, out int spReq02)
    {
        _targetName = targetName;
        act01 = targetAct01;
        act02 = targetAct02;
        spReq01 = spChecklvl1;
        spReq02 = spChecklvl2;
    }
}
