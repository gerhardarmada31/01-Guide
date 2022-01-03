using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendStatus : NPCStatus
{
    //friends will power
    private int wP;
    public bool FriendIsTalking { get; set; }

    private void Awake()
    {
        wP = TotalHp;
    }

    protected override void Start()
    {
        base.Start();
        // Debug.Log("sup");
        DialogueEvent.currentDialogueEvent.onFriendTalking += FriendTalk;
        // FriendIsTalking =false;
    }

    private void FriendTalk(GameObject friendObj, bool friendTalking)
    {
        //Stop moving based on the value here
        if (friendObj == this.gameObject)
        {
            FriendIsTalking = friendTalking;
            // Debug.Log("stop walking" + friendObj);
        }
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
                var _goalItem = this.GetComponent<GoalItem>();

                if (_goalItem != null)
                {
                    _goalItem.CheckItem();
                }
            }
            else
            {
                Debug.Log("strongSauce");
            }
        }
    }

}
