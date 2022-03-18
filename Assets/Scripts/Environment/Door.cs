using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : GoalEnvironment, ITargetInfo
{
    private FriendDialogue MyFriend;
    private PlayerDialogue playerDialogue;
    public bool ObjectIsTalking { get; set; }

    private void Awake()
    {
        MyFriend = this.GetComponent<FriendDialogue>();
    }
    void ITargetInfo.GetTargetInfo(out string _targetName, out string act01, out string act02, out int spReq01, out int spReq02)
    {
        _targetName = targetName;
        act01 = targetAct01;
        act02 = targetAct02;
        spReq01 = spChecklvl1;
        spReq02 = spChecklvl2;
    }

    protected override void Start()
    {
        base.Start();
        // TargetEventSystem.currentTarget.onConfirmTargetSelect += ObjectConfirmed;
        // DialogueEvent.currentDialogueEvent.onFriendTalking += FriendTalk;
    }

    // private void FriendTalk(GameObject friendObj, bool friendTalking)
    // {
    //     if (friendObj == this.gameObject)
    //     {
    //         ObjectIsTalking = friendTalking;
    //         // Debug.Log("stop walking" + friendObj);
    //     }
    // }

    protected override void ActObjectLvl2()
    {

        //Destroy the door
        //Gets the player dialogue from the goalenvironment parent sets isdialogue to false
        if (MyFriend != null && this.gameObject != null)
        {
            // gameObject.SetActive(false);
            Destroy(this.gameObject);
            Debug.Log("DOOR OPEN");
        }

        // Debug.Log("IS DIALOGUE to " + playerDialogue.IsInDialogue);

    }

    protected override void ActObjectLvl1()
    {
        if (MyFriend != null)
        {
            playerDialogue = player.GetComponent<PlayerDialogue>();
            playerDialogue.IsInDialogue = true;
            DialogueController.Instance.dialogueRunner.StartDialogue(MyFriend.YarnStartNode);
        }

    }
}
