using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerManagerSO")]
public class PlayerCharacter_SO : ScriptableObject
{
    [Header ("Player Health and Spirit")]
    public int maxHp;
    public int maxSp;
    public float spRate;
    public float requiredSpRate;
    public float invuFrame;

    [Header ("Player Attacks")]
    public int attackPoint;
    public int totalDmg;

    [Header ("Player Movement")]
    public float moveSpeed;
    public float slideFriction;
    public float gravityScale;
    public float jumpHeight;
    public float castOffset;
    public float turnSpeed;


    [Header ("Player Inventory")]
    public int currentCoin;


    public Vector3 playerPosition;
    public bool hasTeleport = false;
    //public float playerUpBoost;

    //Jump point?
}
