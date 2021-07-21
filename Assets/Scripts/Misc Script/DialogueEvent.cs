using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogueEvent : MonoBehaviour
{
    public static DialogueEvent currentDialogueEvent;

    private void Awake()
    {
        currentDialogueEvent = this;
    }

    public event Action<GameObject, bool> onFriendTalking;

    public void FriendTalking(GameObject friendObj, bool isFriendTalking)
    {
        onFriendTalking?.Invoke(friendObj, isFriendTalking);
    }
}
