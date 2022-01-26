using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.EventSystems;
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
    private float tabInput;
    float tabVal = 1;
    private float yMoveInput;
    private Vector2 itemMove;
    private float mouseWheelAxis;
    private bool commandMode = false;
    private int[] tabList = new int[3];

    // private bool menuOn = false;
    [SerializeField] private UnityEvent callMenu;
    [SerializeField] private UnityEvent itemTab;
    [SerializeField] private UnityEvent statsTab;
    [SerializeField] private UnityEvent optionsTab;
    [SerializeField] private UnityEvent closeItemNotification;

    private bool isItemNotifyOn = false;
    private bool isMenuOn = false;
    private bool itemModeOn = false;
    private PlayerMovement playerMovement;
    private PlayerStatus playerStatus;
    private CommandRange commandRange;
    private PlayerDialogue playerDialogue;

    private void Awake()
    {
        controls = new InputActions();
        playerMovement = GetComponent<PlayerMovement>();
        playerStatus = GetComponent<PlayerStatus>();
        playerDialogue = GetComponent<PlayerDialogue>();
        commandRange = GetComponentInChildren<CommandRange>();
        if (commandRange != null)
        {
            commandRange.transform.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {

        //Subscribring from the inputaction events
        InventoryEvent.currentInventoryEvent.onPlayerItemNotify += HandleItemNotifyInput;

        //MENU
        controls.PlayerCharacter.Menu.performed += HandleMenu;
        controls.UI.Tab.performed += HandleTab;
        controls.PlayerCharacter.CloseNotify.performed += HandleItemNotifyUI;
        controls.UI.MenuNav.performed += HandleMenuSelect;
        controls.UI.MenuNav.canceled += HandleMenuZero => itemMove = Vector2.zero;

        //SPRINT
        controls.PlayerCharacter.Sprint.performed += HandleSprint;
        controls.PlayerCharacter.Sprint.canceled += HandleStopSprint;

        //COMMAND RANGE
        controls.PlayerCharacter.CmdOn.performed += HandleCmdOn;
        controls.PlayerCharacter.CmdOff.performed += HandleCmdOff;
        controls.PlayerCharacter.ExecuteCom.performed += HandleExecuteCom;
        controls.PlayerCharacter.CmdSelect.performed += HandleCmdSelect;
        controls.PlayerCharacter.StackSp.performed += HandheldStackingSP;

        //MOVEMENT
        controls.PlayerCharacter.Jump.performed += HandleJump;
        controls.PlayerCharacter.Move.performed += HandleMove => moveInput = HandleMove.ReadValue<Vector2>();
        controls.PlayerCharacter.YMove.performed += HandleYMovement => yMoveInput = HandleYMovement.ReadValue<float>();
        controls.PlayerCharacter.YMove.canceled += HandleYMovement => yMoveInput = 0;
        controls.PlayerCharacter.Move.canceled += HandleMove => moveInput = Vector2.zero;
        controls.Enable();

    }

    private void HandleItemNotifyInput(bool _isItemOn)
    {
        isItemNotifyOn = true;
        controls.PlayerCharacter.Menu.Disable();
        Debug.Log("ITEM PLAYER NOTIFIED");
    }

    private void HandleMenuSelect(InputAction.CallbackContext context)
    {
        if (itemModeOn)
        {
            // scrollEvent.Invoke();
            itemMove = context.ReadValue<Vector2>();
            float scrollMove = itemMove.y;
            InventoryEvent.currentInventoryEvent.ItemNavigate(scrollMove);
        }
    }

    private void HandleItemNotifyUI(InputAction.CallbackContext context)
    {
        if (isItemNotifyOn)
        {
            Debug.Log("ITEM PRESSED");
            isItemNotifyOn = false;
            controls.PlayerCharacter.Menu.Enable();
            //unity event that listens if the ItemNotification Is Active
            closeItemNotification.Invoke();
        }
    }



    #region MENU
    private void HandleMenu(InputAction.CallbackContext context)
    {
        Debug.Log("ASDASDASD");
        isMenuOn = !isMenuOn;
        if (isMenuOn)
        {
            tabVal = 1;
            itemModeOn = true;
        }
        else
        {
            itemModeOn = false;
        }
        callMenu.Invoke();
    }



    private void HandleTab(InputAction.CallbackContext context)
    {
        // int index;

        //make an int array called tabs[2]
        //convert float tabInput to int?
        if (isMenuOn)
        {
            tabInput = context.ReadValue<float>();
            Mathf.Round(tabInput);
            tabVal = ((tabVal + tabInput) % tabList.Length);
            if (tabVal <= 0)
            {
                tabVal = tabList.Length;
            }

            switch (tabVal)
            {
                case 1:
                    itemTab.Invoke();
                    itemModeOn = true;
                    break;

                case 2:
                    statsTab.Invoke();
                    itemModeOn = false;
                    break;

                case 3:
                    optionsTab.Invoke();
                    itemModeOn = false;
                    break;

                default:
                    Debug.LogError("Overlap. Tab value is more than 3");
                    break;
            }
        }
        else
        {
            tabVal = 1;
        }


    }

    #endregion


    #region SPRINT
    private void HandleStopSprint(InputAction.CallbackContext context)
    {
        Debug.Log("Stop Sprinting");
        playerMovement.Sprint(false);
    }

    private void HandleSprint(InputAction.CallbackContext context)
    {
        //PlayerMovement.Sprint();
        Debug.Log("Sprinting!!");
        playerMovement.Sprint(true);
    }
    #endregion


    #region  COMMANDRANGE
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


    private void HandleCmdOff(InputAction.CallbackContext context)
    {
        commandMode = false;
        commandRange.gameObject.SetActive(false);
        playerStatus.StackSP = 0;
        controls.PlayerCharacter.Jump.Enable();
        playerStatus.spiritCommandRange = false;
    }
    private void HandleCmdOn(InputAction.CallbackContext context)
    {
        //Create a condition if the spirit point is >= to 1
        if (!commandMode && playerStatus.CurrentSP >= 1)
        {
            commandMode = true;
            playerStatus.spiritCommandRange = true;
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

    #endregion


    #region  MOVEMENT
    private void HandleJump(InputAction.CallbackContext context)
    {
        playerMovement.Jump();
    }

    #endregion




    private void OnDisable()
    {
        //MENU
        controls.PlayerCharacter.Menu.performed -= HandleMenu;
        controls.UI.Tab.performed -= HandleTab;
        controls.PlayerCharacter.CloseNotify.performed -= HandleItemNotifyUI;
        controls.UI.MenuNav.performed -= HandleMenuSelect;
        controls.UI.MenuNav.canceled -= HandleMenuZero => itemMove = Vector2.zero;


        //SPRINT
        controls.PlayerCharacter.Sprint.performed += HandleSprint;
        controls.PlayerCharacter.Sprint.canceled += HandleStopSprint;


        //COMMAND RNAGE
        controls.PlayerCharacter.CmdOn.performed -= HandleCmdOn;
        controls.PlayerCharacter.CmdOff.performed -= HandleCmdOff;
        controls.PlayerCharacter.ExecuteCom.performed -= HandleExecuteCom;
        controls.PlayerCharacter.CmdSelect.performed -= HandleCmdSelect;
        // controls.PlayerCharacter.DialogueKeys.performed -= HandleDialogue => dialogueInputs = HandleDialogue.ReadValue<float>();
        // controls.PlayerCharacter.ContinueDialogue.performed -= HandleDialogueNext;

        //MOVEMENT
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
        if (commandRange != null)
        {
            if (!isItemNotifyOn)
            {


                if (!playerStatus.IsHit)
                {
                    if (!commandMode && !freeMove)
                    {
                        playerMovement.Move(moveInput);

                        if (!playerDialogue.IsInDialogue && isMenuOn == false)
                        {
                            controls.PlayerCharacter.Sprint.Enable();
                            controls.PlayerCharacter.Jump.Enable();
                            controls.PlayerCharacter.CmdOn.Enable();
                            controls.PlayerCharacter.Move.Enable();
                        }
                        else
                        {
                            controls.PlayerCharacter.Move.Disable();
                            controls.PlayerCharacter.Jump.Disable();
                            controls.PlayerCharacter.CmdOn.Disable();
                        }
                    }
                    else if (freeMove)
                    {
                        playerMovement.FreeMoveMode(moveInput, yMoveInput);
                    }
                    // Debug.Log(moveInput);
                }
            }
            else
            {
                Debug.Log("HELLOSASDASD");
                controls.PlayerCharacter.CmdOn.Disable();
                controls.PlayerCharacter.Jump.Disable();
                controls.PlayerCharacter.Move.Disable();
                var itemNotifyUI = EventSystem.current.currentSelectedGameObject;

                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(itemNotifyUI);
            }
            commandRange.CommandMode();
            // Debug.Log("MODE CURRENTLY SELECTED " + EventSystem.current.currentSelectedGameObject);

        }


    }

    public void FreeMove()
    {
        freeMove = !freeMove;
    }




}
