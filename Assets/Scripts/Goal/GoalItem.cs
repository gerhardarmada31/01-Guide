using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalItem : GoalBase
{
    // Start is called before the first frame update

    [SerializeField] int ObjectRequireAmount = 1;
    public InventorySO playerInventory;

    [SerializeField] private string requiredItemTitle;
    [SerializeField] private string speakerName;
    private bool goalItem;

    void Awake()
    {

    }

    protected override void Start()
    {
        base.Start();
        requiredAmount = ObjectRequireAmount;
        GoalEvent.currentGoalEvent.onGoalItem += ItemGoal;
        // GoalEvent.currentGoalEvent.onGoalItemUpdate += CheckItem;
    }

    //MAKE A BOOLEAN THAT SAYS THE ACCEPTGOAL = TRUE
    private void ItemGoal(string speakerName)
    {
        goalItem = true;
    }

    //Checks the item if the player has. if it does remove it.
    public void CheckItem()
    {
        if (goalComplete == false && goalItem == true)
        {
            for (int i = 0; i < playerInventory.Container.Count; i++)
            {
                if (playerInventory.Container[i].item.itemTitle == requiredItemTitle)
                {
                    // playerInventory.RemoveItem(playerInventory.Container[i].item,requiredAmount);
                    Debug.Log("goal ITEM COMPLETE " + playerInventory.Container[i].item);
                    GoalEvent.currentGoalEvent.GoalComplete(goalTitle, true);
                    goalComplete = true;
                    InventoryEvent.currentInventoryEvent.InventoryUpdateUI(false);
                    playerInventory.Container.Remove(playerInventory.Container[i]);
                    // break;
                }
            }
        }

    }
}
