using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField] NPCStateController controller;
    [SerializeField] private bool isDetectorFriend;

    private void OnEnable()
    {
        controller = GetComponentInParent<NPCStateController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            controller.ChaseTarget = other.gameObject.transform;
            controller.IsplayerIn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isDetectorFriend)
            {
                controller.ChaseTarget = null;
                Debug.Log("PlayerExit");
            }
            controller.IsplayerIn = false;

        }
    }

}
