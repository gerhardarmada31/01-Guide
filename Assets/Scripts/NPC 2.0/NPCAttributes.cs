using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/NPCAttributes", order = 0)]
public class NPCAttributes : ScriptableObject
{
    [Header("Movement, Eyes, and Rotations")]
    public float moveSpeed = 1f;
    // public float turnSpeed =1f;    
    public float lookSphereCastRadius = 1f;
    public float lookRange = 40f;
    public float searchDuration = 4f;
    public float searchingTurnSpeed = 120f;
    public float idleTime = 3f;

    [Header("Health and SpChecks")]
    
    public int hp = 1;
    public int spCheck1;
    public int spCheck2;

    [Header("Damage")]
    public float attackRange = 1f;
    public float attackRate = 1f;
    public float attackForce = 15f;
    public int attackDamage = 50;

}
