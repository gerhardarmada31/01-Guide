using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/EnemyStats", order = 0)]
public class EnemyStats : ScriptableObject 
{
    [Header ("Movement, Eyes, and Rotations")]
    public float moveSpeed =1f;
    // public float turnSpeed =1f;    
    public float lookSphereCastRadius =1f;
    public float lookRange =40f;
    public float searchDuration = 4f;   
    public float searchingTurnSpeed = 120f;
    public float idleTime = 3f;

    [Header ("Damage")]
    public float attackRange =1f;
    public float attackRate =1f;
    public float attackForce =15f;
    public int attackDamage =50;

}
