using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour, ITakeDamage, ICollector, ICoinReward
{
    public PlayerCharacter_SO playerStats;

    private int maxHp;
    private int currentHP;
    private int currentSP;
    private int totalDmg;
    private int stackSP = 0;
    private bool isInvunerable = false;
    private WaitForSeconds regenSec;


    // public dropType currentDropType;
    [Header("UI Implement")]
    [SerializeField] private HealthUI hpUI;
    [SerializeField] private SpiritUI spUI;
    //PROPS

    public bool spiritCommandRange { get; set; }
    public float spRate { get; set; }
    public bool IsSprinting { get; set; }
    public bool IsHit { get; set; }
    public bool IsMoving { get; set; }
    public bool IsJumping { get; set; }
    public bool SpStop { get; set; }

    public int TotalDmg
    {
        get { return totalDmg + (playerStats.attackPoint + StackSP); }
    }

    public int CurrentHP
    {
        get { return currentHP; }
    }


    public int MaxHp
    {
        get { return maxHp; }
        set { maxHp = value; }
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
        // playerStats.maxHp = 3;
        playerStats.maxSp = 4;


        //del this later
        // playerStats.currentCoin = 100;
        maxHp = playerStats.maxHp;
        currentHP = 3;
        currentSP = 3;

        hpUI.DrawHeart(currentHP, maxHp);
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

    //Updates the Health UI
    public void UpgradeHealthUI()
    {
        maxHp = playerStats.maxHp;
        // currentHP = maxHp;
        hpUI.DrawHeart(currentHP, maxHp);
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
        if (IsSprinting == true && IsMoving == true && IsJumping == false)
        {


            spRate -= (playerStats.spDrain * Time.deltaTime);
            SpStop = true;
            Debug.Log("DEDUCT SPRATE");

            if (spRate < 0)
            {
                if (currentSP <= 0)
                {
                    CurrentSP = 0;
                    spRate = 0.01f;
                    playerStats.currentSpeed = playerStats.normalSpeed;
                }
                else
                {
                    currentSP--;
                    spRate = (playerStats.maxSpRate - 0.001f);
                }

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
            hpUI.DrawHeart(currentHP, maxHp);
            //Start a coroutine of damageTime
            StartCoroutine(DamageTime());
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

    //MoveStops to for the damage of the player
    IEnumerator DamageTime()
    {
        IsHit = true;
        yield return new WaitForSeconds(0.2f);
        IsHit = false;

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

    public void GetCoinReward(int coinAmount)
    {
        playerStats.currentCoin += coinAmount;
    }
}
