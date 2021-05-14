using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStatus : MonoBehaviour, ITakeDamage
{
    public PlayerCharacter_SO playerStats;

    private int currentHP;
    private int currentSP;
    private int totalDmg;
    private int stackSP = 0;



    public float spRate { get; set; }
    public int TotalDmg
    {
        get { return totalDmg + (playerStats.attackPoint + StackSP); }
    }

    public int CurrentHP
    {
        get { return currentHP; }
    }

    public int CurrentSP
    {
        get { return currentSP; }
    }


    public int StackSP
    {
        get
        {
            return stackSP;
        }
        set
        {
            if (currentSP >= 1)
            {
                stackSP = Mathf.Clamp(value, 0, CurrentSP - 1);
            }
        }

    }

    void Start()
    {
        currentHP = playerStats.maxHp;
        spRate = playerStats.spRate;
    }

    void Update()
    {
        //set a condition if commandRange is not on
        SpiritCharge();
        HealthSystem();
        Debug.Log($"current Stack {StackSP}");
    }

    private void HealthSystem()
    {
        if (currentHP <= 0)
        {
            Destroy(gameObject, 0.5f);
        }
    }

    public void SpiritSystem()
    {
        // deduct current sp based on stackSP and executing this through commandRange confirm
        currentSP = currentSP - (1 * (stackSP + 1));
        stackSP = 0;
    }

    public void SpiritCharge()
    {
        if (currentSP != playerStats.maxSp)
        {
            spRate += Time.deltaTime;
        }
        if (spRate >= 3)
        {
            currentSP++;
            spRate = 0;
        }
    }

    public void TakeDamage(int takeDamge)
    {
        currentHP -= takeDamge;
        if (currentHP <= 0)
        {
            currentHP = 0;
        }
    }


}
