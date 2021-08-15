using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Yarn.Unity;


public abstract class GoalBase : MonoBehaviour
{
    [SerializeField] protected string goalTitle;
    protected bool goalComplete;

    //current amount can be the amount of certain items
    protected int currentAmount;
    protected int requiredAmount;

    //<variables>
    //dialogues from NPC
    //list of objects that requires to be activated

    //Methods
    //Init 
    //Check Amount
    //Complete

    protected virtual void Start()
    {


    }

    // protected abstract void CheckAmount(string goalName, int currentAmount);

    protected virtual void OnDisable()
    {

    }
}
