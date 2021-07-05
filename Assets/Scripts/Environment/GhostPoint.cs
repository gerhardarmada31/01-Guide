using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPoint : MonoBehaviour
{
    private PlayerMovement playerBoost;
    private PlayerStatus playerSpCheck;

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
        if (obj == this.gameObject)
        {

         //make a condition for checking you need more than one stacks


            playerBoost = playerObj.GetComponent<PlayerMovement>();

            if (playerBoost != null)
            {
                playerBoost.GhostBoost(transform,25f);
            }
        }
    }

    private void OnDisable()
    {
        TargetEventSystem.currentTarget.onConfirmTargetSelect -= OnTeleportTarget;
    }
}
