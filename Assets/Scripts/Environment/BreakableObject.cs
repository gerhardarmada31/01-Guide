using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : GoalEnvironment, ITargetInfo
{
    [SerializeField] private int breakableObjHP;
    [SerializeField] private GameObject dropPrefab;


    // [Header("Sp Checks")]
    // [SerializeField] protected int spChecklvl1;
    // [SerializeField] protected int spChecklvl2;

    // [Header("Target Info")]
    // [SerializeField] protected string targetName;
    // [SerializeField] protected string targetAct01;
    // [SerializeField] protected string targetAct02;

    private void Awake()
    {
        if (spChecklvl1 <= 0 || spChecklvl2 <= 0)
        {
            Debug.LogError("spCheck 1 or 2 cannot be in the value of 0");
        }

        if (String.IsNullOrEmpty(targetAct01) || String.IsNullOrEmpty(targetAct02) || String.IsNullOrEmpty(targetName))
        {
            Debug.LogError("target name or Acts cannot be Null");
        }
    }
    protected override void Start()
    {
        base.Start();
        // TargetEventSystem.currentTarget.onConfirmTargetSelect += ObjectConfirmed;
    }


    protected override void ActObjectLvl2()
    {
        breakableObjHP -= sentSP;

        if (breakableObjHP <= 0)
        {
            DropObject();
            gameObject.SetActive(false);
        }
    }

    public void DropObject()
    {
        bool isObjDropped = false;

        if (isObjDropped == false && this.enabled)
        {
            Instantiate(dropPrefab, gameObject.transform.position, gameObject.transform.rotation);
            isObjDropped = true;
        }

    }


    private void OnDisable()
    {
        TargetEventSystem.currentTarget.onConfirmTargetSelect -= ObjectConfirmed;
    }

}
