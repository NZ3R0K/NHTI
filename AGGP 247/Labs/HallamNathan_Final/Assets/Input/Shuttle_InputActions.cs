// GENERATED AUTOMATICALLY FROM 'Assets/Input/Shuttle_InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Shuttle_InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Shuttle_InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Shuttle_InputActions"",
    ""maps"": [
        {
            ""name"": ""System"",
            ""id"": ""9f3758e9-95de-462d-8c85-090d0557b3db"",
            ""actions"": [
                {
                    ""name"": ""Play"",
                    ""type"": ""Button"",
                    ""id"": ""f9f34b22-2bc7-4e28-8101-ff95eb8bfc34"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""2f47fbb4-4163-41fb-b717-c65f905c7103"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""35e29ec7-444a-4028-b189-da13e3a020cd"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Play"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9dd97998-72f0-4e77-b2e5-cdb8cf76ad61"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Shuttle"",
            ""id"": ""0ebd12ae-ac17-473c-9087-2d61d228d3e7"",
            ""actions"": [
                {
                    ""name"": ""Thrust"",
                    ""type"": ""Value"",
                    ""id"": ""722f1e52-ab10-4d8a-acca-ffd3215d903d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""9969dacd-cd0d-4351-99dd-924dea05db59"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6d6ff6e2-e11f-48a5-8960-1d514487f2a2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Thrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""6490cdec-e737-4c57-8e0d-ddecd706297d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""9a6858e3-d09c-4957-b681-b18369fd7349"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0cfb6088-8e5a-4526-a219-5f91cd669b59"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // System
        m_System = asset.FindActionMap("System", throwIfNotFound: true);
        m_System_Play = m_System.FindAction("Play", throwIfNotFound: true);
        m_System_Exit = m_System.FindAction("Exit", throwIfNotFound: true);
        // Shuttle
        m_Shuttle = asset.FindActionMap("Shuttle", throwIfNotFound: true);
        m_Shuttle_Thrust = m_Shuttle.FindAction("Thrust", throwIfNotFound: true);
        m_Shuttle_Rotate = m_Shuttle.FindAction("Rotate", throwIfNotFound: true);
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

    // System
    private readonly InputActionMap m_System;
    private ISystemActions m_SystemActionsCallbackInterface;
    private readonly InputAction m_System_Play;
    private readonly InputAction m_System_Exit;
    public struct SystemActions
    {
        private @Shuttle_InputActions m_Wrapper;
        public SystemActions(@Shuttle_InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Play => m_Wrapper.m_System_Play;
        public InputAction @Exit => m_Wrapper.m_System_Exit;
        public InputActionMap Get() { return m_Wrapper.m_System; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SystemActions set) { return set.Get(); }
        public void SetCallbacks(ISystemActions instance)
        {
            if (m_Wrapper.m_SystemActionsCallbackInterface != null)
            {
                @Play.started -= m_Wrapper.m_SystemActionsCallbackInterface.OnPlay;
                @Play.performed -= m_Wrapper.m_SystemActionsCallbackInterface.OnPlay;
                @Play.canceled -= m_Wrapper.m_SystemActionsCallbackInterface.OnPlay;
                @Exit.started -= m_Wrapper.m_SystemActionsCallbackInterface.OnExit;
                @Exit.performed -= m_Wrapper.m_SystemActionsCallbackInterface.OnExit;
                @Exit.canceled -= m_Wrapper.m_SystemActionsCallbackInterface.OnExit;
            }
            m_Wrapper.m_SystemActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Play.started += instance.OnPlay;
                @Play.performed += instance.OnPlay;
                @Play.canceled += instance.OnPlay;
                @Exit.started += instance.OnExit;
                @Exit.performed += instance.OnExit;
                @Exit.canceled += instance.OnExit;
            }
        }
    }
    public SystemActions @System => new SystemActions(this);

    // Shuttle
    private readonly InputActionMap m_Shuttle;
    private IShuttleActions m_ShuttleActionsCallbackInterface;
    private readonly InputAction m_Shuttle_Thrust;
    private readonly InputAction m_Shuttle_Rotate;
    public struct ShuttleActions
    {
        private @Shuttle_InputActions m_Wrapper;
        public ShuttleActions(@Shuttle_InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Thrust => m_Wrapper.m_Shuttle_Thrust;
        public InputAction @Rotate => m_Wrapper.m_Shuttle_Rotate;
        public InputActionMap Get() { return m_Wrapper.m_Shuttle; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShuttleActions set) { return set.Get(); }
        public void SetCallbacks(IShuttleActions instance)
        {
            if (m_Wrapper.m_ShuttleActionsCallbackInterface != null)
            {
                @Thrust.started -= m_Wrapper.m_ShuttleActionsCallbackInterface.OnThrust;
                @Thrust.performed -= m_Wrapper.m_ShuttleActionsCallbackInterface.OnThrust;
                @Thrust.canceled -= m_Wrapper.m_ShuttleActionsCallbackInterface.OnThrust;
                @Rotate.started -= m_Wrapper.m_ShuttleActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_ShuttleActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_ShuttleActionsCallbackInterface.OnRotate;
            }
            m_Wrapper.m_ShuttleActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Thrust.started += instance.OnThrust;
                @Thrust.performed += instance.OnThrust;
                @Thrust.canceled += instance.OnThrust;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
            }
        }
    }
    public ShuttleActions @Shuttle => new ShuttleActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface ISystemActions
    {
        void OnPlay(InputAction.CallbackContext context);
        void OnExit(InputAction.CallbackContext context);
    }
    public interface IShuttleActions
    {
        void OnThrust(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
    }
}
