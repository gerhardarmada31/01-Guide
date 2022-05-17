using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class MainMenuInput : MonoBehaviour
{
    private InputActions controls;
    [SerializeField] private UnityEvent menuOnEvent;
    [SerializeField] private UnityEvent menuOffEvent;

    private void Awake()
    {
        controls = new InputActions();
    }


    private void OnEnable()
    {
        controls.MainMenuUI.MenuCmdOn.performed += ActivateButtons;
        controls.MainMenuUI.MenuCmdOn.canceled += DeactivateButtons;
        controls.Enable();
    }

    private void DeactivateButtons(InputAction.CallbackContext context)
    {
        menuOffEvent.Invoke();
    }

    private void ActivateButtons(InputAction.CallbackContext context)
    {
        Debug.Log("CLICK RIGHT!");
        menuOnEvent.Invoke();
    }

    private void OnDisable()
    {
        controls.MainMenuUI.MenuCmdOn.performed -= ActivateButtons;
        controls.MainMenuUI.MenuCmdOn.canceled += DeactivateButtons;
        controls.Disable();
    }

}
