using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GoalEnvironment : MonoBehaviour
{
    [Header("Goal Attributes")]
    [SerializeField] protected string goalTitle;
    protected int goalCounter = 1;

    [Header("Sp Checks")]
    [SerializeField] protected int spChecklvl1;
    [SerializeField] protected int spChecklvl2;

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

    protected virtual void ObjectConfirmed(GameObject _obj, GameObject _playerObj, int sentSP)
    {
        Debug.Log("yo  got hit");
        if (_obj == this.gameObject && sentSP >= spChecklvl1)
        {
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
                if (sentSP <= spChecklvl1)
                {
                    ActObjectLvl1();
                }
                else if (sentSP >= spChecklvl2)
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

    private void OnDisable()
    {
        TargetEventSystem.currentTarget.onConfirmTargetSelect -= ObjectConfirmed;
    }
}
