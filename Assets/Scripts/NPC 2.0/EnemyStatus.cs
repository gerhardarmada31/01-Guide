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

    private PlayerStatus playerDmg;

    // public PlayerCharacter_SO playerStats;

    // Start is called before the first frame update
    void Start()
    {
        TargetEventSystem.current.onConfirmTargetSelect += ObjectTargeted;
    }

    private void ObjectTargeted(GameObject obj, GameObject playerObj)
    {

        //only work if time is moving.
        if (obj == this.gameObject)
        {
            playerDmg = playerObj.GetComponent<PlayerStatus>();
            if (playerDmg != null)
            {
                hp -= playerDmg.TotalDmg;
            }
            Debug.Log($"{this.gameObject} took {playerDmg.TotalDmg} Damage");
            // hp-= playerStats.totalDmg;
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
}
