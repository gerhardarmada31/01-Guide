using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetInfo : MonoBehaviour
{
    [SerializeField] private string targetName;
    [SerializeField] private string targetAct;

    public void GetInfo(out string _targetName, out string _targetAct)
    {
        Debug.Log("TARGET INFO IS CALLED");
        _targetName = targetName;
        _targetAct = targetAct;
    }


}
