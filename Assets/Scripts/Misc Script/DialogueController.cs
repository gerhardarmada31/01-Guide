using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Yarn.Unity;
using System;

public class DialogueController : SingletonParent<DialogueController>
{
    // [SerializeField] Image speakerPortrait;
    [SerializeField] TextMeshProUGUI txt_Dialogue, txt_SpeakerName;
    [SerializeField] Image speakerBox;

    public DialogueRunner dialogueRunner;
    private GameObject friendObject;
    Dictionary<string, SpeakerSO> speakerDatabase = new Dictionary<string, SpeakerSO>();

    private void Awake()
    {
        dialogueRunner = GetComponent<DialogueRunner>();
        dialogueRunner.AddCommandHandler("SetSpeaker", SetSpeakerInfo);
        dialogueRunner.AddCommandHandler("SetItemGoal", GoalItem);
        dialogueRunner.AddCommandHandler("SetTalkGoal", GoalTalk);
        dialogueRunner.AddCommandHandler("GetReward", GoalReward);
    }
    private void Start()
    {
        TargetEventSystem.currentTarget.onConfirmTargetSelect += FriendTargeted;
    }

    private void GoalReward(string[] parameters)
    {
        Debug.Log("REWARD!!!");
        GoalBase goalReward = friendObject.GetComponent<GoalBase>();
        goalReward.GoalReward(parameters);
        Debug.Log("COIN UI CALLING");
        var coinUI = FindObjectOfType<CoinUI>();
        coinUI.UpdateCoin();
    }

    private void GoalItem(string[] info)
    {
        GoalEvent.currentGoalEvent.GoalItem(txt_SpeakerName.text);

    }

    private void GoalTalk(string[] info)
    {
        GoalEvent.currentGoalEvent.GoalTalk(txt_SpeakerName.text);
        // Debug.Log(txt_SpeakerName.text);

    }


    private void FriendTargeted(GameObject friend, GameObject arg2, int arg3)
    {
        friendObject = friend;
    }

    // Start is called before the first frame update
    public void AddSpeaker(SpeakerSO data)
    {
        if (speakerDatabase.ContainsKey(data.speakerName))
        {
            Debug.LogWarningFormat("Attempting to add {0} into speaker database, but it already exist", data.speakerName);
            return;
        }

        speakerDatabase.Add(data.speakerName, data);
    }

    public void SetSpeakerInfo(string[] info)
    {
        string speaker = info[0];

        if (speakerDatabase.TryGetValue(speaker, out SpeakerSO data))
        {
            txt_SpeakerName.text = data.speakerName;
            Debug.Log(txt_SpeakerName.text);
            speakerBox.sprite = data.DialougeBox;
            return;
        }
        Debug.LogErrorFormat("Could not set speaker info for unknown speaker {0}", speaker);
    }

    public void FriendTalking(bool FriendTalking)
    {
        DialogueEvent.currentDialogueEvent.FriendTalking(friendObject, FriendTalking);
    }
}
