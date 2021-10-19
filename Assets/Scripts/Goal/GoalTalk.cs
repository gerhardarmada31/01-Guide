using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTalk : GoalBase
{
    // Start is called before the first frame update

    [SerializeField] string requiredFriendName;

    protected override void Start()
    {
        base.Start();
        GoalEvent.currentGoalEvent.onGoalTalk += TalkedFriend;
    }

    private void TalkedFriend(string _FriendName)
    {
        if (_FriendName == requiredFriendName)
        {
            Debug.Log("GOAL TALK WORKS");
            GoalEvent.currentGoalEvent.GoalComplete(goalTitle, true);
        }
    }

}
