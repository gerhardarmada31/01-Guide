using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Add also requirement for targeting
[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{

    //CONSTS
    private InputActions controls;
    private Vector2 moveInput;
    private bool commandMode = false;
    private PlayerMovement playerMovement;
    private CommandRange commandRange;


    private void Awake()
    {
        controls = new InputActions();
        playerMovement = GetComponent<PlayerMovement>();

        commandRange = GetComponentInChildren<CommandRange>();
        if (commandRange != null)
        {
            commandRange.transform.gameObject.SetActive(false);
        }

    }

    private void OnEnable()
    {
        controls.PlayerCharacter.cmdOn.performed += HandleCmdOn;
        controls.PlayerCharacter.cmdOff.performed += HandleCmdOff;
        controls.PlayerCharacter.ExecuteCom.performed += HandleExecuteCom;


        controls.PlayerCharacter.Jump.performed += HandleJump;

        controls.PlayerCharacter.Move.performed += HandleMove => moveInput = HandleMove.ReadValue<Vector2>();
        controls.PlayerCharacter.Move.canceled += HandleMove => moveInput = Vector2.zero;
        controls.Enable();

    }

    private void HandleJump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump");
        playerMovement.Jump();
    }

    private void HandleCmdOff(InputAction.CallbackContext context)
    {
        commandMode = false;
        if (!commandMode)
        {
        }
        commandRange.gameObject.SetActive(false);
    }

    private void HandleCmdOn(InputAction.CallbackContext context)
    {
        //Create a condition if the spirit point is >= to 1
        if (!commandMode)
        {
            commandMode = true;

        }
        commandRange.gameObject.SetActive(true);
    }

    private void HandleExecuteCom(InputAction.CallbackContext context)
    {
        commandMode = false;
        commandRange.gameObject.SetActive(false);
        commandRange.ConfirmTarget();
    }


    private void OnDisable()
    {
        controls.PlayerCharacter.cmdOn.performed -= HandleCmdOn;
        controls.PlayerCharacter.cmdOff.performed -= HandleCmdOff;
        controls.PlayerCharacter.ExecuteCom.performed -= HandleExecuteCom;

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
