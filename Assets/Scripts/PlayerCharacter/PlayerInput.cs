using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.InputSystem;
using UnityEngine.Events;

//Add also requirement for targeting
[RequireComponent(typeof(PlayerMovement), typeof(PlayerStatus))]
public class PlayerInput : MonoBehaviour
{

    //CONSTS
    private InputActions controls;
    private bool freeMove;
    private Vector2 moveInput;
    private float dialogueInputs;
    private float yMoveInput;
    private float mouseWheelAxis;
    private bool commandMode = false;

    // private bool menuOn = false;
    [SerializeField] private UnityEvent callMenu;
    private bool isMenuOn = false;
    private PlayerMovement playerMovement;
    private PlayerStatus playerStatus;
    private CommandRange commandRange;
    private PlayerDialogue playerDialogue;

    private void Awake()
    {
        controls = new InputActions();
        playerMovement = GetComponent<PlayerMovement>();
        playerStatus = GetComponent<PlayerStatus>();
        commandRange = GetComponentInChildren<CommandRange>();
        playerDialogue = GetComponent<PlayerDialogue>();
        if (commandRange != null)
        {
            commandRange.transform.gameObject.SetActive(false);
        }

    }

    private void OnEnable()
    {
        //Debug contro;
        //Subscribring from the inputaction events
        controls.PlayerCharacter.Menu.performed += HandleMenu;
        // controls.PlayerCharacter.Menu.canceled

        controls.PlayerCharacter.Sprint.performed += HandleSprint;
        controls.PlayerCharacter.Sprint.canceled += HandleStopSprint;
        controls.PlayerCharacter.CmdOn.performed += HandleCmdOn;
        controls.PlayerCharacter.CmdOff.performed += HandleCmdOff;
        controls.PlayerCharacter.ExecuteCom.performed += HandleExecuteCom;
        controls.PlayerCharacter.CmdSelect.performed += HandleCmdSelect;
        controls.PlayerCharacter.StackSp.performed += HandheldStackingSP;
        // controls.PlayerCharacter.StackSp.canceled += HandheldStackingSP => playerStatus.StackSP = 0;

        // controls.PlayerCharacter.DialogueKeys.performed += HandleDialogueSelection => dialogueInputs = HandleDialogueSelection.ReadValue<float>();
        // controls.PlayerCharacter.ContinueDialogue.performed += HandleDialogueNext;
        controls.PlayerCharacter.Jump.performed += HandleJump;
        controls.PlayerCharacter.Move.performed += HandleMove => moveInput = HandleMove.ReadValue<Vector2>();
        controls.PlayerCharacter.YMove.performed += HandleYMovement => yMoveInput = HandleYMovement.ReadValue<float>();
        controls.PlayerCharacter.YMove.canceled += HandleYMovement => yMoveInput = 0;
        controls.PlayerCharacter.Move.canceled += HandleMove => moveInput = Vector2.zero;
        controls.Enable();

    }

    private void HandleStopSprint(InputAction.CallbackContext context)
    {
        Debug.Log("Stop Sprinting");
    }

    private void HandleSprint(InputAction.CallbackContext context)
    {
        //PlayerMovement.Sprint();
        Debug.Log("Sprinting!!");
        playerMovement.Sprint();
    }

    private void HandleMenu(InputAction.CallbackContext context)
    {
        isMenuOn = !isMenuOn;
        callMenu.Invoke();
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
        // Debug.Log("Jump");
        playerMovement.Jump();
    }

    private void HandleCmdOff(InputAction.CallbackContext context)
    {
        commandMode = false;
        commandRange.gameObject.SetActive(false);
        playerStatus.StackSP = 0;
        controls.PlayerCharacter.Jump.Enable();
    }

    private void HandleCmdOn(InputAction.CallbackContext context)
    {
        //Create a condition if the spirit point is >= to 1
        if (!commandMode && playerStatus.CurrentSP >= 1)
        {
            commandMode = true;

            commandRange.gameObject.SetActive(true);
            controls.PlayerCharacter.Jump.Disable();
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
        controls.PlayerCharacter.Menu.performed -= HandleMenu;

        controls.PlayerCharacter.Sprint.performed += HandleSprint;
        controls.PlayerCharacter.Sprint.canceled += HandleStopSprint;

        controls.PlayerCharacter.CmdOn.performed -= HandleCmdOn;
        controls.PlayerCharacter.CmdOff.performed -= HandleCmdOff;
        controls.PlayerCharacter.ExecuteCom.performed -= HandleExecuteCom;
        controls.PlayerCharacter.CmdSelect.performed -= HandleCmdSelect;
        // controls.PlayerCharacter.DialogueKeys.performed -= HandleDialogue => dialogueInputs = HandleDialogue.ReadValue<float>();
        // controls.PlayerCharacter.ContinueDialogue.performed -= HandleDialogueNext;


        controls.PlayerCharacter.Move.performed -= HandleMove => moveInput = HandleMove.ReadValue<Vector2>();
        controls.PlayerCharacter.YMove.performed -= HandleYMovement => yMoveInput = HandleYMovement.ReadValue<float>();
        controls.PlayerCharacter.YMove.canceled -= HandleYMovement => yMoveInput = 0;
        controls.PlayerCharacter.Move.canceled -= HandleMove => moveInput = Vector2.zero;
        controls.PlayerCharacter.Jump.performed -= HandleJump;
        controls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (!commandMode && !freeMove)
        {
            if (!playerDialogue.IsInDialogue && isMenuOn == false)
            {
                playerMovement.Move(moveInput);
                controls.PlayerCharacter.Sprint.Enable();
                controls.PlayerCharacter.Jump.Enable();
            }
            else
            {
                controls.PlayerCharacter.Jump.Disable();
            }
        }
        else if (freeMove)
        {
            playerMovement.FreeMoveMode(moveInput, yMoveInput);
        }
        // Debug.Log(moveInput);
        commandRange.CommandMode();

    }

    public void FreeMove()
    {
        freeMove = !freeMove;
    }




}
