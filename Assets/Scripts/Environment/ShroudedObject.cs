using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroudedObject : MonoBehaviour
{

    // private GameObject shroudedObj;
    private bool isShrouded = true;
    private bool isActivated = false;
    [SerializeField] private string goalTitle;
    private int activateCounter = 1;
    [SerializeField] private int spChecklvl1;
    [SerializeField] private int spChecklvl2;

    [SerializeField] private float lookRadius = 1f;


    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
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
            //Shroud is activated
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

            if (currentSp <= spChecklvl1)
            {
                isShrouded = false;

                if (!isActivated)
                {
                    Debug.Log("Weak sauce");
                    GoalEvent.currentGoalEvent.spInteractUpdate(goalTitle, activateCounter);
                }

                this.transform.GetChild(0).gameObject.SetActive(true);
                //Change behaviour because of npcStateController
            }
            else if (currentSp >= spChecklvl2)
            {
                Debug.Log("strong Sauce");
            }
            isActivated = true;
        }
    }


    void OnDisable()
    {

        TargetEventSystem.currentTarget.onConfirmTargetSelect -= ObjectConfirmed;
        TargetEventSystem.currentTarget.onShroudDetected -= ShroudDetected;
    }

    void OnTriggerEnter(Collider other)
    {
    }

    void OnTriggerExit(Collider other)
    {
        // if (isShrouded)
        // {
        //     Debug.Log("shroud");
        //     this.transform.GetChild(0).gameObject.SetActive(false);
        // }
    }

}
