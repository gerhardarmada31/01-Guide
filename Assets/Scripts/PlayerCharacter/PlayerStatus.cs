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
    private bool isInvunerable = false;



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
        currentHP = 3;
        playerStats.invuFrame = 1.5f;
        playerStats.maxHp = 3;
        playerStats.maxSp = 4;
        currentSP = 3;
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
        if (spRate >= playerStats.requiredSpRate)
        {
            currentSP++;
            spRate = 0;
        }
    }

    public void TakeDamage(int takeDamge)
    {
        if (isInvunerable == false)
        {
            currentHP -= takeDamge;
            StartCoroutine(InvuTime());
        }

        if (currentHP <= 0)
        {
            currentHP = 0;
        }
    }

    IEnumerator InvuTime()
    {
        isInvunerable = true;
        yield return new WaitForSeconds(playerStats.invuFrame);
        isInvunerable = false;
    }

    public void MoreHP()
    {
        currentHP = 99;
        playerStats.invuFrame = 300;
        playerStats.maxHp = 99;
    }

    public void MoreSP()
    {
        currentSP = 99;
        // stackSP = 99;
        playerStats.maxSp = 99;

    }

    public void MorePower()
    {
        playerStats.attackPoint = 99;
    }

    public void LessCheats()
    {
        currentHP = 3;
        playerStats.invuFrame = 1.5f;
        playerStats.maxHp = 3;
        playerStats.maxSp = 4;
        currentSP = 3;
    }
}
