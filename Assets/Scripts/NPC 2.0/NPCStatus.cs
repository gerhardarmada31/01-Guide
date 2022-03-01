using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// , ITakeDamage
public abstract class NPCStatus : MonoBehaviour, ITargetInfo
{
    //Create an scriptable object later... for separation stuff
    // public int hp = 3;
    // public int attack = 1;



    protected int spChecklvl1;
    protected int spChecklvl2;

    [Header("Target Info")]
    [SerializeField] protected string targetName;
    [SerializeField] protected string targetAct01;
    [SerializeField] protected string targetAct02;

    public NPCAttributes nPCAttributes;



    //PROPS
    private GameObject playerObj;
    public GameObject PlayerObj
    {
        get { return playerObj; }
        set { playerObj = value; }
    }
    private int totalhp;
    public int TotalHp
    {
        get { return totalhp = nPCAttributes.hp; }
    }

    // private int spCheckLvl1;
    public int SpCheckLvl1
    {
        get { return spChecklvl1; }
        set { spChecklvl1 = value; }
    }

    // private int spCheckLvl2;
    public int SpCheckLvl2
    {
        get { return spChecklvl2; }
        set { spChecklvl2 = value; }
    }

    public bool IsStun { get; set; }
    public bool canStun { get; set; }
    public bool IsHit { get; set; }

    private float staggerTime;
    public float StaggerTime
    {
        get { return staggerTime; }
        set { staggerTime = value; }
    }
    protected virtual void Start()
    {
        canStun = nPCAttributes.canStun;
        staggerTime = nPCAttributes.staggerTimer;
        spChecklvl1 = nPCAttributes.spCheck1;
        spChecklvl2 = nPCAttributes.spCheck2;
        TargetEventSystem.currentTarget.onConfirmTargetSelect += ObjectTargeted;
    }
    protected abstract void ObjectTargeted(GameObject myObj, GameObject playerObj, int spCheck);


    protected virtual void OnDisable()
    {
        TargetEventSystem.currentTarget.onConfirmTargetSelect -= ObjectTargeted;
    }

    public void KILL_ALL()
    {
        Debug.Log("killall");
        // Destroy(this);
    }

    void ITargetInfo.GetTargetInfo(out string _targetName, out string act01, out string act02, out int spReq01, out int spReq02)
    {
        _targetName = targetName;
        act01 = targetAct01;
        act02 = targetAct02;
        spReq01 = spChecklvl1;
        spReq02 = spChecklvl2;
    }
}
