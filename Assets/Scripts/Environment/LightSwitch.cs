using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : GoalEnvironment
{
    // Start is called before the first frame update


    //Variable for the light component to check if its on or off
    private Light lightSource;
    private bool isLit = false;

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

    protected override void ActObjectLvl2()
    {
        lightSource.enabled = true;
        Debug.Log("LIGHT");
        if (!isLit)
        {
            UpdateGoal(1);
        }
        isLit = true;
    }

    protected override void ActObjectLvl1()
    {
        // base.ActObjectLvl1();
        lightSource.enabled = false;
        UpdateGoal(-1);
        isLit = false;
        //Check if the 
    }
}
