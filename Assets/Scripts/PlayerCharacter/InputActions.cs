// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerCharacter/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""PlayerCharacter"",
            ""id"": ""a88756bb-3218-4783-9762-c062c5b73075"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""848aefa2-734c-4852-a496-6063727871fc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c0583e71-4147-45df-932b-bd8995a6d4ba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ExecuteCom"",
                    ""type"": ""Button"",
                    ""id"": ""ca1bdb8d-f0e4-47a6-805f-ebb203b3619c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CmdOff"",
                    ""type"": ""Button"",
                    ""id"": ""186143e2-78d0-4ce1-b53c-d497671e993d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CmdOn"",
                    ""type"": ""Button"",
                    ""id"": ""08f8a21b-dab7-4b84-999c-ff3a60a4a693"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CmdSelect"",
                    ""type"": ""Button"",
                    ""id"": ""2f1335a5-99bc-447f-9aa1-90f1cc352f61"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StackSp"",
                    ""type"": ""Value"",
                    ""id"": ""0238c7b8-6154-4ef6-864b-0bcbbbc0c5b8"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""f3af0f6d-2e8b-4264-9611-78ebc556a49c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=0.5),Clamp(min=-1,max=1)"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""65d1755a-d1e4-4b6f-b0ee-a3eac76eb08a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""95c5430a-8a18-4106-93e5-cb5eace363c8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6114afb4-9c94-4f0a-bf5c-13aebc699e24"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6793dffb-5f0d-4aba-8850-c87e7a796ff4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""105765b9-47fe-4fa8-b21f-25662dc9aba0"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b4b001f-a333-4800-b1e2-418869c85588"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CmdOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76267eb9-84c8-4176-bc11-2e09363567f7"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CmdOff"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""e7e4b0a7-82a6-4501-9ad9-66babb6b612e"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ExecuteCom"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""5a890b90-44e2-43d6-8082-67f983fc3908"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ExecuteCom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""f0c2000b-d9a7-4e05-ba92-162b592f9a58"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ExecuteCom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""243175b0-8f84-4b1d-ab4e-57a66519aaf7"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CmdSelect"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""17969292-8a94-42ca-b99f-56efd1f586cb"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CmdSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a1b07ff2-ad52-437d-9b9e-146be23c42a1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CmdSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""99d11d5b-2a8f-41ee-81f0-2172ed019f88"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StackSp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerCharacter
        m_PlayerCharacter = asset.FindActionMap("PlayerCharacter", throwIfNotFound: true);
        m_PlayerCharacter_Move = m_PlayerCharacter.FindAction("Move", throwIfNotFound: true);
        m_PlayerCharacter_Jump = m_PlayerCharacter.FindAction("Jump", throwIfNotFound: true);
        m_PlayerCharacter_ExecuteCom = m_PlayerCharacter.FindAction("ExecuteCom", throwIfNotFound: true);
        m_PlayerCharacter_CmdOff = m_PlayerCharacter.FindAction("CmdOff", throwIfNotFound: true);
        m_PlayerCharacter_CmdOn = m_PlayerCharacter.FindAction("CmdOn", throwIfNotFound: true);
        m_PlayerCharacter_CmdSelect = m_PlayerCharacter.FindAction("CmdSelect", throwIfNotFound: true);
        m_PlayerCharacter_StackSp = m_PlayerCharacter.FindAction("StackSp", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // PlayerCharacter
    private readonly InputActionMap m_PlayerCharacter;
    private IPlayerCharacterActions m_PlayerCharacterActionsCallbackInterface;
    private readonly InputAction m_PlayerCharacter_Move;
    private readonly InputAction m_PlayerCharacter_Jump;
    private readonly InputAction m_PlayerCharacter_ExecuteCom;
    private readonly InputAction m_PlayerCharacter_CmdOff;
    private readonly InputAction m_PlayerCharacter_CmdOn;
    private readonly InputAction m_PlayerCharacter_CmdSelect;
    private readonly InputAction m_PlayerCharacter_StackSp;
    public struct PlayerCharacterActions
    {
        private @InputActions m_Wrapper;
        public PlayerCharacterActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerCharacter_Move;
        public InputAction @Jump => m_Wrapper.m_PlayerCharacter_Jump;
        public InputAction @ExecuteCom => m_Wrapper.m_PlayerCharacter_ExecuteCom;
        public InputAction @CmdOff => m_Wrapper.m_PlayerCharacter_CmdOff;
        public InputAction @CmdOn => m_Wrapper.m_PlayerCharacter_CmdOn;
        public InputAction @CmdSelect => m_Wrapper.m_PlayerCharacter_CmdSelect;
        public InputAction @StackSp => m_Wrapper.m_PlayerCharacter_StackSp;
        public InputActionMap Get() { return m_Wrapper.m_PlayerCharacter; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerCharacterActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerCharacterActions instance)
        {
            if (m_Wrapper.m_PlayerCharacterActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnJump;
                @ExecuteCom.started -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnExecuteCom;
                @ExecuteCom.performed -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnExecuteCom;
                @ExecuteCom.canceled -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnExecuteCom;
                @CmdOff.started -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnCmdOff;
                @CmdOff.performed -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnCmdOff;
                @CmdOff.canceled -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnCmdOff;
                @CmdOn.started -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnCmdOn;
                @CmdOn.performed -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnCmdOn;
                @CmdOn.canceled -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnCmdOn;
                @CmdSelect.started -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnCmdSelect;
                @CmdSelect.performed -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnCmdSelect;
                @CmdSelect.canceled -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnCmdSelect;
                @StackSp.started -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnStackSp;
                @StackSp.performed -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnStackSp;
                @StackSp.canceled -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnStackSp;
            }
            m_Wrapper.m_PlayerCharacterActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @ExecuteCom.started += instance.OnExecuteCom;
                @ExecuteCom.performed += instance.OnExecuteCom;
                @ExecuteCom.canceled += instance.OnExecuteCom;
                @CmdOff.started += instance.OnCmdOff;
                @CmdOff.performed += instance.OnCmdOff;
                @CmdOff.canceled += instance.OnCmdOff;
                @CmdOn.started += instance.OnCmdOn;
                @CmdOn.performed += instance.OnCmdOn;
                @CmdOn.canceled += instance.OnCmdOn;
                @CmdSelect.started += instance.OnCmdSelect;
                @CmdSelect.performed += instance.OnCmdSelect;
                @CmdSelect.canceled += instance.OnCmdSelect;
                @StackSp.started += instance.OnStackSp;
                @StackSp.performed += instance.OnStackSp;
                @StackSp.canceled += instance.OnStackSp;
            }
        }
    }
    public PlayerCharacterActions @PlayerCharacter => new PlayerCharacterActions(this);
    public interface IPlayerCharacterActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnExecuteCom(InputAction.CallbackContext context);
        void OnCmdOff(InputAction.CallbackContext context);
        void OnCmdOn(InputAction.CallbackContext context);
        void OnCmdSelect(InputAction.CallbackContext context);
        void OnStackSp(InputAction.CallbackContext context);
    }
}
