using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPoint : MonoBehaviour, ITargetInfo
{
    private PlayerMovement playerBoost;
    private PlayerStatus playerSpCheck;


    [Header("Sp Checks")]
    [SerializeField] protected int spChecklvl1;
    [SerializeField] protected int spChecklvl2;

    [Header("Target Info")]
    [SerializeField] protected string targetName;
    [SerializeField] protected string targetAct01;
    [SerializeField] protected string targetAct02;


    private void Awake()
    {


    }

    // Start is called before the first frame update
    void Start()
    {
        TargetEventSystem.currentTarget.onConfirmTargetSelect += OnTeleportTarget;
    }

    private void OnTeleportTarget(GameObject obj, GameObject playerObj, int spCheck)
    {
        //CHANGE LATER if going for the more Jump Boost setup the spCheck
        if (obj == this.gameObject)
        {

            //make a condition for checking you need more than one stacks


            playerBoost = playerObj.GetComponent<PlayerMovement>();

            if (playerBoost != null)
            {
                playerBoost.GhostBoost(transform, 25f);
            }
        }
    }

    private void OnDisable()
    {
        TargetEventSystem.currentTarget.onConfirmTargetSelect -= OnTeleportTarget;
    }

    public void GetTargetInfo(out string _targetName, out string act01, out string act02, out int spReq01, out int spReq02)
    {
        _targetName = targetName;
        act01 = targetAct01;
        act02 = targetAct02;
        spReq01 = spChecklvl1;
        spReq02 = spChecklvl2;
    }
}
