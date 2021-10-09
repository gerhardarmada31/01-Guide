using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpiritUI : MonoBehaviour
{
    [SerializeField] private PlayerStatus pStats;
    private CommandRange commandRange;
    [SerializeField] private Image spRAmount;
    [SerializeField] private TMP_Text spCountText;
    private float maxSprate;
    private int spCount;
    private int maxSpCount;

    void Awake()
    {
        // spRAmount = GetComponent<Image>();
        maxSprate = pStats.playerStats.maxSpRate;


        maxSpCount = pStats.playerStats.maxSp;
    }

    public void SpiritRateUI(float _spRate, float _maxSpRate, int _spCount, int _maxSpCount)
    {
        if (_spCount != _maxSpCount)
        {
            spRAmount.fillAmount = Mathf.InverseLerp(spRAmount.fillAmount, _maxSpRate, _spRate);
        }
        else if (_spCount >= _maxSpCount)
        {
            spRAmount.fillAmount = 0;
        }
    }

    public void SpiritCount(int _spCount)
    {
        spCountText.SetText(_spCount.ToString());
        Debug.Log("commandMode off");
    }
    public void SpiritStack()
    {
        //get the stack or spcost value 
    }
    // Update is called once per frame
    // void Update()
    // {
    //     spCount = pStats.CurrentSP;
    //     spRAmount.fillAmount = Mathf.InverseLerp(spRAmount.fillAmount, maxSprate, pStats.spRate);
    //     spCountText.SetText(spCount.ToString());

    //     //Once spRate is max and currentSp is not max then spAmount goes back 0
    //     if (spRAmount.fillAmount == maxSprate && spCount < maxSpCount)
    //     {
    //         spRAmount.fillAmount = 0;
    //     }
    //     else if (spCount >= maxSpCount)
    //     {
    //         Debug.Log("MAX sp");
    //     }


    //     //if spRate is max and currentSp is max then fillamount = 1
    // }


}
