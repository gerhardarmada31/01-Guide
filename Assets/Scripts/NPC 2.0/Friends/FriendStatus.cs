using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendStatus : NPCStatus
{
    //friends will power
    private int wP;
    public bool FriendIsTalking { get; set; }
    private FriendDialogue MyFriend;
    private PlayerDialogue playerDialogue;
    private GoalItem goalItem;

    private void Awake()
    {
        wP = TotalHp;
        MyFriend = this.GetComponent<FriendDialogue>();
        goalItem = this.GetComponent<GoalItem>();
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

    protected override void ObjectTargeted(GameObject obj, GameObject player, int sentSp)
    {
        //most likely do a switch case for sp checks
        if (obj == this.gameObject)
        {
            Debug.Log("sentSp is " + sentSp);
            PlayerObj = player;
            if (sentSp <= SpCheckLvl1)
            {

            }
            else
            {
                Debug.Log("strongSauce");
            }

            Debug.Log("CHECK ITEM");

            playerDialogue = player.GetComponent<PlayerDialogue>();
            playerDialogue.IsInDialogue = true;
            DialogueController.Instance.dialogueRunner.StartDialogue(MyFriend.YarnStartNode);
            FriendIsTalking = true;


            if (goalItem != null)
            {
                goalItem.CheckItem();
            }
        }
    }


    // private void OnDisable()
    // {
    //     DialogueEvent.currentDialogueEvent.onFriendTalking -= FriendTalk;
    // }

}
