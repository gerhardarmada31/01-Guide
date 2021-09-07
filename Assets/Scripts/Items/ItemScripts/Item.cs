using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Item_SO item;

    private void Start()
    {
        TargetEventSystem.currentTarget.onConfirmTargetSelect += ObjectConfirmed;
    }

    private void ObjectConfirmed(GameObject obj, GameObject playerObj, int currentSp)
    {
        if (obj == this.gameObject)
        {
            Debug.Log("got hit");

            //ADD Item
        }
    }

    private void OnDisable()
    {
         TargetEventSystem.currentTarget.onConfirmTargetSelect -= ObjectConfirmed;
    }
}
