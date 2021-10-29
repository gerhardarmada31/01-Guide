using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    private PlayerStatus pStatus;
    // Start is called before the first frame update
    void Start()
    {
        pStatus = this.GetComponent<PlayerStatus>();
    }

    //This function will be called via onclick on UI
    public void UpgradeEvent()
    {
        // pStatus.playerStats.maxHp
    }
}
