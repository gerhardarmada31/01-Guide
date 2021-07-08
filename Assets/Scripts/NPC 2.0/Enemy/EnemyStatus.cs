using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : NPCStatus
{
    private int hp;
    private int spChecks;

    private void Awake()
    {
        hp = TotalHp;
    }
    // Update is called once per frame
    void Update()
    {
        Death();
    }

    // void OnEnable()
    // {
    // }


    protected override void OnDisable()
    {
        base.OnDisable();
        hp = TotalHp;
    }

    protected override void ObjectTargeted(GameObject obj, GameObject playerObj, int sentSp)
    {
        Debug.Log("Break");
        //only work if time is moving.
        if (obj == this.gameObject && obj != null)
        {
            PlayerObj = playerObj;
            hp -= sentSp;
            Debug.Log($"{this.gameObject} took {sentSp} Damage");

            if (sentSp <= SpCheckLvl1)
            {
                Debug.Log("Weak sauce");
                //Change behaviour because of npcStateController
            }
            else if (sentSp >= SpCheckLvl2)
            {
                Debug.Log("strong Sauce");
            }
        }
    }

    public void Death()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    protected override void Start()
    {
        base.Start();
        Debug.Log("sup");
    }


}
