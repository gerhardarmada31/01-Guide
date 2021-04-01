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
                    ""name"": ""ExecuteCom"",
                    ""type"": ""Button"",
                    ""id"": ""ca1bdb8d-f0e4-47a6-805f-ebb203b3619c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""cmdOn"",
                    ""type"": ""Button"",
                    ""id"": ""08f8a21b-dab7-4b84-999c-ff3a60a4a693"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""cmdOff"",
                    ""type"": ""Button"",
                    ""id"": ""186143e2-78d0-4ce1-b53c-d497671e993d"",
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
                    ""name"": """",
                    ""id"": ""5b4b001f-a333-4800-b1e2-418869c85588"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""cmdOn"",
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
                    ""action"": ""cmdOff"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
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
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerCharacter
        m_PlayerCharacter = asset.FindActionMap("PlayerCharacter", throwIfNotFound: true);
        m_PlayerCharacter_Move = m_PlayerCharacter.FindAction("Move", throwIfNotFound: true);
        m_PlayerCharacter_ExecuteCom = m_PlayerCharacter.FindAction("ExecuteCom", throwIfNotFound: true);
        m_PlayerCharacter_cmdOn = m_PlayerCharacter.FindAction("cmdOn", throwIfNotFound: true);
        m_PlayerCharacter_cmdOff = m_PlayerCharacter.FindAction("cmdOff", throwIfNotFound: true);
        m_PlayerCharacter_Jump = m_PlayerCharacter.FindAction("Jump", throwIfNotFound: true);
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
    private readonly InputAction m_PlayerCharacter_ExecuteCom;
    private readonly InputAction m_PlayerCharacter_cmdOn;
    private readonly InputAction m_PlayerCharacter_cmdOff;
    private readonly InputAction m_PlayerCharacter_Jump;
    public struct PlayerCharacterActions
    {
        private @InputActions m_Wrapper;
        public PlayerCharacterActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerCharacter_Move;
        public InputAction @ExecuteCom => m_Wrapper.m_PlayerCharacter_ExecuteCom;
        public InputAction @cmdOn => m_Wrapper.m_PlayerCharacter_cmdOn;
        public InputAction @cmdOff => m_Wrapper.m_PlayerCharacter_cmdOff;
        public InputAction @Jump => m_Wrapper.m_PlayerCharacter_Jump;
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
                @ExecuteCom.started -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnExecuteCom;
                @ExecuteCom.performed -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnExecuteCom;
                @ExecuteCom.canceled -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnExecuteCom;
                @cmdOn.started -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnCmdOn;
                @cmdOn.performed -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnCmdOn;
                @cmdOn.canceled -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnCmdOn;
                @cmdOff.started -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnCmdOff;
                @cmdOff.performed -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnCmdOff;
                @cmdOff.canceled -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnCmdOff;
                @Jump.started -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_PlayerCharacterActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @ExecuteCom.started += instance.OnExecuteCom;
                @ExecuteCom.performed += instance.OnExecuteCom;
                @ExecuteCom.canceled += instance.OnExecuteCom;
                @cmdOn.started += instance.OnCmdOn;
                @cmdOn.performed += instance.OnCmdOn;
                @cmdOn.canceled += instance.OnCmdOn;
                @cmdOff.started += instance.OnCmdOff;
                @cmdOff.performed += instance.OnCmdOff;
                @cmdOff.canceled += instance.OnCmdOff;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public PlayerCharacterActions @PlayerCharacter => new PlayerCharacterActions(this);
    public interface IPlayerCharacterActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnExecuteCom(InputAction.CallbackContext context);
        void OnCmdOn(InputAction.CallbackContext context);
        void OnCmdOff(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
