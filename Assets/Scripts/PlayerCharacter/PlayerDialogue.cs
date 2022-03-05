using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogue : MonoBehaviour
{
    //Const
    private FriendDialogue friendNpc;
    private CommandRange commandRange;

    [SerializeField] SpeakerSO speakerData;
    private bool isInDialogue = false;
    //Property
    public bool IsInDialogue
    {
        get { return isInDialogue; }
        set { isInDialogue = value; }
    }


    private void Start()
    {
        commandRange = GetComponentInChildren<CommandRange>();
        DialogueController.Instance.AddSpeaker(speakerData);
    }
    // public string YarnStartNode { get{return yarnStartNode;} }


    public void SelectingDialogueOptions(int dialogueOption)
    {
        isInDialogue = true;
    }

    public void ConfirmedDialogue(bool isContinuePressed)
    {
        isInDialogue = true;
    }

    public void OnDialogueEnd()
    {
        isInDialogue = false;
    }
}
