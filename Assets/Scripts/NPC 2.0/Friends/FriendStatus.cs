using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendStatus : NPCStatus
{
    //friends will power
    private int wP;

    private void Awake()
    {
        wP = TotalHp;
    }

    private void Update()
    {

    }
    // [SerializeField] private
    protected override void ObjectTargeted(GameObject obj, GameObject player, int sentSp)
    {
        //most likely do a switch case for sp checks
        if (obj == this.gameObject)
        {
            PlayerObj = player;
            if (sentSp <= SpCheckLvl1)
            {
                Debug.Log("weakSauce");
            }
            else
            {
                Debug.Log("strongSauce");
            }
        }
    }

}
