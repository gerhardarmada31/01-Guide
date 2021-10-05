using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerManagerSO")]
public class PlayerCharacter_SO : ScriptableObject
{
    [Header("Player Health")]
    public int maxHp;

    public float invuFrame;

    [Header("Player Attacks")]
    public int attackPoint;
    public int totalDmg;

    [Header("Player Spirit")]
    public int maxSp;
    public float maxSpRate;
    public float spRate;
    [Range(0,50)] public float spRegen;
    [Range(0,50)] public float spDrain;

    [Header("Player Movement")]
    public float currentSpeed;
    public float normalSpeed;
    public float sprintSpeed;
    public float slideFriction;
    public float gravityScale;
    public float jumpHeight;
    public float castOffset;
    public float turnSpeed;



    [Header("Player Inventory")]
    public int currentCoin;


    public Vector3 playerPosition;
    public bool hasTeleport = false;
    //public float playerUpBoost;

    //Jump point?
}
