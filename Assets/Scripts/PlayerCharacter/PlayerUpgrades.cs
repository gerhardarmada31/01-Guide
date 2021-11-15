using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    private PlayerStatus pStatus;
    [SerializeField] private PlayerUpgrade_SO pUpgrade;

    [Header("HP")]
    private int hpCurrentLvl = 0;
    private int[] hpCostArray;
    private int[] hpUpgradeArray;

    [Header("Attack")]
    private int atkCurrentLvl = 0;
    private int[] atkCostArray;
    private int[] atkUpgradeArray;

    [Header("SP")]
    private int spCurrentLvl = 0;
    private int[] spCostArray;
    private int[] spUpgradeArray;

    [Header("SP Rate")]
    private int spRateCurrentLvl = 0;
    private int[] spRateCostArray;
    private float[] spRateUpgradeArray;
    private bool canUpgrade;
    // Start is called before the first frame update


    private void Awake()
    {
        pStatus = this.GetComponent<PlayerStatus>();
    }

    void Start()
    {

        // setting the Arrays to the Upgrade SO
        hpCostArray = new int[] { pUpgrade.lvl1CostHp, pUpgrade.lvl2CostHp, pUpgrade.lvl3CostHp, pUpgrade.lvl4CostHp };
        hpUpgradeArray = new int[] { pUpgrade.lvl1UpgradeHp, pUpgrade.lvl2UpgradeHp, pUpgrade.lvl3UpgradeHp, pUpgrade.lvl4UpgradeHp };
        atkCostArray = new int[] { pUpgrade.lvl1CostAtk, pUpgrade.lvl2CostAtk, pUpgrade.lvl3CostAtk, pUpgrade.lvl4CostAtk };
        atkUpgradeArray = new[] { pUpgrade.lvl1UpgradeAtk, pUpgrade.lvl2UpgradeAtk, pUpgrade.lvl3UpgradeAtk, pUpgrade.lvl4UpgradeAtk };
        spCostArray = new int[] { pUpgrade.lvl1CostSp, pUpgrade.lvl2CostSp, pUpgrade.lvl3CostSp, pUpgrade.lvl4CostSp };
        spUpgradeArray = new int[] { pUpgrade.lvl1UpgradeAtk, pUpgrade.lvl2UpgradeAtk, pUpgrade.lvl3UpgradeAtk, pUpgrade.lvl4UpgradeAtk };
        spRateCostArray = new int[] { pUpgrade.lvl1CostSpRate, pUpgrade.lvl2CostSpRate, pUpgrade.lvl3CostSpRate, pUpgrade.lvl4CostSpRate };
        spRateUpgradeArray = new float[] { pUpgrade.lvl1UpgradeSpRate, pUpgrade.lvl2UpgradeSpRate, pUpgrade.lvl3UpgradeSpRate, pUpgrade.lvl4UpgradeSpRate };
    }

    //A function that upgrades the values in Int Based
    public int UpgradingInt(int[] _typeArray, int _currentTypeLvl, int[] _typeCostArray, int _pStat)
    {

        for (int i = 0; i < _typeArray.Length; i++)
        {
            if (pStatus.playerStats.currentCoin >= _typeCostArray[i])
            {
                if (_currentTypeLvl == i)
                {
                    _pStat += _typeArray[i];
                    pStatus.playerStats.currentCoin -= _typeCostArray[i];
                    // _currentTypeLvl += 1;
                    canUpgrade = true;

                    Debug.Log($"The current Type level is {_currentTypeLvl}");
                    return _pStat;
                }

            }
        }
        return _pStat;
    }

    //A function that upgrades the values in Float Based
    public float UpgradingFloat(float[] _typeArray, int _currentTypeLvl, int[] _typeCostArray, float _pStat)
    {

        for (int i = 0; i < _typeArray.Length; i++)
        {
            if (pStatus.playerStats.currentCoin >= _typeCostArray[i])
            {
                if (_currentTypeLvl == i)
                {
                    _pStat += _typeArray[i];
                    pStatus.playerStats.currentCoin -= _typeCostArray[i];
                    _currentTypeLvl += 1;
                    i = _currentTypeLvl;

                    return _pStat;
                }

            }
        }
        return _pStat;
    }

    //This function will be called via onclick on UI
    public void HPUpgradeEvent()
    {
        pStatus.playerStats.maxHp = UpgradingInt(hpUpgradeArray, hpCurrentLvl, hpCostArray, pStatus.playerStats.maxHp);

        if (canUpgrade)
        {
            hpCurrentLvl++;
            canUpgrade = false;
        }
    }

    public void AtkUpgradeEvent()
    {
        pStatus.playerStats.attackPoint = UpgradingInt(atkUpgradeArray, atkCurrentLvl, atkCostArray, pStatus.playerStats.attackPoint);

        if (canUpgrade)
        {
            atkCurrentLvl++;
            canUpgrade = false;
        }
    }

    public void SpUpgradeEvent()
    {
        pStatus.playerStats.maxSp = UpgradingInt(spUpgradeArray, spCurrentLvl, spCostArray, pStatus.playerStats.maxSp);

        if (canUpgrade)
        {
            spCurrentLvl++;
            canUpgrade = false;
        }
    }

    public void SpRateUpgrade()
    {

        pStatus.playerStats.spRegen = UpgradingFloat(spRateUpgradeArray, spRateCurrentLvl, spRateCostArray, pStatus.playerStats.spRegen);

        if (canUpgrade)
        {
            spRateCurrentLvl++;
            canUpgrade = false;
        }
    }
}
