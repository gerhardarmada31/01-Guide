using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GoalEnvironment : MonoBehaviour, ITargetInfo
{
    [Header("Goal Attributes")]
    [SerializeField] protected string goalTitle;
    protected int goalCounter = 0;


    [Header("Sp Checks")]
    [SerializeField] protected int spChecklvl1;
    [SerializeField] protected int spChecklvl2;

    [Header("Target Info")]
    [SerializeField] protected string targetName;
    [SerializeField] protected string targetAct01;
    [SerializeField] protected string targetAct02;


    protected int sentSP;
    protected GameObject player;



    private ShroudedObject shroudObj;
    private bool hasShroud;

    protected virtual void Start()
    {
        TargetEventSystem.currentTarget.onConfirmTargetSelect += ObjectConfirmed;

        if (spChecklvl2 <= 0 || spChecklvl1 <= 0)
        {
            Debug.LogError("sp Checks cannot be zero");
        }
    }

    protected virtual void ObjectConfirmed(GameObject _obj, GameObject _playerObj, int _sentSP)
    {
        Debug.Log("yo  got hit");
        if (_obj == this.gameObject && _sentSP >= spChecklvl1)
        {
            player = _playerObj;
            sentSP = _sentSP;
            //FIX this Shrouded needs to reveal first then back to activiting it
            //Solution Probably add a boolean in the objectconfirmed event that says shroudGone?
            if (this.GetComponent<ShroudedObject>() != null && this.GetComponent<ShroudedObject>().enabled == false)
            {
                Debug.Log("ShroudStuff");
                // Debug.Log("ShroudCall");

                // {
                //     if (sentSP <= spChecklvl1)
                //     {
                //         ActObjectLvl1();
                //     }
                //     else if (sentSP >= spChecklvl2)
                //     {
                //         ActObjectLvl2();
                //     }

                // }
            }
            else
            {
                Debug.Log("ShroudCall");
                if (_sentSP <= spChecklvl1)
                {
                    ActObjectLvl1();
                }
                else if (_sentSP >= spChecklvl2)
                {
                    ActObjectLvl2();
                }

            }
        }

    }

    protected virtual void ActObjectLvl1()
    {

    }

    protected virtual void ActObjectLvl2()
    {

    }

    protected virtual void UpdateGoal(int _count)
    {
        goalCounter = goalCounter + (_count);
        if (goalCounter <= 0)
        {
            goalCounter = 0;
        }
        GoalEvent.currentGoalEvent.spInteractUpdate(goalTitle, goalCounter);
        Debug.Log($"Update Goal. Counter is {goalCounter} ");

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
