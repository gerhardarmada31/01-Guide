using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;


public class GoalObjInteract : GoalBase
{

    [SerializeField] int ObjectRequireAmount = 1;

    protected override void Start()
    {
        base.Start();
        requiredAmount = ObjectRequireAmount;
        GoalEvent.currentGoalEvent.onGoalspInteractUpdate += CheckAmount;
    }
    public void AddAmount()
    {
        currentAmount++;
    }

    private void CheckAmount(string goalName, int _currentAmount)
    {
        if (goalTitle == goalName)
        {
            Debug.Log("amountAdd");
            AddAmount();

            if (currentAmount >= requiredAmount)
            {
                goalComplete = true;
                GoalEvent.currentGoalEvent.GoalComplete(goalTitle, goalComplete);
                Debug.Log("Required amount met");
            }
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        GoalEvent.currentGoalEvent.onGoalspInteractUpdate -= CheckAmount;
    }

}
