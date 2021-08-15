using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject spawnedObj;
    public GameObject SpawnedObj
    {
        get { return spawnedObj; }
        set { spawnedObj = value; }
    }

    public bool SpawnedEnemyDied { get; private set; }

    private CombatZone parentCombatZone;
    private bool hasSpawned = false;

    private void Awake()
    {
        parentCombatZone = this.GetComponentInParent<CombatZone>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GoalEvent.currentGoalEvent.onGoalKillUpdate += KillCount;
    }

    private void KillCount(GameObject _thisEnemy, bool _isEnemyDead)
    {
        if (_thisEnemy == SpawnedObj)
        {
            Debug.Log("YOYOYOYOYOYOYO" + _thisEnemy);
            SpawnedEnemyDied = _isEnemyDead;
            parentCombatZone.KillGoalCheck();
        }
    }

    public void SpawnEnemies()
    {
        if (hasSpawned == false)
        {
            SpawnedObj = Instantiate(SpawnedObj, transform.position, transform.rotation, this.gameObject.transform);
            Debug.Log("Spawning");
            hasSpawned = true;
        }
        else
        {
            if (!SpawnedEnemyDied)
            {
                SpawnedObj.SetActive(true);
            }
        }
    }

    public void DeSpawnEnemies()
    {
        // gameObject.SetActive(false);
        SpawnedObj.SetActive(false);
    }
}
