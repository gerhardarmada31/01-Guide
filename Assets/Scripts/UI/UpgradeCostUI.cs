using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeCostUI : MonoBehaviour
{
    public PlayerUpgrades pCost;
    [SerializeField] private TMP_Text HPCost, SPCost, AtkCost, SPRateCost;
    private int costChecker;

    // Start is called before the first frame update
    void Start()
    {
        Cost();

        // costChecker = pCost.CurrentHPCost;
        // Debug.Log($"cost current HP{costChecker}");
    }

    public void Cost()
    {
        MaxChecker(pCost.HPCurrentLvl, HPCost, pCost.CurrentHPCost.ToString());
        MaxChecker(pCost.SPCurrentLvl, SPCost, pCost.CurrentSPCost.ToString());
        MaxChecker(pCost.ATKCurrentLvl, AtkCost, pCost.CurrentAtkCost.ToString());
        MaxChecker(pCost.SPRateCurrentLvl, SPRateCost, pCost.CurrentSpRateCost.ToString());
    }
    //sets text to MAX
    public void MaxCost(TMP_Text _maxText)
    {
        _maxText.SetText("MAX");
    }

    //Checking if the levelType is in the MAX
    public void MaxChecker(int _currentLvl, TMP_Text _costText, string _pCost)
    {
        if (_currentLvl >= 4)
        {
            MaxCost(_costText);
        }
        else
        {
            _costText.SetText(_pCost);
        }
    }

}
