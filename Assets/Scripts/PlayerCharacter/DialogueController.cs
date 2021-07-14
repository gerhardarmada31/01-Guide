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

    public DialogueRunner dialogueRunner;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
