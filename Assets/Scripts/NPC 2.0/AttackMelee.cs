using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMelee : AttackObject
{
    public EnemyStats enemyStats;
    [SerializeField] private float lifeTime;

    void Awake()
    {
        objTimer = lifeTime;
    }
    // Start is called before the first frame update
    void Start()
    {
        DestroyObject();
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        ITakeDamage damage = other.GetComponent<ITakeDamage>();

        if (damage != null)
        {
            damage.TakeDamage(enemyStats.attackDamage);
        }
    }
}
