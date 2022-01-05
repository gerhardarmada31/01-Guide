using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TargetEventSystem : MonoBehaviour
{
    public static TargetEventSystem currentTarget;

    private void Awake()
    {
        currentTarget = this;
    }

    public event Action<GameObject, GameObject, int> onConfirmTargetSelect;
    public event Action<GameObject, bool> onShroudDetected;
    public event Action<Transform> onCheckPointUpdate;
    public event Action<string, string, bool> onTargetInfoUpdate;


    //Getting the target and getting from the players Values
    //spCheck is the totalDmg from playerStatus
    public void ConfirmTargetSelect(GameObject target, GameObject playerObj, int spCheck)
    {
        onConfirmTargetSelect?.Invoke(target, playerObj, spCheck);
    }

    public void ShroudDetected(GameObject shroudObject, bool isDetected)
    {
        onShroudDetected?.Invoke(shroudObject, isDetected);
    }

    public void CheckPointUpdate(Transform targetCheckPoint)
    {
        onCheckPointUpdate?.Invoke(targetCheckPoint);
    }

    public void TargetInfoUpdate(string _name, string _act, bool _cmdOn)
    {
        onTargetInfoUpdate?.Invoke(_name, _act, _cmdOn);
    }
}
