using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroudedObject : MonoBehaviour
{

    // private GameObject shroudedObj;
    private bool isShrouded = true;
    private bool isActivated = false;

    [Header("Only use if it does NOT has Goal Environment or NPCstatus")]
    [SerializeField] private string goalTitle;
    private int activateCounter = 1;
    [SerializeField] private int spCheck;
    [SerializeField] private float lookRadius = 1f;
    private Collider myCollider;

    private GoalEnvironment interactiveObj;
    private NPCStatus npcObject;


    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    private void Awake()
    {
        myCollider = GetComponent<Collider>();
        interactiveObj = GetComponent<GoalEnvironment>();
        npcObject = GetComponent<NPCStatus>();
    }

    void Start()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        TargetEventSystem.currentTarget.onConfirmTargetSelect += ObjectConfirmed;
        TargetEventSystem.currentTarget.onShroudDetected += ShroudDetected;

        if (spCheck <= 0)
        {
            Debug.LogError("sp Checks cannot be zero");
        }

        //Checks if the object is something written on the goaltitle and the object has goalenvironment
        if (!String.IsNullOrEmpty(goalTitle) && (interactiveObj == null || npcObject == null))
        {
            Debug.LogError("Goal Title has characters. This should be empty if have a child of GoalEnvironment Script");
        }
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
        if (obj == this.gameObject && currentSp >= spCheck)
        {
            Debug.Log("got hit");

            if (currentSp <= spCheck)
            {

                if (!isActivated)
                {
                    Debug.Log("Weak sauce");
                    GoalEvent.currentGoalEvent.spInteractUpdate(goalTitle, activateCounter);
                }

                this.transform.GetChild(0).gameObject.SetActive(true);
                myCollider.isTrigger = false;
                this.enabled = false;
                isShrouded = false;
            }
            isActivated = true;
        }
    }


    void OnDisable()
    {

        TargetEventSystem.currentTarget.onConfirmTargetSelect -= ObjectConfirmed;
        TargetEventSystem.currentTarget.onShroudDetected -= ShroudDetected;
    }


}
