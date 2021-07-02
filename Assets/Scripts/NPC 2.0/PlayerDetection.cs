using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField] NPCStateController controller;

    private void OnEnable()
    {
        controller = GetComponentInParent<NPCStateController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            controller.ChaseTarget = other.gameObject.transform;
            Debug.Log("PlayerEnter");
            controller.IsplayerIn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            controller.ChaseTarget = null;
            Debug.Log("PlayerExit");
            controller.IsplayerIn = false;
        }
    }


}
