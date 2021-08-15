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

    public event Action<string, int> onGoalUpdate;
    public event Action<GameObject, bool> onGoalKillUpdate;
    public event Action<string, bool, int> onAreaClearComplete;
    public event Action<string, bool> onGoalComplete;

    public void AmountUpdate(string goalName, int goalAmountUpdate)
    {
        onGoalUpdate?.Invoke(goalName, goalAmountUpdate);
    }

    public void KillUpdate(GameObject thisEnemy, bool isEnemyDead)
    {
        onGoalKillUpdate?.Invoke(thisEnemy, isEnemyDead);
    }

    public void AreaClearComplete(string completedGoalName, bool isAreaClear, int numOfAreasCleared)
    {
        onAreaClearComplete?.Invoke(completedGoalName, isAreaClear, numOfAreasCleared);
    }

    public void GoalComplete(string completedGoalName, bool isGoalComplete)
    {
        onGoalComplete?.Invoke(completedGoalName, isGoalComplete);
    }
}
