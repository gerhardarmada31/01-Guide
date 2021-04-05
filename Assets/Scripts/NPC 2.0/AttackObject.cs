using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObject : MonoBehaviour
{
    public EnemyStats enemyStats;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        ITakeDamage damage = other.GetComponent<ITakeDamage>();

        if (damage != null)
        {
            damage.TakeDamage(enemyStats.attackDamage);
        }
    }
}
