using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendDialogue : MonoBehaviour
{
    public string YarnStartNode { get{return yarnStartNode;} }
    [SerializeField] GameObject chatBubble;
    [SerializeField] string yarnStartNode ="Start";
    [SerializeField] YarnProgram yarnDialogue;
    [SerializeField] SpeakerSO speakerData;
    // Start is called before the first frame update
    void Start()
    {
        // chatBubble.SetActive(false);
        DialogueController.Instance.dialogueRunner.Add(yarnDialogue);
        DialogueController.Instance.AddSpeaker(speakerData);
    }

}
