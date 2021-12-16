using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsUI : MonoBehaviour
{
    // private PlayerStatus pStatus;
    public PlayerCharacter_SO playerStatus;
    [SerializeField] private TMP_Text maxHP, maxSP, attack, spRate;

    private void Awake()
    {
        // pStatus = FindObjectOfType<PlayerStatus>();
        // if (pStatus == null)
        // {
        //     Debug.LogError("Player status is empty on UI, set something to it");
        // }
    }

    void Start()
    {
        Stats();
    }

    //Getting called from any of the upgrade buttons
    public void Stats()
    {
        maxHP.SetText(playerStatus.maxHp.ToString());
        maxSP.SetText(playerStatus.maxSp.ToString());
        attack.SetText(playerStatus.attackPoint.ToString());

        var speed = (int)playerStatus.spRegen;
        spRate.SetText(speed.ToString());
    }
}
