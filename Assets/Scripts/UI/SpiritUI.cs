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
    [SerializeField] private TMP_Text spCountValue;
    [SerializeField] private TMP_Text spText;

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
        if (_spRate != _maxSpRate)
        {
            // Debug.Log("SP fill UI");
            spRAmount.fillAmount = Mathf.InverseLerp(spRAmount.fillAmount, _maxSpRate, _spRate);
        }
        else
        {
            spRAmount.fillAmount = 0;

        }
        // else if (_spCount >= _maxSpCount)
        // {
        // }


    }

    public void SpiritCount(int _spCount)
    {
        spCountValue.SetText((_spCount + 1).ToString());
        // Debug.Log("commandMode off");
    }

    public void CommandModeOn(bool _cmdOn)
    {
        if (_cmdOn)
        {
            spText.SetText("Stack");
        }
        else
        {
            spText.SetText("SP");
        }
    }


}
