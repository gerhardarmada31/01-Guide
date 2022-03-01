using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour, ITargetInfo
{
    [Header("Sp Checks")]
    [SerializeField] protected int spChecklvl1;
    [SerializeField] protected int spChecklvl2;

    [Header("Target Info")]
    [SerializeField] protected string targetName;
    [SerializeField] protected string targetAct01;
    [SerializeField] protected string targetAct02;

    private void Start()
    {
        TargetEventSystem.currentTarget.onConfirmTargetSelect += ObjectConfirmed;
    }

    private void ObjectConfirmed(GameObject obj, GameObject playerObj, int currentSp)
    {
        if (obj == this.gameObject && currentSp >= 1)
        {
            Debug.Log("CHECKPOINT CHECK!");
            // SEND an EVENT to the Respawn Volume
            TargetEventSystem.currentTarget.CheckPointUpdate(this.gameObject.transform);
        }
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
