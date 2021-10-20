using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Yarn.Unity;
using System.Linq;

public abstract class GoalBase : MonoBehaviour
{
    [Header("Goal Attribute")]
    [SerializeField] protected string goalTitle;
    [SerializeField] protected Item_SO rewardEquip;
    [SerializeField] protected int rewardCoin;

    protected bool goalComplete;

    //current amount can be the amount of certain items
    protected int currentAmount;
    protected int requiredAmount;

    public void GoalReward(string[] _typeReward)
    {
        //Get player from friendStatus
        FriendStatus player = this.GetComponent<FriendStatus>();
        if (_typeReward.Contains("Coin"))
        {
            //Interface send the coin via Interface
            // ICollector _coinReward = player.PlayerObj.GetComponent<ICollector>();
            ICoinReward _coinReward = player.PlayerObj.GetComponent<ICoinReward>();
            if (_coinReward != null)
            {
                _coinReward.GetCoinReward(rewardCoin);
            }
            Debug.Log("Get Reward Item");
        }
        else if (_typeReward.Contains("Item"))
        {
            //Event Based Item
            PlayerInventory playerInventory = player.PlayerObj.GetComponent<PlayerInventory>();

            if (rewardEquip != null)
            {
                playerInventory.inventory.AddItem(rewardEquip, 1);
                InventoryEvent.currentInventoryEvent.InventoryUpdateUI(true);
            }
        }
    }

    protected virtual void Start()
    {


    }

    // protected abstract void CheckAmount(string goalName, int currentAmount);

    protected virtual void OnDisable()
    {

    }
}
