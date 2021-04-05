using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPoint : MonoBehaviour, ITakePosition
{
    private GameObject playerTransform;
    private PlayerMovement playerBoost;
    private PlayerStatus playerSpCheck;

    public void TakePosition(Vector3 takeposition)
    {
        takeposition = this.gameObject.transform.position;
    }

    private void Awake()
    {


    }

    // Start is called before the first frame update
    void Start()
    {
        TargetEventSystem.current.onConfirmTargetSelect += OnTeleportTarget;
    }

    private void OnTeleportTarget(GameObject obj, GameObject playerObj)
    {
        if (obj == this.gameObject)
        {
            playerTransform = playerObj;

            playerTransform.transform.position = gameObject.transform.position;

            // // if the players SP is not enough 
            playerBoost = playerObj.GetComponent<PlayerMovement>();

            if (playerBoost != null)
            {
                // Teleport to a target and boost
                playerBoost.GhostBoost(transform,25f);
            }
            //myPlayerCharacter.transform.position = gameObject.transform.position;
        }
    }

    private void OnDisable()
    {
        TargetEventSystem.current.onConfirmTargetSelect -= OnTeleportTarget;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
