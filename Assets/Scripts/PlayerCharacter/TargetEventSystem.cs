using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TargetEventSystem : MonoBehaviour
{
    public static TargetEventSystem current;

    private void Awake()
    {
        current = this;
    }

    public event Action<GameObject, GameObject> onConfirmTargetSelect;

    //Getting the target and getting from the players Values
    public void ConfirmTargetSelect(GameObject target, GameObject playerObj)
    {
        onConfirmTargetSelect?.Invoke(target, playerObj);

        // if (onConfirmTargetSelect != null)
        // {
        //     onConfirmTargetSelect(obj);
        // }
    }
}
