using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quest : MonoBehaviour
{
    protected string description;
    protected bool questComplete;

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
}
