using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : GoalEnvironment
{
    // Start is called before the first frame update

    [SerializeField] int spCheckLvl1;
    //Variable for the light component to check if its on or off
    private Light lightSource;

    private void Awake()
    {
        lightSource = GetComponentInChildren<Light>();
    }

    protected override void Start()
    {
        base.Start();
        // TargetEventSystem.currentTarget.onConfirmTargetSelect += ObjectConfirmed;
    }

    //CALL This on either ActObjectLvl1 or 2 depending on the level you want
    public void UpdateGoal()
    {
        GoalEvent.currentGoalEvent.spInteractUpdate(goalTitle, goalCounter);
        Debug.Log("Update Goal");
    }

    protected override void ActObjectLvl1()
    {
        lightSource.enabled = true;
        UpdateGoal();
    }
}
