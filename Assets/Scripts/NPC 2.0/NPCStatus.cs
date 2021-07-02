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
    private bool spCheckLvl1;
    public bool SpCheckLvl1
    {
        get { return spCheckLvl1; }
    }

    private bool spCheckLvl2;
    public bool SpCheckLvl2
    {
        get { return spCheckLvl2; }
    }

    private void Awake()
    {

    }

    void Start()
    {
        TargetEventSystem.current.onConfirmTargetSelect += ObjectTargeted;
    }

    protected abstract void ObjectTargeted(GameObject arg1, GameObject arg2, int arg3);

    // Update is called once per frame
    void Update()
    {
        Death();
    }

    private void OnDisable()
    {
        TargetEventSystem.current.onConfirmTargetSelect -= ObjectTargeted;
    }

    public void Death()
    {
        if (nPCAttributes.hp <= 0)
        {
            Destroy(this.gameObject);
        }
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
