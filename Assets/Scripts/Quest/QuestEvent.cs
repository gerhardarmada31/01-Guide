using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestEvent : MonoBehaviour
{
    public static QuestEvent currentQuestEvent;

    // Start is called before the first frame update
    void Awake()
    {
        currentQuestEvent = this;
    }

    // public event Action<>
}
