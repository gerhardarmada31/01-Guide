using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerUpgrades : MonoBehaviour
{
    private PlayerStatus pStatus;
    [SerializeField] private PlayerUpgrade_SO pUpgrade;

    [Header("HP")]
    private int hpCurrentLvl = 0;
    private int currentHPCost = 0;
    public int[] hpCostArray;
    private int[] hpUpgradeArray;

    // HP PROPS
    public int HPCurrentLvl
    {
        get { return hpCurrentLvl; }
        set { hpCurrentLvl = value; }
    }
    public int CurrentHPCost
    {
        get { return currentHPCost; }
        set { currentHPCost = value; }
    }

    [Header("Attack")]
    private int atkCurrentLvl = 0;
    private int currentAtkCost = 0;
    private int[] atkCostArray;
    private int[] atkUpgradeArray;

    // ATK PROPS
    public int ATKCurrentLvl
    {
        get { return atkCurrentLvl; }
        set { atkCurrentLvl = value; }
    }
    public int CurrentAtkCost
    {
        get { return currentAtkCost; }
        set { currentAtkCost = value; }
    }

    [Header("SP")]
    private int spCurrentLvl = 0;
    private int currentSPCost = 0;

    private int[] spCostArray;
    private int[] spUpgradeArray;

    //SP PROPS
    public int SPCurrentLvl
    {
        get { return spCurrentLvl; }
        set { spCurrentLvl = value; }
    }
    public int CurrentSPCost
    {
        get { return currentSPCost; }
        set { currentSPCost = value; }
    }

    [Header("SP Rate")]
    private int spRateCurrentLvl = 0;
    private int currentSpRateCost = 0;
    private int[] spRateCostArray;
    private float[] spRateUpgradeArray;
    //SPRATE PROPS
    public int SPRateCurrentLvl
    {
        get { return spRateCurrentLvl; }
        set { spRateCurrentLvl = value; }
    }
    public int CurrentSpRateCost
    {
        get { return currentSpRateCost; }
        set { currentSpRateCost = value; }
    }

    private bool canUpgrade;
    // Start is called before the first frame update


    private void Awake()
    {
        pStatus = this.GetComponent<PlayerStatus>();

        // setting the Arrays to the Upgrade SO
        hpCostArray = new int[] { pUpgrade.lvl1CostHp, pUpgrade.lvl2CostHp, pUpgrade.lvl3CostHp, pUpgrade.lvl4CostHp };
        hpUpgradeArray = new int[] { pUpgrade.lvl1UpgradeHp, pUpgrade.lvl2UpgradeHp, pUpgrade.lvl3UpgradeHp, pUpgrade.lvl4UpgradeHp };
        atkCostArray = new int[] { pUpgrade.lvl1CostAtk, pUpgrade.lvl2CostAtk, pUpgrade.lvl3CostAtk, pUpgrade.lvl4CostAtk };
        atkUpgradeArray = new[] { pUpgrade.lvl1UpgradeAtk, pUpgrade.lvl2UpgradeAtk, pUpgrade.lvl3UpgradeAtk, pUpgrade.lvl4UpgradeAtk };
        spCostArray = new int[] { pUpgrade.lvl1CostSp, pUpgrade.lvl2CostSp, pUpgrade.lvl3CostSp, pUpgrade.lvl4CostSp };
        spUpgradeArray = new int[] { pUpgrade.lvl1UpgradeAtk, pUpgrade.lvl2UpgradeAtk, pUpgrade.lvl3UpgradeAtk, pUpgrade.lvl4UpgradeAtk };
        spRateCostArray = new int[] { pUpgrade.lvl1CostSpRate, pUpgrade.lvl2CostSpRate, pUpgrade.lvl3CostSpRate, pUpgrade.lvl4CostSpRate };
        spRateUpgradeArray = new float[] { pUpgrade.lvl1UpgradeSpRate, pUpgrade.lvl2UpgradeSpRate, pUpgrade.lvl3UpgradeSpRate, pUpgrade.lvl4UpgradeSpRate };

        CurrentHPCost = hpCostArray[0];
        CurrentSPCost = spCostArray[0];
        CurrentAtkCost = atkCostArray[0];
        CurrentSpRateCost = spRateCostArray[0];

    }

    void Start()
    {
        InventoryEvent.currentInventoryEvent.onPlayerSPUpgrade += SPUpgradeEvent;
    }



    //A function that upgrades the values in Int Based
    public int UpgradingInt(int[] _typeArray, int _currentTypeLvl, int[] _typeCostArray, int _pStat)
    {
        if (_currentTypeLvl >= _typeArray.Length)
        {
            Debug.Log("CANNOT LEVEL UP ANYMORE");
        }
        else
        {
            for (int i = 0; i < _typeArray.Length; i++)
            {
                if (pStatus.playerStats.currentCoin >= _typeCostArray[i])
                {
                    if (_currentTypeLvl == i)
                    {
                        _pStat += _typeArray[i];
                        pStatus.playerStats.currentCoin -= _typeCostArray[i];
                        canUpgrade = true;
                        // Debug.Log($"The current Level is {_currentTypeLvl}");

                        return _pStat;
                    }

                }

            }
        }
        return _pStat;
    }

    //A function that upgrades the values in Float Based
    public float UpgradingFloat(float[] _typeArray, int _currentTypeLvl, int[] _typeCostArray, int _currentCost, float _pStat)
    {

        if (_currentTypeLvl >= _typeArray.Length)
        {
            Debug.Log("CANNOT LEVEL UP ANYMORE");
        }
        else
        {
            for (int i = 0; i < _typeArray.Length; i++)
            {
                if (pStatus.playerStats.currentCoin >= _typeCostArray[i])
                {
                    if (_currentTypeLvl == i)
                    {
                        _pStat += _typeArray[i];
                        pStatus.playerStats.currentCoin -= _typeCostArray[i];
                        canUpgrade = true;
                        return _pStat;
                    }

                }
            }
        }
        return _pStat;
    }

    //Updates and checks the cost of the Upgrade
    public int CostCheck(int _currentLvl, int[] _costArray, int _currentCost)
    {
        for (int i = 0; i < _costArray.Length; i++)
        {
            if (_currentLvl == i)
            {
                _currentCost = _costArray[i];
            }
        }
        if (_currentLvl >= _costArray.Length)
        {
            Debug.Log("Reached Max Level");
            //SEND EVENT to the COST text
        }

        return _currentCost;
    }

    //This function will be called via onclick on UI
    public void HPUpgradeEvent()
    {
        pStatus.playerStats.maxHp = UpgradingInt(hpUpgradeArray, hpCurrentLvl, hpCostArray, pStatus.playerStats.maxHp);

        // Debug.Log("current Level" + hpCurrentLvl);
        if (canUpgrade)
        {
            hpCurrentLvl++;
            // for (int i = 0; i < hpCostArray.Length; i++)
            // {
            //     if (hpCurrentLvl == i)
            //     {
            //         currentHPCost = hpCostArray[i];
            //     }
            // }

            // if (hpCurrentLvl >= hpCostArray.Length)
            // {
            //     Debug.Log("MAX LEVEL REACHED");
            // }
            currentHPCost = CostCheck(hpCurrentLvl, hpCostArray, currentHPCost);
            Debug.Log("currentCost" + currentHPCost);
            canUpgrade = false;
        }
    }

    private void SPUpgradeEvent(int _spAmount)
    {
        pStatus.playerStats.maxSp += _spAmount;
    }

    public void AtkUpgradeEvent()
    {
        pStatus.playerStats.attackPoint = UpgradingInt(atkUpgradeArray, atkCurrentLvl, atkCostArray, pStatus.playerStats.attackPoint);

        if (canUpgrade)
        {
            atkCurrentLvl++;
            for (int i = 0; i < atkCostArray.Length; i++)
            {
                if (atkCurrentLvl == i)
                {
                    currentAtkCost = atkCostArray[i];
                }
            }

            if (atkCurrentLvl >= atkCostArray.Length)
            {
                Debug.Log("Reached Max Level");
            }
            canUpgrade = false;
        }
    }


    public void SpRateUpgrade()
    {
        pStatus.playerStats.spRegen = UpgradingFloat(spRateUpgradeArray, spRateCurrentLvl, spRateCostArray, currentSpRateCost, pStatus.playerStats.spRegen);
        if (canUpgrade)
        {
            spRateCurrentLvl++;
            for (int i = 0; i < spRateCostArray.Length; i++)
            {
                if (spRateCurrentLvl == i)
                {
                    CurrentSpRateCost = spRateCostArray[i];
                }
            }
            if (spRateCurrentLvl >= spRateCostArray.Length)
            {
                Debug.Log("Reached Max Level");
            }
            canUpgrade = false;
        }
    }

    void OnDisable()
    {
        InventoryEvent.currentInventoryEvent.onPlayerSPUpgrade -= SPUpgradeEvent;
    }


}
