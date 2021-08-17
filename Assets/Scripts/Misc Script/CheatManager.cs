using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class CheatManager : MonoBehaviour
{
    private InputActions inputControl;
    private string input;
    [SerializeField]
    private bool isPlayerTyping = false;

    [SerializeField]
    private string currentString = "";

    [SerializeField]
    private List<CheatCodeInstance> cheatCodeList = new List<CheatCodeInstance>();
    void Start()
    {
        Cursor.visible = true;

    }
    private void Awake()
    {
        inputControl = new InputActions();
    }

    void OnEnable()
    {
        inputControl.CheatController.ToggleDebug.performed += OnToggleDebug;
        inputControl.CheatController.Return.performed += OnReturn;
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.CheatController.ToggleDebug.performed -= OnToggleDebug;
        inputControl.CheatController.Return.performed -= OnReturn;
        inputControl.Disable();
    }
    //pressing the  accent key
    private void OnToggleDebug(InputAction.CallbackContext context)
    {
        isPlayerTyping = !isPlayerTyping;
        if (isPlayerTyping)
        {
            Cursor.visible = true;
            input = "";
        }
        else
        {
            // Cursor.visible = false;
        }
    }

    private void OnGUI()
    {
        if (!isPlayerTyping)
        {
            return;
        }
        float y = 0f;

        GUI.Box(new Rect(0, y, Screen.width, 30), "");
        GUI.backgroundColor = new Color(0, 0, 0);
        input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);
    }

    private void OnReturn(InputAction.CallbackContext context)
    {
        if (isPlayerTyping)
        {
            currentString = input;
            CheckCheat(currentString);
        }
        Time.timeScale = 1;
     //   Cursor.visible = false;
        isPlayerTyping = !isPlayerTyping;
    }

    private bool CheckCheat(string _input)
    {
        foreach (CheatCodeInstance code in cheatCodeList)
        {
            if (_input == code.code)
            {
                code.cheatEvent?.Invoke();
                return true;
            }
        }
        return false;
    }
}


[System.Serializable]
public class CheatCodeInstance
{
    public string code;
    public UnityEvent cheatEvent;
}
