using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Add also requirement for targeting
[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private InputActions controls;
    private Vector2 moveInput;
    private bool commandMode = false;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        controls = new InputActions();
        playerMovement = GetComponent<PlayerMovement>();
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
    }

    private void HandleCmdOn(InputAction.CallbackContext context)
    {
        if (!commandMode)
        {
            commandMode = true;

        }
    }

    private void HandleExecuteCom(InputAction.CallbackContext context)
    {
        commandMode = false;
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

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Command Mode " + commandMode);
        playerMovement.Move(moveInput);
        Debug.Log(moveInput);

    }


}
