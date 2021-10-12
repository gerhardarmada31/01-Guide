using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour, ITakeDamage, ICollector
{
    public PlayerCharacter_SO playerStats;

    private int currentHP;
    private int currentSP;
    private int totalDmg;
    private int stackSP = 0;
    private bool isInvunerable = false;
    private WaitForSeconds regenSec;


    // public dropType currentDropType;
    [SerializeField] private HealthUI hpUI;
    [SerializeField] private SpiritUI spUI;
    public bool spiritCommandRange { get; set; }
    //PROPS
    public float spRate { get; set; }

    public bool IsSprinting { get; set; }
    public bool IsMoving { get; set; }
    public bool SpStop { get; set; }

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
        set { currentSP = value; }
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

    private void Awake()
    {


        playerStats.currentSpeed = playerStats.normalSpeed;
        regenSec = new WaitForSeconds(playerStats.spRegen);
        spRate = playerStats.spRate;

        playerStats.invuFrame = 1.5f;
        playerStats.maxHp = 3;
        playerStats.maxSp = 4;

        //del this later
        playerStats.currentCoin = 0;
        currentHP = 3;
        currentSP = 3;

        hpUI.DrawHeart(currentHP, playerStats.maxHp);
    }

    void Start()
    {
        currentHP = playerStats.maxHp;
    }

    void Update()
    {
        //set a condition if commandRange is not on
        SpiritCharge();
        HealthSystem();
        spUI.SpiritRateUI(spRate, playerStats.maxSpRate, currentSP, playerStats.maxSp);

        //If commandRange is true go to spirit Stacking else spirit count
        if (spiritCommandRange)
        {
            spUI.SpiritCount(stackSP);
        }
        else
        {
            spUI.SpiritCount(currentSP);
        }
        // spUI.SpiritCount(currentSP,);
        // Debug.Log($"current Stack {StackSP}");
    }

    private void HealthSystem()
    {
        if (currentHP <= 0)
        {
            Destroy(gameObject, 0.5f);
        }
    }

    public void SpiritStack()
    {
        // deduct current sp based on stackSP and executing this through commandRange confirm
        currentSP = currentSP - (1 * (stackSP + 1));
        stackSP = 0;
    }

    // public void SpiritCharge(bool _isSprinting, bool _isJumping)
    public void SpiritCharge()
    {

        //Checking if the player is moving or sprinting.
        if (IsSprinting == true && IsMoving == true)
        {
            spRate -= (playerStats.spDrain * Time.deltaTime);

            Debug.Log("DEDUCT SPRATE");
            SpStop = true;

            if (currentSP <= 0)
            {
                spRate = 0.1f;
            }

            if (spRate < 0)
            {
                currentSP--;
                spRate = (playerStats.maxSpRate - 0.001f);
            }
        }
        else if (SpStop == false)
        {
            spRate += (playerStats.spRegen * Time.deltaTime);

            if (spRate >= playerStats.maxSpRate)
            {
                if (currentSP >= playerStats.maxSp)
                {
                    spRate = (playerStats.maxSpRate - 0.001f);
                }
                else
                {
                    spRate = 0;
                    currentSP++;
                }
            }
        }

    }




    public void TakeDamage(int takeDamge)
    {
        if (isInvunerable == false)
        {
            currentHP -= takeDamge;
            hpUI.DrawHeart(currentHP, playerStats.maxHp);
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

    #region Cheats

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

    #endregion



    //An interface that collects from objects that are collectable
    public void GetCollectDrop(int dropAmount, dropType _dropType)
    {
        switch (((int)_dropType))
        {
            case 0:
                playerStats.currentCoin += dropAmount;
                break;

            case 1:
                if (currentHP < playerStats.maxHp)
                {
                    currentHP += dropAmount;
                }
                hpUI.DrawHeart(currentHP, playerStats.maxHp);
                break;

            case 2:
                if (currentSP < playerStats.maxSp)
                {
                    currentSP += dropAmount;
                    if (currentSP >= playerStats.maxSp)
                    {
                        currentSP = playerStats.maxSp;
                        spRate = (playerStats.maxSpRate - 0.001f);
                    }
                }


                break;

            default:
                Debug.LogError("Value is not in the dropType");
                break;

        }
    }
}
