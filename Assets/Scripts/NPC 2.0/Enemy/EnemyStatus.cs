using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : NPCStatus
{


    // Update is called once per frame
    void Update()
    {

    }

    protected override void ObjectTargeted(GameObject obj, GameObject playerObj, int sentSp)
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
            nPCAttributes.hp -= sentSp;
            Debug.Log($"{this.gameObject} took {sentSp} Damage");

            if (sentSp >= 2)
            {
                //Change behaviour because of npcStateController
                Debug.Log("Break");
            }
        }
    }
}
