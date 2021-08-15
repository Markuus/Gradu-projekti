// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/Player.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Player : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player"",
    ""maps"": [
        {
            ""name"": ""PlayerMain"",
            ""id"": ""244124f0-d073-43c9-9113-1c63025eee40"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""986495a4-62af-46c5-976c-a560505473e9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""d96c8767-bebd-4ba1-89da-dae55ed6be4a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""1e539e7c-26f7-466b-9890-97cc4654e1ec"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EnterRaft"",
                    ""type"": ""Button"",
                    ""id"": ""5ffdf75d-660d-4ff3-bfc2-3417cad6c512"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ExitRaft"",
                    ""type"": ""Button"",
                    ""id"": ""01028315-6c54-45b5-85e0-cf660808b3a3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4794a6b0-6f4d-4b06-b5fc-8cad91696377"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""268b6688-927d-4958-93fa-c66ba635fa2f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7dcc279d-8cea-40ee-aa26-4f39380633a4"",
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
                    ""id"": ""2727545a-0002-4cef-9c89-71caaaa4d329"",
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
                    ""id"": ""914dc802-cc17-48d8-8327-8a4891ad1179"",
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
                    ""id"": ""f4282f5b-9ff8-4630-8716-c6a9876929f0"",
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
                    ""id"": ""57ba7761-dd07-4210-97e8-0b55b33ac377"",
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
                    ""id"": ""401647cc-8b11-40eb-b661-4a76ee647f1b"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a351db2-efeb-47f8-a616-a2d076480d14"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aff4da61-417e-462c-a7b1-0f41fadf83f8"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EnterRaft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1bced9e9-009f-4c29-ae05-fdb11fc00904"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ExitRaft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerMain2"",
            ""id"": ""c13ca145-6768-4e87-9a33-9eac82fc7710"",
            ""actions"": [
                {
                    ""name"": ""TouchInput"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6f615c04-c54a-4605-ad40-1a3fe531179f"",
                    ""expectedControlType"": ""Touch"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""Button"",
                    ""id"": ""588828b8-8ca7-4437-81e2-f077d2c9f28c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""TouchPress2"",
                    ""type"": ""Button"",
                    ""id"": ""ee8c196f-8268-4eaf-93a9-9c2b51facf8b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f99974e6-b0e8-4ef9-bf5a-5daf1d38e836"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LookAround"",
                    ""type"": ""PassThrough"",
                    ""id"": ""fe527bd2-5247-4b47-9fbc-1182d96356a7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""07d6650a-d6fa-42d4-9e27-6463eb841879"",
                    ""path"": ""<Touchscreen>/primaryTouch"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4d95b22-e971-4297-9a06-c19989e1badd"",
                    ""path"": ""<Touchscreen>/touch0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""954daad9-64be-4b9b-bc9e-7b6b045c43e6"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8065e71f-a0f7-4c31-8c51-174ca54d5b06"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6002e58b-8ba8-404a-be39-9c7be694393d"",
                    ""path"": ""<Touchscreen>/primaryTouch/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""733bf038-1a9d-4a9d-80fc-300434fb496a"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMain
        m_PlayerMain = asset.FindActionMap("PlayerMain", throwIfNotFound: true);
        m_PlayerMain_Move = m_PlayerMain.FindAction("Move", throwIfNotFound: true);
        m_PlayerMain_Jump = m_PlayerMain.FindAction("Jump", throwIfNotFound: true);
        m_PlayerMain_Look = m_PlayerMain.FindAction("Look", throwIfNotFound: true);
        m_PlayerMain_EnterRaft = m_PlayerMain.FindAction("EnterRaft", throwIfNotFound: true);
        m_PlayerMain_ExitRaft = m_PlayerMain.FindAction("ExitRaft", throwIfNotFound: true);
        // PlayerMain2
        m_PlayerMain2 = asset.FindActionMap("PlayerMain2", throwIfNotFound: true);
        m_PlayerMain2_TouchInput = m_PlayerMain2.FindAction("TouchInput", throwIfNotFound: true);
        m_PlayerMain2_TouchPress = m_PlayerMain2.FindAction("TouchPress", throwIfNotFound: true);
        m_PlayerMain2_TouchPress2 = m_PlayerMain2.FindAction("TouchPress2", throwIfNotFound: true);
        m_PlayerMain2_TouchPosition = m_PlayerMain2.FindAction("TouchPosition", throwIfNotFound: true);
        m_PlayerMain2_LookAround = m_PlayerMain2.FindAction("LookAround", throwIfNotFound: true);
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

    // PlayerMain
    private readonly InputActionMap m_PlayerMain;
    private IPlayerMainActions m_PlayerMainActionsCallbackInterface;
    private readonly InputAction m_PlayerMain_Move;
    private readonly InputAction m_PlayerMain_Jump;
    private readonly InputAction m_PlayerMain_Look;
    private readonly InputAction m_PlayerMain_EnterRaft;
    private readonly InputAction m_PlayerMain_ExitRaft;
    public struct PlayerMainActions
    {
        private @Player m_Wrapper;
        public PlayerMainActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerMain_Move;
        public InputAction @Jump => m_Wrapper.m_PlayerMain_Jump;
        public InputAction @Look => m_Wrapper.m_PlayerMain_Look;
        public InputAction @EnterRaft => m_Wrapper.m_PlayerMain_EnterRaft;
        public InputAction @ExitRaft => m_Wrapper.m_PlayerMain_ExitRaft;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMain; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMainActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMainActions instance)
        {
            if (m_Wrapper.m_PlayerMainActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnJump;
                @Look.started -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnLook;
                @EnterRaft.started -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnEnterRaft;
                @EnterRaft.performed -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnEnterRaft;
                @EnterRaft.canceled -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnEnterRaft;
                @ExitRaft.started -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnExitRaft;
                @ExitRaft.performed -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnExitRaft;
                @ExitRaft.canceled -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnExitRaft;
            }
            m_Wrapper.m_PlayerMainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @EnterRaft.started += instance.OnEnterRaft;
                @EnterRaft.performed += instance.OnEnterRaft;
                @EnterRaft.canceled += instance.OnEnterRaft;
                @ExitRaft.started += instance.OnExitRaft;
                @ExitRaft.performed += instance.OnExitRaft;
                @ExitRaft.canceled += instance.OnExitRaft;
            }
        }
    }
    public PlayerMainActions @PlayerMain => new PlayerMainActions(this);

    // PlayerMain2
    private readonly InputActionMap m_PlayerMain2;
    private IPlayerMain2Actions m_PlayerMain2ActionsCallbackInterface;
    private readonly InputAction m_PlayerMain2_TouchInput;
    private readonly InputAction m_PlayerMain2_TouchPress;
    private readonly InputAction m_PlayerMain2_TouchPress2;
    private readonly InputAction m_PlayerMain2_TouchPosition;
    private readonly InputAction m_PlayerMain2_LookAround;
    public struct PlayerMain2Actions
    {
        private @Player m_Wrapper;
        public PlayerMain2Actions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @TouchInput => m_Wrapper.m_PlayerMain2_TouchInput;
        public InputAction @TouchPress => m_Wrapper.m_PlayerMain2_TouchPress;
        public InputAction @TouchPress2 => m_Wrapper.m_PlayerMain2_TouchPress2;
        public InputAction @TouchPosition => m_Wrapper.m_PlayerMain2_TouchPosition;
        public InputAction @LookAround => m_Wrapper.m_PlayerMain2_LookAround;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMain2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMain2Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMain2Actions instance)
        {
            if (m_Wrapper.m_PlayerMain2ActionsCallbackInterface != null)
            {
                @TouchInput.started -= m_Wrapper.m_PlayerMain2ActionsCallbackInterface.OnTouchInput;
                @TouchInput.performed -= m_Wrapper.m_PlayerMain2ActionsCallbackInterface.OnTouchInput;
                @TouchInput.canceled -= m_Wrapper.m_PlayerMain2ActionsCallbackInterface.OnTouchInput;
                @TouchPress.started -= m_Wrapper.m_PlayerMain2ActionsCallbackInterface.OnTouchPress;
                @TouchPress.performed -= m_Wrapper.m_PlayerMain2ActionsCallbackInterface.OnTouchPress;
                @TouchPress.canceled -= m_Wrapper.m_PlayerMain2ActionsCallbackInterface.OnTouchPress;
                @TouchPress2.started -= m_Wrapper.m_PlayerMain2ActionsCallbackInterface.OnTouchPress2;
                @TouchPress2.performed -= m_Wrapper.m_PlayerMain2ActionsCallbackInterface.OnTouchPress2;
                @TouchPress2.canceled -= m_Wrapper.m_PlayerMain2ActionsCallbackInterface.OnTouchPress2;
                @TouchPosition.started -= m_Wrapper.m_PlayerMain2ActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.performed -= m_Wrapper.m_PlayerMain2ActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.canceled -= m_Wrapper.m_PlayerMain2ActionsCallbackInterface.OnTouchPosition;
                @LookAround.started -= m_Wrapper.m_PlayerMain2ActionsCallbackInterface.OnLookAround;
                @LookAround.performed -= m_Wrapper.m_PlayerMain2ActionsCallbackInterface.OnLookAround;
                @LookAround.canceled -= m_Wrapper.m_PlayerMain2ActionsCallbackInterface.OnLookAround;
            }
            m_Wrapper.m_PlayerMain2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TouchInput.started += instance.OnTouchInput;
                @TouchInput.performed += instance.OnTouchInput;
                @TouchInput.canceled += instance.OnTouchInput;
                @TouchPress.started += instance.OnTouchPress;
                @TouchPress.performed += instance.OnTouchPress;
                @TouchPress.canceled += instance.OnTouchPress;
                @TouchPress2.started += instance.OnTouchPress2;
                @TouchPress2.performed += instance.OnTouchPress2;
                @TouchPress2.canceled += instance.OnTouchPress2;
                @TouchPosition.started += instance.OnTouchPosition;
                @TouchPosition.performed += instance.OnTouchPosition;
                @TouchPosition.canceled += instance.OnTouchPosition;
                @LookAround.started += instance.OnLookAround;
                @LookAround.performed += instance.OnLookAround;
                @LookAround.canceled += instance.OnLookAround;
            }
        }
    }
    public PlayerMain2Actions @PlayerMain2 => new PlayerMain2Actions(this);
    public interface IPlayerMainActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnEnterRaft(InputAction.CallbackContext context);
        void OnExitRaft(InputAction.CallbackContext context);
    }
    public interface IPlayerMain2Actions
    {
        void OnTouchInput(InputAction.CallbackContext context);
        void OnTouchPress(InputAction.CallbackContext context);
        void OnTouchPress2(InputAction.CallbackContext context);
        void OnTouchPosition(InputAction.CallbackContext context);
        void OnLookAround(InputAction.CallbackContext context);
    }
}
