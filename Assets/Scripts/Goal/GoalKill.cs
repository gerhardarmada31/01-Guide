using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKill : GoalBase
{
    //Maybe make reqAreasCleared into a List?
    [SerializeField] private int reqAreasCleared;
    private int currentAreasCleared;
    private bool isAreaClear = false;

    protected override void Start()
    {
        base.Start();
        // GoalEvent.currentGoalEvent.onGoalKillUpdate += AreaCheck;
        GoalEvent.currentGoalEvent.onAreaClearComplete += AreaCheck;
    }

    private void AreaCheck(string _goalName, bool _isAreaClear, int _addAreaClear)
    {
        if (goalTitle == _goalName)
        {
            isAreaClear = _isAreaClear;
            currentAreasCleared += _addAreaClear;
            if (currentAreasCleared >= reqAreasCleared && isAreaClear)
            {
                Debug.Break();
                GoalEvent.currentGoalEvent.GoalComplete(goalTitle, true);
            }
        }
        // throw new NotImplementedException();
    }
}
