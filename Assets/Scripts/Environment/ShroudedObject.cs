using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroudedObject : MonoBehaviour
{

    // private GameObject shroudedObj;
    private bool isShrouded = true;
    private bool isActivated = false;
    [SerializeField] private int spCheck;

    void Awake()
    {
    }
    void Start()
    {
        TargetEventSystem.current.onConfirmTargetSelect += ObjectConfirmed;
        TargetEventSystem.current.onShroudDetected += ShroudDetected;

    }

    private void ShroudDetected(GameObject obj, bool shroudOn)
    {
        if (obj == this.gameObject)
        {
            isShrouded = shroudOn;
        }

        if (!isShrouded)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (!isActivated)
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void ObjectConfirmed(GameObject obj, GameObject playerObj, int currentSp)
    {
        if (obj == this.gameObject && currentSp >= spCheck)
        {
            Debug.Log("got hit");
            this.transform.GetChild(0).gameObject.SetActive(true);
            // isActivated = true;
        }
    }

    void OnDisable()
    {
        TargetEventSystem.current.onConfirmTargetSelect -= ObjectConfirmed;
    }

    void OnTriggerEnter(Collider other)
    {
    }

    void OnTriggerExit(Collider other)
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void Update()
    {

    }


}
