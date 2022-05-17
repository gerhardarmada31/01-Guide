using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetInfo : MonoBehaviour
{
    [SerializeField] private string targetName;
    [SerializeField] private string targetAct;
    //actCostRequirement = goalEnvironments or NPCs spRequirment make this a interface probably
    // private bool hasShroud;

    private void Awake()
    {
        // ShroudChecker();
    }

    // public void ShroudChecker()
    // {
    //     if (this.GetComponent<ShroudedObject>() != null)
    //     {
    //         if (this.GetComponent<ShroudedObject>().enabled == true)
    //         {
    //             hasShroud = true;
    //         }
    //         else
    //         {
    //             hasShroud = false;
    //         }
    //     }

    // }

    public void GetInfo(out string _targetName, out string _targetAct)
    {
        // ShroudChecker();
        // if (hasShroud)
        // {
        //     _targetAct = "REVEAL";
        //     _targetName = "Shrouded";
        // }
        // else
        // {
        // }
            Debug.Log("TARGET INFO IS CALLED");
            _targetName = targetName;
            _targetAct = targetAct;

    }




}
