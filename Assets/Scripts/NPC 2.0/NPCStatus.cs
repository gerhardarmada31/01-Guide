using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// , ITakeDamage
public abstract class NPCStatus : MonoBehaviour, ITakeDamage
{
    //Create an scriptable object later... for separation stuff
    // public int hp = 3;
    // public int attack = 1;

    public NPCAttributes nPCAttributes;
    [SerializeField] private NPCStateController controller;


    //PROPS
    private int totalhp;
    public int TotalHp
    {
        get { return totalhp = nPCAttributes.hp; }
    }

    private int spCheckLvl1;
    public int SpCheckLvl1
    {
        get { return spCheckLvl1 = nPCAttributes.spCheck1; }
        set { spCheckLvl1 = value;}
    }

    private int spCheckLvl2;
    public int SpCheckLvl2
    {
        get { return spCheckLvl2 = nPCAttributes.spCheck2; }
        set { spCheckLvl2 = value; }
    }


    void Start()
    {
        TargetEventSystem.current.onConfirmTargetSelect += ObjectTargeted;
    }

    protected abstract void ObjectTargeted(GameObject arg1, GameObject arg2, int arg3);

    private void OnDisable()
    {
        TargetEventSystem.current.onConfirmTargetSelect -= ObjectTargeted;
    }



    public void TakeDamage(int takeDamge)
    {
        // hp -= takeDamge;
    }

    public void KILL_ALL()
    {
        Debug.Log("killall");
        // Destroy(this);
    }
}
