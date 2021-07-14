using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogue : MonoBehaviour
{
    //Const
    private FriendDialogue friendNpc;
    private CommandRange commandRange;
    private bool isInDialogue = false;

    private void Start()
    {
        commandRange = GetComponentInChildren<CommandRange>();
    }
    // public string YarnStartNode { get{return yarnStartNode;} }
    //Property
    public bool IsInDialogue
    {
        get { return isInDialogue; }
        set { isInDialogue = value; }
    }

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
