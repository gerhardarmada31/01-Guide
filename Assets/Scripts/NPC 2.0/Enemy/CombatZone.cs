using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatZone : MonoBehaviour
{
    private EnemySpawner[] enemySpawners;
    private float despawnTime = 3f;
    Coroutine coroutine;

    private ITakeDamage playerTarget;
    public GameObject PlayerInZone { get; private set; }


    private void Awake()
    {
        enemySpawners = this.GetComponentsInChildren<EnemySpawner>();
    }

    void OnTriggerEnter(Collider other)
    {
        playerTarget = other.GetComponent<ITakeDamage>();

        if (playerTarget != null)
        {
            PlayerInZone = other.gameObject;
            Debug.Log("Stop coroutine");
            //this is true send call function to all enemySpawner to instantiate enemies

            foreach (EnemySpawner _enemySpawner in enemySpawners)
            {
                _enemySpawner.SpawnEnemies();
                // colEnemies.Add(_enemySpawner.gameObject);
            }
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        // if (PlayerInZone == other.gameObject)
        // {
        //     StopCoroutine(coroutine);
        // }
    }

    void OnTriggerExit(Collider other)
    {
        if (PlayerInZone == other.gameObject)
        {
            coroutine = StartCoroutine(DespawnTimer());
        }
    }

    IEnumerator DespawnTimer()
    {
        yield return new WaitForSeconds(despawnTime);
        foreach (EnemySpawner _enemySpawner in enemySpawners)
        {
            _enemySpawner.DeSpawnEnemies();
        }
    }
}
