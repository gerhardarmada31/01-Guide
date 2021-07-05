using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatZone : MonoBehaviour
{
    private EnemySpawner[] enemySpawners;


    private void Awake()
    {
        enemySpawners = this.GetComponentsInChildren<EnemySpawner>();
    }

    void OnTriggerEnter(Collider other)
    {
        ITakeDamage playerTarget = other.GetComponent<ITakeDamage>();
        if (playerTarget != null)
        {
            Debug.Log("PlayerHasEntered");
            //this is true send call function to all enemySpawner to instantiate enemies

            foreach (EnemySpawner _enemySpawner in enemySpawners)
            {
                _enemySpawner.SpawnEnemies();
            }
        }
    }
}
