using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Yarn.Unity;

public class DialogueController : SingletonParent<DialogueController>
{
    // [SerializeField] Image speakerPortrait;
    [SerializeField] TextMeshProUGUI txt_Dialogue, txt_SpeakerName;
    [SerializeField] Image speakerBox;

    public DialogueRunner dialogueRunner;
    Dictionary<string, SpeakerSO> speakerDatabase = new Dictionary<string, SpeakerSO>();

    private void Awake()
    {
        dialogueRunner = GetComponent<DialogueRunner>();
        dialogueRunner.AddCommandHandler("SetSpeaker", SetSpeakerInfo);
    }

    // Start is called before the first frame update
    public void AddSpeaker(SpeakerSO data)
    {
        if (speakerDatabase.ContainsKey(data.speakerName))
        {
            Debug.LogWarningFormat("Attempting to add {0} into speaker database, but it already exist", data.speakerName);
            return;
        }

        speakerDatabase.Add(data.speakerName,data);
        // speakerDatabase.Add

    }

    public void SetSpeakerInfo(string[] info)
    {
        string speaker = info[0];

        if (speakerDatabase.TryGetValue(speaker, out SpeakerSO data))
        {
            txt_SpeakerName.text = data.speakerName;
            speakerBox.sprite = data.DialougeBox;
            return;
        }
        Debug.LogErrorFormat("Could not set speaker info for unknown speaker {0}", speaker);
    }
}