using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GoalEvent : MonoBehaviour
{
    public static GoalEvent currentGoalEvent;

    // Start is called before the first frame update
    private void Awake()
    {
        currentGoalEvent = this;
    }

    public event Action<string, int> onGoalspInteractUpdate;
    public event Action<string, string, int> onGoalItemUpdate;
    public event Action<GameObject, bool> onGoalKillUpdate;
    public event Action<string, bool, int> onAreaClearComplete;
    public event Action<string, bool> onGoalComplete;
    public event Action<string> onGoalItem;
    public event Action<string> onGoalTalk;


    //Amount updated for the objects interacted
    public void spInteractUpdate(string goalName, int goalSpInteractUpdate)
    {
        onGoalspInteractUpdate?.Invoke(goalName, goalSpInteractUpdate);
    }

    //Amount update for the item goals
    public void ItemUpdate(string goalName, string itemTitle, int itemAmountReq)
    {
        onGoalItemUpdate?.Invoke(goalName, itemTitle, itemAmountReq);
    }

    //respawner updates kill amount to the combat volume
    public void KillUpdate(GameObject thisEnemy, bool isEnemyDead)
    {
        onGoalKillUpdate?.Invoke(thisEnemy, isEnemyDead);
    }

    //Calls from the combat volume to the npc
    public void AreaClearComplete(string completedGoalName, bool isAreaClear, int numOfAreasCleared)
    {
        onAreaClearComplete?.Invoke(completedGoalName, isAreaClear, numOfAreasCleared);
    }

    //An event for the npc goalEnd dialog
    public void GoalComplete(string completedGoalName, bool isGoalComplete)
    {
        onGoalComplete?.Invoke(completedGoalName, isGoalComplete);
    }

    public void GoalItem(string itemGoalName)
    {
        onGoalItem?.Invoke(itemGoalName);
    }

    public void GoalTalk(string personTalk)
    {
        onGoalTalk?.Invoke(personTalk);
    }
}
