using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class DebugController : MonoBehaviour
{
    private InputActions inputControl;
    private bool showConsole = false;
    private string input;

    public static DebugCommand KILL_ALL;
    public List<object> commandList;
    [SerializeField] UnityEvent onCompleteCommand;

    private void Awake()
    {
        inputControl = new InputActions();
        KILL_ALL = new DebugCommand("kill_all", "Removes all heroes from the Scene", "kill_all", () =>
         {
             // sends events to objects here but check if the its using the kill_all?
             Debug.Log("killAll");
             onCompleteCommand.Invoke();
         }
        );
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
    private void OnReturn(InputAction.CallbackContext context)
    {
        if (showConsole)
        {
            Debug.Log("enter");
            HandleInput();
            input = "";
        }
    }

    private void HandleInput()
    {
        // for (int i = 0; i < commandList.Count; i++)
        // {
        //     DebugCommandBase commandBase = commandList[i] as DebugCommandBase;

        //     if (input.Contains(commandBase.CommandId))
        //     {
        //         if (commandList[i] as DebugCommand != null)
        //         {
        //             (commandList[i] as DebugCommand).Invoke();
        //         }
        //     }
        // }
    }

    private void OnToggleDebug(InputAction.CallbackContext context)
    {
        showConsole = !showConsole;
        Debug.Log($"Debug is on {showConsole}");
    }

    private void OnGUI()
    {
        if (!showConsole)
        {
            return;
        }
        float y = 0f;

        GUI.Box(new Rect(0, y, Screen.width, 30), "");
        GUI.backgroundColor = new Color(0, 0, 0);
        input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);
    }

}
