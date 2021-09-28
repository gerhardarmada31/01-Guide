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
                },
                {
                    ""name"": ""YMove"",
                    ""type"": ""Button"",
                    ""id"": ""515f056a-d608-4171-80ad-6f630d20d205"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DialogueKeys"",
                    ""type"": ""Value"",
                    ""id"": ""b4fbedd2-3dc8-42cf-b829-44ece17f89de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ContinueDialogue"",
                    ""type"": ""Button"",
                    ""id"": ""c177b893-742a-463b-b380-b798f1d6ce8d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""a4873738-f017-4247-acd6-ec27cde8daa5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""9688ea3e-72e9-48b7-84be-8b240738641c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.1,pressPoint=0.2)""
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
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""eba26df1-dc8e-488e-b56c-1aa54a9b5b12"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""2dcc5650-175f-48db-9129-756b17945d6a"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""4c91c728-5ba1-4ee5-8a8d-3241aa4cbfe1"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WS keys"",
                    ""id"": ""5aa2c94d-2f33-4920-9d62-9639a088d8d7"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DialogueKeys"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""141d2a19-e821-42f8-aeb6-2fe528871187"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DialogueKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b19be727-bc67-4a61-8fbe-e6e0e87a64fe"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DialogueKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""9d789e1f-090a-4125-a9be-360345c26993"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DialogueKeys"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""88db6501-a43a-472d-b6c3-d9bd5b120e64"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DialogueKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e6e09245-ede6-413d-946f-c2d1dd2882a6"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DialogueKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f5b51ab5-d9af-4260-b6a4-6704c4e01ce8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ContinueDialogue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""999e42c5-f0d4-49e2-b71a-673f5aa98257"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa89f8e5-995b-4fa1-88b4-cbfc5f0d27cc"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""CheatController"",
            ""id"": ""40d9e923-932d-45db-9e2c-8e652d28c7e4"",
            ""actions"": [
                {
                    ""name"": ""Return"",
                    ""type"": ""Button"",
                    ""id"": ""a6a1c128-9704-4a15-95c6-e938ae9b81a3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleDebug"",
                    ""type"": ""Button"",
                    ""id"": ""7aea200f-f150-4b28-93d6-e44044cd72cb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cec63f5b-0b78-4f17-9f8e-c9a58ba9ae29"",
                    ""path"": ""<Keyboard>/backquote"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleDebug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""343460dc-ac06-4e63-b6c5-d63413670b6c"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Return"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""21dd6d46-2fa6-42fb-90f4-115092332a0b"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""7b7e772e-e2ba-425f-90e4-65491424e830"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""24f38b44-4390-4333-bdc7-f96e4a2f44df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""c0d2e6bf-8dd1-4933-bb07-1f787c874e69"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9fef534e-cf30-44aa-90c6-120cf80532ef"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6d3aa171-643f-4788-b8aa-1d5e28f761f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ScrollWheel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""15f729a2-10d2-430b-9089-0c733b829b38"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MiddleClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a9ca01aa-d806-4a07-80c5-4af3e296fb5a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f78d1782-bad5-4d2f-bc10-14e6be40e75b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDevicePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""47962fd4-ebef-4420-b13c-af43e7271d16"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDeviceOrientation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""be9d99a2-1825-45eb-b743-b26613d81ff2"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Tab"",
                    ""type"": ""Button"",
                    ""id"": ""0329cd49-2939-428d-bab0-6eeb06f64e69"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""b7da4961-541d-40db-a78e-5acb07c62b21"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""847c9d56-e2d3-4c1a-befc-40bc6bc36047"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f8fb4452-be8a-47fe-8abd-a18f8c509a02"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""403c84c3-8b74-4183-9727-8af721a45529"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""232d40f5-48d1-4883-92d0-97ca0abd9b89"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b3295621-45e4-4201-b3c7-5c4d67fc68cf"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4c7aa038-6dab-45cf-b216-4cbfe95bfbef"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d89afdee-95b4-4cb2-852c-e3300fd232df"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""38782384-04e1-4c67-84c3-f63d99c50bff"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b15856b0-9311-468f-8dba-d1bcfb4f3547"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""4e176897-daf1-4517-8cc8-a1c126efd384"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""21c8db9f-4311-4220-8492-73f1c7ee118a"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9fb795a9-cc6f-44ae-905d-88b70673257a"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""51ce971d-f2f0-45c9-ad8c-67e3f8a52a94"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4b0bad39-4786-4250-93f5-28ac0d2ea0a9"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""9e7c208a-11e2-4847-aeb1-cb731bb26fe3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7a083d22-70e8-4f84-92f6-c7f7536ec680"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""bea8384f-32aa-4d4d-b527-49a79d05f0b5"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3a9bd06e-55aa-41c4-a39a-fdf1864f37c6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5b539cad-0d7f-4e7c-b2f7-50afd90e47ba"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6e20941d-1300-45a6-82cf-4ddf3b6e958d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""418b51ee-06fa-45cc-859b-770869e09015"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e6d0f574-799e-4448-9daa-4272afa614c7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f96fbf7f-931b-4d60-a204-342f9a38036e"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e7dde1a9-a5d4-4365-8b13-c4e3b8a993cd"",
                    ""path"": ""*/{Submit}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60c3e510-4124-4c23-ba6d-5cfcd6453933"",
                    ""path"": ""*/{Cancel}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12f6afb3-50d4-474e-9296-8e2195a7cecb"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9ec534e-05a5-44fb-85af-f0414e522769"",
                    ""path"": ""<Pen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44854f5f-a1b8-43b5-b526-fbb8f3fc4165"",
                    ""path"": ""<Touchscreen>/touch*/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c6cde8f-18c1-4525-8bb1-54ed7115b5fa"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09b9aa98-7d88-446e-8deb-3bb1ed5af1d8"",
                    ""path"": ""<Pen>/tip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5b0c07c-2167-4e04-8e7a-082c403146f8"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73ed7273-9025-470d-912c-866cbb33ddcd"",
                    ""path"": ""<XRController>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0c0a77d-56b6-4b67-ad56-a26e1006fa33"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""ScrollWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7cfe5a82-c9c6-4dfa-996c-acd086b3efb7"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""MiddleClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24fa2c70-589a-4538-a1d8-e8b0cb0f4495"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd088868-0d90-4b33-9177-5dbb4791c5b5"",
                    ""path"": ""<XRController>/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""TrackedDevicePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a77cef17-dbdc-46f9-9edb-be1d16147554"",
                    ""path"": ""<XRController>/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""TrackedDeviceOrientation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""NextOrPrev"",
                    ""id"": ""7e4d35fe-c4b7-4e6a-ae05-2a0487cadca1"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tab"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""29698322-f010-4c26-9f75-e4e56838bd72"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""21c788b1-c51e-4fa3-816f-87bd0a99d371"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
        m_PlayerCharacter_YMove = m_PlayerCharacter.FindAction("YMove", throwIfNotFound: true);
        m_PlayerCharacter_DialogueKeys = m_PlayerCharacter.FindAction("DialogueKeys", throwIfNotFound: true);
        m_PlayerCharacter_ContinueDialogue = m_PlayerCharacter.FindAction("ContinueDialogue", throwIfNotFound: true);
        m_PlayerCharacter_Menu = m_PlayerCharacter.FindAction("Menu", throwIfNotFound: true);
        m_PlayerCharacter_Sprint = m_PlayerCharacter.FindAction("Sprint", throwIfNotFound: true);
        // CheatController
        m_CheatController = asset.FindActionMap("CheatController", throwIfNotFound: true);
        m_CheatController_Return = m_CheatController.FindAction("Return", throwIfNotFound: true);
        m_CheatController_ToggleDebug = m_CheatController.FindAction("ToggleDebug", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Navigate = m_UI.FindAction("Navigate", throwIfNotFound: true);
        m_UI_Submit = m_UI.FindAction("Submit", throwIfNotFound: true);
        m_UI_Cancel = m_UI.FindAction("Cancel", throwIfNotFound: true);
        m_UI_Point = m_UI.FindAction("Point", throwIfNotFound: true);
        m_UI_Click = m_UI.FindAction("Click", throwIfNotFound: true);
        m_UI_ScrollWheel = m_UI.FindAction("ScrollWheel", throwIfNotFound: true);
        m_UI_MiddleClick = m_UI.FindAction("MiddleClick", throwIfNotFound: true);
        m_UI_RightClick = m_UI.FindAction("RightClick", throwIfNotFound: true);
        m_UI_TrackedDevicePosition = m_UI.FindAction("TrackedDevicePosition", throwIfNotFound: true);
        m_UI_TrackedDeviceOrientation = m_UI.FindAction("TrackedDeviceOrientation", throwIfNotFound: true);
        m_UI_Tab = m_UI.FindAction("Tab", throwIfNotFound: true);
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
    private readonly InputAction m_PlayerCharacter_YMove;
    private readonly InputAction m_PlayerCharacter_DialogueKeys;
    private readonly InputAction m_PlayerCharacter_ContinueDialogue;
    private readonly InputAction m_PlayerCharacter_Menu;
    private readonly InputAction m_PlayerCharacter_Sprint;
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
        public InputAction @YMove => m_Wrapper.m_PlayerCharacter_YMove;
        public InputAction @DialogueKeys => m_Wrapper.m_PlayerCharacter_DialogueKeys;
        public InputAction @ContinueDialogue => m_Wrapper.m_PlayerCharacter_ContinueDialogue;
        public InputAction @Menu => m_Wrapper.m_PlayerCharacter_Menu;
        public InputAction @Sprint => m_Wrapper.m_PlayerCharacter_Sprint;
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
                @YMove.started -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnYMove;
                @YMove.performed -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnYMove;
                @YMove.canceled -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnYMove;
                @DialogueKeys.started -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnDialogueKeys;
                @DialogueKeys.performed -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnDialogueKeys;
                @DialogueKeys.canceled -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnDialogueKeys;
                @ContinueDialogue.started -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnContinueDialogue;
                @ContinueDialogue.performed -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnContinueDialogue;
                @ContinueDialogue.canceled -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnContinueDialogue;
                @Menu.started -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnMenu;
                @Menu.performed -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnMenu;
                @Menu.canceled -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnMenu;
                @Sprint.started -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnSprint;
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
                @YMove.started += instance.OnYMove;
                @YMove.performed += instance.OnYMove;
                @YMove.canceled += instance.OnYMove;
                @DialogueKeys.started += instance.OnDialogueKeys;
                @DialogueKeys.performed += instance.OnDialogueKeys;
                @DialogueKeys.canceled += instance.OnDialogueKeys;
                @ContinueDialogue.started += instance.OnContinueDialogue;
                @ContinueDialogue.performed += instance.OnContinueDialogue;
                @ContinueDialogue.canceled += instance.OnContinueDialogue;
                @Menu.started += instance.OnMenu;
                @Menu.performed += instance.OnMenu;
                @Menu.canceled += instance.OnMenu;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
            }
        }
    }
    public PlayerCharacterActions @PlayerCharacter => new PlayerCharacterActions(this);

    // CheatController
    private readonly InputActionMap m_CheatController;
    private ICheatControllerActions m_CheatControllerActionsCallbackInterface;
    private readonly InputAction m_CheatController_Return;
    private readonly InputAction m_CheatController_ToggleDebug;
    public struct CheatControllerActions
    {
        private @InputActions m_Wrapper;
        public CheatControllerActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Return => m_Wrapper.m_CheatController_Return;
        public InputAction @ToggleDebug => m_Wrapper.m_CheatController_ToggleDebug;
        public InputActionMap Get() { return m_Wrapper.m_CheatController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CheatControllerActions set) { return set.Get(); }
        public void SetCallbacks(ICheatControllerActions instance)
        {
            if (m_Wrapper.m_CheatControllerActionsCallbackInterface != null)
            {
                @Return.started -= m_Wrapper.m_CheatControllerActionsCallbackInterface.OnReturn;
                @Return.performed -= m_Wrapper.m_CheatControllerActionsCallbackInterface.OnReturn;
                @Return.canceled -= m_Wrapper.m_CheatControllerActionsCallbackInterface.OnReturn;
                @ToggleDebug.started -= m_Wrapper.m_CheatControllerActionsCallbackInterface.OnToggleDebug;
                @ToggleDebug.performed -= m_Wrapper.m_CheatControllerActionsCallbackInterface.OnToggleDebug;
                @ToggleDebug.canceled -= m_Wrapper.m_CheatControllerActionsCallbackInterface.OnToggleDebug;
            }
            m_Wrapper.m_CheatControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Return.started += instance.OnReturn;
                @Return.performed += instance.OnReturn;
                @Return.canceled += instance.OnReturn;
                @ToggleDebug.started += instance.OnToggleDebug;
                @ToggleDebug.performed += instance.OnToggleDebug;
                @ToggleDebug.canceled += instance.OnToggleDebug;
            }
        }
    }
    public CheatControllerActions @CheatController => new CheatControllerActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Navigate;
    private readonly InputAction m_UI_Submit;
    private readonly InputAction m_UI_Cancel;
    private readonly InputAction m_UI_Point;
    private readonly InputAction m_UI_Click;
    private readonly InputAction m_UI_ScrollWheel;
    private readonly InputAction m_UI_MiddleClick;
    private readonly InputAction m_UI_RightClick;
    private readonly InputAction m_UI_TrackedDevicePosition;
    private readonly InputAction m_UI_TrackedDeviceOrientation;
    private readonly InputAction m_UI_Tab;
    public struct UIActions
    {
        private @InputActions m_Wrapper;
        public UIActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigate => m_Wrapper.m_UI_Navigate;
        public InputAction @Submit => m_Wrapper.m_UI_Submit;
        public InputAction @Cancel => m_Wrapper.m_UI_Cancel;
        public InputAction @Point => m_Wrapper.m_UI_Point;
        public InputAction @Click => m_Wrapper.m_UI_Click;
        public InputAction @ScrollWheel => m_Wrapper.m_UI_ScrollWheel;
        public InputAction @MiddleClick => m_Wrapper.m_UI_MiddleClick;
        public InputAction @RightClick => m_Wrapper.m_UI_RightClick;
        public InputAction @TrackedDevicePosition => m_Wrapper.m_UI_TrackedDevicePosition;
        public InputAction @TrackedDeviceOrientation => m_Wrapper.m_UI_TrackedDeviceOrientation;
        public InputAction @Tab => m_Wrapper.m_UI_Tab;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Navigate.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Submit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Cancel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Point.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Point.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Point.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Click.started -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @ScrollWheel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                @MiddleClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                @MiddleClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                @MiddleClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                @RightClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                @TrackedDevicePosition.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDevicePosition.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDevicePosition.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDeviceOrientation.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                @Tab.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTab;
                @Tab.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTab;
                @Tab.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTab;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Point.started += instance.OnPoint;
                @Point.performed += instance.OnPoint;
                @Point.canceled += instance.OnPoint;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @ScrollWheel.started += instance.OnScrollWheel;
                @ScrollWheel.performed += instance.OnScrollWheel;
                @ScrollWheel.canceled += instance.OnScrollWheel;
                @MiddleClick.started += instance.OnMiddleClick;
                @MiddleClick.performed += instance.OnMiddleClick;
                @MiddleClick.canceled += instance.OnMiddleClick;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
                @TrackedDevicePosition.started += instance.OnTrackedDevicePosition;
                @TrackedDevicePosition.performed += instance.OnTrackedDevicePosition;
                @TrackedDevicePosition.canceled += instance.OnTrackedDevicePosition;
                @TrackedDeviceOrientation.started += instance.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.performed += instance.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.canceled += instance.OnTrackedDeviceOrientation;
                @Tab.started += instance.OnTab;
                @Tab.performed += instance.OnTab;
                @Tab.canceled += instance.OnTab;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IPlayerCharacterActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnExecuteCom(InputAction.CallbackContext context);
        void OnCmdOff(InputAction.CallbackContext context);
        void OnCmdOn(InputAction.CallbackContext context);
        void OnCmdSelect(InputAction.CallbackContext context);
        void OnStackSp(InputAction.CallbackContext context);
        void OnYMove(InputAction.CallbackContext context);
        void OnDialogueKeys(InputAction.CallbackContext context);
        void OnContinueDialogue(InputAction.CallbackContext context);
        void OnMenu(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
    }
    public interface ICheatControllerActions
    {
        void OnReturn(InputAction.CallbackContext context);
        void OnToggleDebug(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnNavigate(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnScrollWheel(InputAction.CallbackContext context);
        void OnMiddleClick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnTrackedDevicePosition(InputAction.CallbackContext context);
        void OnTrackedDeviceOrientation(InputAction.CallbackContext context);
        void OnTab(InputAction.CallbackContext context);
    }
}
