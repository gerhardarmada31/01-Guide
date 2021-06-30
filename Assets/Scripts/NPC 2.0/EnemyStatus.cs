using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// , ITakeDamage
public class EnemyStatus : MonoBehaviour, ITakeDamage
{
    //Create an scriptable object later... for separation stuff
    public int hp = 3;
    public int attack = 5;

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

    private PlayerStatus playerDmg;
    void Start()
    {
        TargetEventSystem.current.onConfirmTargetSelect += ObjectTargeted;
    }

    private void ObjectTargeted(GameObject obj, GameObject playerObj, int sentSp)
    {

        //only work if time is moving.
        if (obj == this.gameObject)
        {
            //playerDmg is now obsolete
            // playerDmg = playerObj.GetComponent<PlayerStatus>();
            // if (playerDmg != null)
            // {
            //     hp -= playerDmg.TotalDmg;
            // }
            hp -= sentSp;
            Debug.Log($"{this.gameObject} took {sentSp} Damage");

            if (sentSp >= 2)
            {
                //Change behaviour because of npcStateController
                Debug.Log("Break");
            }
        }
    }

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
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int takeDamge)
    {
        hp -= takeDamge;
    }

    public void KILL_ALL()
    {
        Debug.Log("killall");
        // Destroy(this);
    }
}
