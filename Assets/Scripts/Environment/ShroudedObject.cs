using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroudedObject : MonoBehaviour
{

    // private GameObject shroudedObj;
    private bool isShrouded = true;
    private bool isActivated = false;

    [Header("Only write if object does not have Goal Environment")]
    [SerializeField] private string goalTitle;
    private int activateCounter = 1;
    [SerializeField] private int spCheck;
    [SerializeField] private float lookRadius = 1f;
    private Collider myCollider;

    private GoalEnvironment interactiveObj;


    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    private void Awake()
    {
        myCollider = GetComponent<Collider>();
        interactiveObj = GetComponent<GoalEnvironment>();
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

        if (!String.IsNullOrEmpty(goalTitle) && interactiveObj != null)
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
