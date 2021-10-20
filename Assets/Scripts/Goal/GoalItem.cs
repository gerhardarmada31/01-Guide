using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GoalItem : GoalBase
{
    // Start is called before the first frame update

    [SerializeField] int ObjectRequireAmount = 1;
    public InventorySO playerInventory;
    [SerializeField] private DisplayInventory UIItem;

    [SerializeField] private string requiredItemTitle;
    [SerializeField] private string speakerName;
    private bool goalItem;

    void Awake()
    {
        if (UIItem == null)
        {
            UIItem = FindObjectOfType<DisplayInventory>();
        }
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
            //checks if the SO item tittle is the same as the goalItemTitle
            for (int i = 0; i < playerInventory.Container.Count; i++)
            {
                if (playerInventory.Container[i].item.itemTitle == requiredItemTitle)
                {
                    Debug.Log("goal ITEM COMPLETE " + playerInventory.Container[i].item);
                    GoalEvent.currentGoalEvent.GoalComplete(goalTitle, true);
                    goalComplete = true;
                    var dicItem = UIItem.ItemsDisplayed;

                    if (dicItem.ContainsKey(playerInventory.Container[i]))
                    {
                        //Destroying the Dictionary, SO, and the object for Inventory
                        GameObject itemObj = dicItem[playerInventory.Container[i]];
                        Destroy(itemObj);
                        dicItem.Remove(playerInventory.Container[i]);
                        playerInventory.Container.Remove(playerInventory.Container[i]);

                        //Debugs the values
                        // foreach (var keyVal in dicItem)
                        // {
                        //     Debug.Log("Key = {0}, Value= {1} " + keyVal.Key + keyVal.Value);
                        // }
                    }
                }
            }



        }

    }
}
