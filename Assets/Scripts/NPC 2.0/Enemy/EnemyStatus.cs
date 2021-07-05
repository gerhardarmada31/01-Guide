using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : NPCStatus
{
    private int hp;

    private void Awake()
    {
        hp = TotalHp;
    }
    // Update is called once per frame
    void Update()
    {
        Death();
    }

    protected override void ObjectTargeted(GameObject obj, GameObject playerObj, int sentSp)
    {
        Debug.Log("Break");
        //only work if time is moving.
        if (obj == this.gameObject)
        {
            PlayerObj = playerObj;
            hp -= sentSp;
            Debug.Log($"{this.gameObject} took {sentSp} Damage");

            if (sentSp >= 2)
            {
                //Change behaviour because of npcStateController
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
}
