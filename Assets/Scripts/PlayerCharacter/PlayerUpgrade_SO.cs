using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeData", menuName = "ScriptableObjects/PlayerUpgradeData")]
public class PlayerUpgrade_SO : ScriptableObject
{
    //The cost is coins
    //upgrade cost of HP
    [Header("Player Health Cost")]
    public int lvl1CostHp;
    public int lvl2CostHp;
    public int lvl3CostHp;
    public int lvl4CostHp;   

    [Header("Player Health Upgrade")]
    public int lvl1UpgradeHp;
    public int lvl2UpgradeHp;
    public int lvl3UpgradeHp;
    public int lvl4UpgradeHp;


    //upgrade cost Atk
    [Header("Player Attack Cost")]
    public int lvl1CostAtk;
    public int lvl2CostAtk;
    public int lvl3CostAtk;
    public int lvl4CostAtk;

    [Header("Player Attack Upgrade")]
    public int lvl1UpgradeAtk;
    public int lvl2UpgradeAtk;
    public int lvl3UpgradeAtk;
    public int lvl4UpgradeAtk;
    //upgrade cost SP
    [Header("Player Sp Cost")]
    public int lvl1CostSp;
    public int lvl2CostSp;
    public int lvl3CostSp;
    public int lvl4CostSp;

    [Header("Player Sp Upgrade")]
    public int lvl1UpgradeSp;
    public int lvl2UpgradeSp;
    public int lvl3UpgradeSp;
    public int lvl4UpgradeSp;

    //upgrade cost SPrate
    [Header("Player SpRate Cost")]
    public int lvl1CostSpRate;
    public int lvl2CostSpRate;
    public int lvl3CostSpRate;
    public int lvl4CostSpRate;

    [Header("Player SpRate Upgrade")]
    public float lvl1UpgradeSpRate;
    public float lvl2UpgradeSpRate;
    public float lvl3UpgradeSpRate;
    public float lvl4UpgradeSpRate;
}
