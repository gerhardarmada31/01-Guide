using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    [SerializeField] TMP_Text coinValue;
    [SerializeField] PlayerCharacter_SO playerCoin;

    private void Start()
    {
        UpdateCoin();
    }

    public void UpdateCoin()
    {
        coinValue.SetText(playerCoin.currentCoin.ToString());
    }
}
