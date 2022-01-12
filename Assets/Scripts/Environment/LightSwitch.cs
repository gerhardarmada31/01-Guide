using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int spCheckLvl1;
    //Variable for the light component to check if its on or off
    private Light lightSource;

    void Start()
    {
        lightSource = GetComponentInChildren<Light>();
        TargetEventSystem.currentTarget.onConfirmTargetSelect += ObjectConfirmed;
    }

    private void ObjectConfirmed(GameObject obj, GameObject playerObj, int sentSP)
    {
        if (obj == this.gameObject && sentSP >= spCheckLvl1)
        {
            lightSource.enabled = true;
        }

    }

    private void OnDisable()
    {
        TargetEventSystem.currentTarget.onConfirmTargetSelect -= ObjectConfirmed;
    }
}
