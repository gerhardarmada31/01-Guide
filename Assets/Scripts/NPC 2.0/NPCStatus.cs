using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// , ITakeDamage
public abstract class NPCStatus : MonoBehaviour
{
    //Create an scriptable object later... for separation stuff
    // public int hp = 3;
    // public int attack = 1;

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

    private int spCheckLvl1;
    public int SpCheckLvl1
    {
        get { return spCheckLvl1; }
        set { spCheckLvl1 = value; }
    }

    private int spCheckLvl2;
    public int SpCheckLvl2
    {
        get { return spCheckLvl2; }
        set { spCheckLvl2 = value; }
    }

    public bool IsStun { get; set; }
    public bool hasStun { get; set; }
    public bool IsHit { get; set; }

    private float staggerTime;
    public float StaggerTime
    {
        get { return staggerTime; }
        set { staggerTime = value; }
    }
    protected virtual void Start()
    {
        hasStun = nPCAttributes.hasStun;
        staggerTime = nPCAttributes.staggerTimer;
        spCheckLvl1 = nPCAttributes.spCheck1;
        spCheckLvl2 = nPCAttributes.spCheck2;
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
}
