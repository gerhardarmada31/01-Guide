using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackObject : MonoBehaviour
{
    public EnemyStats enemyStats;
    protected float objTimer;



    // Start is called before the first frame update
    void Start()
    {

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

    protected void DestroyObject()
    {
        Destroy(gameObject, objTimer);
    }
}
