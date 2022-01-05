using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TargetText : MonoBehaviour
{
    [SerializeField] private TMP_Text nameValue;
    [SerializeField] private TMP_Text actValue;

    private void OnEnable()
    {
    }

    private void Start()
    {
        TargetEventSystem.currentTarget.onTargetInfoUpdate += UpdateTargetInfo;

    }

    private void UpdateTargetInfo(string _name, string _act, bool _cmdOn)
    {
        if (_cmdOn)
        {
            nameValue.SetText(_name);
            actValue.SetText(_act);
        }
        else
        {
            nameValue.SetText("N/A");
            actValue.SetText("N/A");
        }
    }

    private void OnDisable()
    {
        TargetEventSystem.currentTarget.onTargetInfoUpdate -= UpdateTargetInfo;
    }
}
