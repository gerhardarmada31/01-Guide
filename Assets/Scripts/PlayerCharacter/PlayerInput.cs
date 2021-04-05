using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Add also requirement for targeting
[RequireComponent(typeof(PlayerMovement), typeof(PlayerStatus))]
public class PlayerInput : MonoBehaviour
{

    //CONSTS
    private InputActions controls;
    private Vector2 moveInput;
    private float mouseWheelAxis;
    private bool commandMode = false;
    private PlayerMovement playerMovement;
    private PlayerStatus playerStatus;
    private CommandRange commandRange;


    private void Awake()
    {
        controls = new InputActions();
        playerMovement = GetComponent<PlayerMovement>();
        playerStatus = GetComponent<PlayerStatus>();
        commandRange = GetComponentInChildren<CommandRange>();
        if (commandRange != null)
        {
            commandRange.transform.gameObject.SetActive(false);
        }

    }

    private void OnEnable()
    {
        //Subscribring from the inputaction events
        controls.PlayerCharacter.CmdOn.performed += HandleCmdOn;
        controls.PlayerCharacter.CmdOff.performed += HandleCmdOff;
        controls.PlayerCharacter.ExecuteCom.performed += HandleExecuteCom;
        controls.PlayerCharacter.CmdSelect.performed += HandleCmdSelect;
        controls.PlayerCharacter.StackSp.performed += HandheldStackingSP;
        // controls.PlayerCharacter.StackSp.canceled += HandheldStackingSP => playerStatus.StackSP = 0;

        controls.PlayerCharacter.Jump.performed += HandleJump;

        controls.PlayerCharacter.Move.performed += HandleMove => moveInput = HandleMove.ReadValue<Vector2>();
        controls.PlayerCharacter.Move.canceled += HandleMove => moveInput = Vector2.zero;
        controls.Enable();

    }

    private void HandheldStackingSP(InputAction.CallbackContext context)
    {
        //This stacks the value of the spirits
        if (commandMode)
        {
            mouseWheelAxis = context.ReadValue<float>();
            mouseWheelAxis = Mathf.Clamp(mouseWheelAxis, -1, 1);
            playerStatus.StackSP += Mathf.RoundToInt(mouseWheelAxis);
        }


    }

    private void HandleCmdSelect(InputAction.CallbackContext context)
    {
        if (commandMode && commandRange.SelectedObj != null)
        {
            commandRange.CommandSelect(context.ReadValue<float>());
        }
    }

    private void HandleJump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump");
        playerMovement.Jump();
    }

    private void HandleCmdOff(InputAction.CallbackContext context)
    {
        commandMode = false;
        commandRange.gameObject.SetActive(false);
        playerStatus.StackSP = 0;
    }

    private void HandleCmdOn(InputAction.CallbackContext context)
    {
        //Create a condition if the spirit point is >= to 1
        if (!commandMode && playerStatus.CurrentSP >= 1)
        {
            commandMode = true;
            commandRange.gameObject.SetActive(true);
        }
    }

    private void HandleExecuteCom(InputAction.CallbackContext context)
    {
        commandMode = false;
        commandRange.gameObject.SetActive(false);

        commandRange.ConfirmTarget();
    }


    private void OnDisable()
    {
        controls.PlayerCharacter.CmdOn.performed -= HandleCmdOn;
        controls.PlayerCharacter.CmdOff.performed -= HandleCmdOff;
        controls.PlayerCharacter.ExecuteCom.performed -= HandleExecuteCom;

        controls.PlayerCharacter.CmdSelect.performed -= HandleCmdSelect;

        controls.PlayerCharacter.Move.performed -= HandleMove => moveInput = HandleMove.ReadValue<Vector2>();
        controls.PlayerCharacter.Move.canceled -= HandleMove => moveInput = Vector2.zero;


        controls.PlayerCharacter.Jump.performed -= HandleJump;
        controls.Disable();
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Command Mode " + commandMode);
        if (!commandMode)
        {
            playerMovement.Move(moveInput);
        }

        Debug.Log(moveInput);
        commandRange.CommandMode();

    }


}
