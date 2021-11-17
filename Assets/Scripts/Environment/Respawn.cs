using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform currentCheckpoint;

    private void Start()
    {
        TargetEventSystem.currentTarget.onCheckPointUpdate += CheckPointChecker;
    }

    private void CheckPointChecker(Transform targetCheckPoint)
    {
        currentCheckpoint = targetCheckPoint;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = currentCheckpoint.transform.position;
            Physics.SyncTransforms();
        }
    }

    private void OnDisable()
    {
        TargetEventSystem.currentTarget.onCheckPointUpdate -= CheckPointChecker;
    }
}
