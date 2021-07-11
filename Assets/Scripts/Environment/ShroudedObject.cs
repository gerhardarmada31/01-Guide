using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroudedObject : MonoBehaviour
{

    // private GameObject shroudedObj;
    private bool isShrouded = true;
    private bool isActivated = false;
    [SerializeField] private int spChecklvl1;
    [SerializeField] private int spChecklvl2;

    void Awake()
    {
    }
    void Start()
    {
        TargetEventSystem.currentTarget.onConfirmTargetSelect += ObjectConfirmed;
        TargetEventSystem.currentTarget.onShroudDetected += ShroudDetected;

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
        if (obj == this.gameObject && currentSp >= spChecklvl1)
        {
            Debug.Log("got hit");
            this.transform.GetChild(0).gameObject.SetActive(true);
            // isActivated = true;

            if (currentSp <= spChecklvl1)
            {
                Debug.Log("Weak sauce");
                //Change behaviour because of npcStateController
            }
            else if (currentSp >= spChecklvl2)
            {
                Debug.Log("strong Sauce");
            }
        }
    }

    void OnDisable()
    {
        TargetEventSystem.currentTarget.onConfirmTargetSelect -= ObjectConfirmed;
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
