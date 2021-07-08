using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnedObj;

    private CombatZone parentCombatZone;
    private bool hasSpawned = false;

    private void Awake()
    {
        parentCombatZone = this.GetComponentInParent<CombatZone>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SpawnEnemies()
    {
        if (hasSpawned == false)
        {
            Instantiate(spawnedObj, transform.position, transform.rotation, this.gameObject.transform);

            Debug.Log("Spawning");
            hasSpawned = true;
            // npcController.ChaseTarget = parentCombatZone.PlayerInZone.transform;
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    public void DeSpawnEnemies()
    {
        gameObject.SetActive(false);
    }
}
