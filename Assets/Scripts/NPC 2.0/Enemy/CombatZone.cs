using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatZone : MonoBehaviour
{
    [SerializeField] private string goalName;
    [SerializeField] private bool hasGoal;
    private EnemySpawner[] enemySpawners;
    [SerializeField] private List<GameObject> enemyList = new List<GameObject>();
    private int killCount;
    private int totalEnemies;
    private float despawnTime = 8f;
    private GoalKill goalKill;
    Coroutine coroutine;
    private ITakeDamage playerTarget;
    public GameObject PlayerInZone { get; private set; }


    private void Awake()
    {
        enemySpawners = this.GetComponentsInChildren<EnemySpawner>();
        goalKill = this.GetComponent<GoalKill>();

        foreach (EnemySpawner _enemy in enemySpawners)
        {
            enemyList.Add(_enemy.SpawnedObj);
        }
        totalEnemies = enemyList.Count;
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

    public void KillGoalCheck()
    {
        if (hasGoal == true)
        {
            killCount++;

            if (killCount >= totalEnemies)
            {
                // Debug.Break();
                GoalEvent.currentGoalEvent.AreaClearComplete(goalName, true, 1);
                // GoalEvent
                //Call goalKillComplete(GoalName, killCount)
            }
        }

    }
}
