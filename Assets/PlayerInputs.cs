//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/PlayerInputs.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""Inputs"",
            ""id"": ""17c1295f-eff2-4c45-9d40-61cf0bb73a61"",
            ""actions"": [
                {
                    ""name"": ""KnobInput"",
                    ""type"": ""Value"",
                    ""id"": ""0ee69410-b282-42d0-88db-cfc76bd597d6"",
                    ""expectedControlType"": ""Delta"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""QuickTime"",
                    ""type"": ""Value"",
                    ""id"": ""50a0796e-2280-488c-a6d6-bd16e223b150"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""FX-Button L"",
                    ""type"": ""Button"",
                    ""id"": ""09b3e939-6a80-42d8-82af-29d22fed769f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""FX-Button R"",
                    ""type"": ""Button"",
                    ""id"": ""c457807b-1b08-4d24-b23a-17157ef3a35a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""265d6e2b-c982-4517-a1f8-b22cd7c0887b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Secret"",
                    ""type"": ""Button"",
                    ""id"": ""7035d5ed-cda0-4290-8ab0-41eabd15d351"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""66aaea77-66a5-4355-a068-847e8c0c14ba"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KnobInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""7e4d8bf7-56a7-4b7c-bfbc-15b6c6749b1a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickTime"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""144c16d0-5f2a-42b7-bda2-0c5cf2fefa65"",
                    ""path"": ""<HID::VIRGOO TURBOCHARGER VIRGOO TURBOCHARGER>/button5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickTime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""21d5c12d-a676-458e-816e-4f9df36408e3"",
                    ""path"": ""<HID::VIRGOO TURBOCHARGER VIRGOO TURBOCHARGER>/button7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickTime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""22743b1e-0197-434f-95f6-e7119148b265"",
                    ""path"": ""<HID::VIRGOO TURBOCHARGER VIRGOO TURBOCHARGER>/button8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickTime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""84342fb4-215b-4b33-9f9a-23210f9c3eba"",
                    ""path"": ""<HID::VIRGOO TURBOCHARGER VIRGOO TURBOCHARGER>/button6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickTime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""f7e402d3-48bd-41df-b352-46671d1a9166"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickTime"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""fc6ac6f2-5c29-42fb-8401-539fe5d0021b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickTime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e400a208-c167-414e-be1e-cd7077b546cb"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickTime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e34660b8-013f-4f74-b95b-16f9bf4dfe78"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickTime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e8de6d68-ffac-4dc9-ad40-69fc4cf5a972"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickTime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f4ba0d37-63ac-4c8d-84c3-929e8056d2b6"",
                    ""path"": ""<HID::VIRGOO TURBOCHARGER VIRGOO TURBOCHARGER>/button10"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d9d3267e-eb6b-4c0c-8fa5-7fba4fd7ff35"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""06ce33c2-9925-489e-9e7f-ebd154e2fb96"",
                    ""path"": ""<HID::VIRGOO TURBOCHARGER VIRGOO TURBOCHARGER>/button4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Secret"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2d877b5-59e6-415b-a4f8-8d72fa366cc8"",
                    ""path"": ""<HID::VIRGOO TURBOCHARGER VIRGOO TURBOCHARGER>/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FX-Button L"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bb4b3bc-679b-4b9f-8621-cca79ca7ca7a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FX-Button L"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59163a37-e763-423e-9018-44df771a12e5"",
                    ""path"": ""<HID::VIRGOO TURBOCHARGER VIRGOO TURBOCHARGER>/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FX-Button R"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bcc30b1d-e44d-4fc1-8834-448d0c96b1e6"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FX-Button R"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Inputs
        m_Inputs = asset.FindActionMap("Inputs", throwIfNotFound: true);
        m_Inputs_KnobInput = m_Inputs.FindAction("KnobInput", throwIfNotFound: true);
        m_Inputs_QuickTime = m_Inputs.FindAction("QuickTime", throwIfNotFound: true);
        m_Inputs_FXButtonL = m_Inputs.FindAction("FX-Button L", throwIfNotFound: true);
        m_Inputs_FXButtonR = m_Inputs.FindAction("FX-Button R", throwIfNotFound: true);
        m_Inputs_Start = m_Inputs.FindAction("Start", throwIfNotFound: true);
        m_Inputs_Secret = m_Inputs.FindAction("Secret", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Inputs
    private readonly InputActionMap m_Inputs;
    private List<IInputsActions> m_InputsActionsCallbackInterfaces = new List<IInputsActions>();
    private readonly InputAction m_Inputs_KnobInput;
    private readonly InputAction m_Inputs_QuickTime;
    private readonly InputAction m_Inputs_FXButtonL;
    private readonly InputAction m_Inputs_FXButtonR;
    private readonly InputAction m_Inputs_Start;
    private readonly InputAction m_Inputs_Secret;
    public struct InputsActions
    {
        private @PlayerInputs m_Wrapper;
        public InputsActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @KnobInput => m_Wrapper.m_Inputs_KnobInput;
        public InputAction @QuickTime => m_Wrapper.m_Inputs_QuickTime;
        public InputAction @FXButtonL => m_Wrapper.m_Inputs_FXButtonL;
        public InputAction @FXButtonR => m_Wrapper.m_Inputs_FXButtonR;
        public InputAction @Start => m_Wrapper.m_Inputs_Start;
        public InputAction @Secret => m_Wrapper.m_Inputs_Secret;
        public InputActionMap Get() { return m_Wrapper.m_Inputs; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputsActions set) { return set.Get(); }
        public void AddCallbacks(IInputsActions instance)
        {
            if (instance == null || m_Wrapper.m_InputsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InputsActionsCallbackInterfaces.Add(instance);
            @KnobInput.started += instance.OnKnobInput;
            @KnobInput.performed += instance.OnKnobInput;
            @KnobInput.canceled += instance.OnKnobInput;
            @QuickTime.started += instance.OnQuickTime;
            @QuickTime.performed += instance.OnQuickTime;
            @QuickTime.canceled += instance.OnQuickTime;
            @FXButtonL.started += instance.OnFXButtonL;
            @FXButtonL.performed += instance.OnFXButtonL;
            @FXButtonL.canceled += instance.OnFXButtonL;
            @FXButtonR.started += instance.OnFXButtonR;
            @FXButtonR.performed += instance.OnFXButtonR;
            @FXButtonR.canceled += instance.OnFXButtonR;
            @Start.started += instance.OnStart;
            @Start.performed += instance.OnStart;
            @Start.canceled += instance.OnStart;
            @Secret.started += instance.OnSecret;
            @Secret.performed += instance.OnSecret;
            @Secret.canceled += instance.OnSecret;
        }

        private void UnregisterCallbacks(IInputsActions instance)
        {
            @KnobInput.started -= instance.OnKnobInput;
            @KnobInput.performed -= instance.OnKnobInput;
            @KnobInput.canceled -= instance.OnKnobInput;
            @QuickTime.started -= instance.OnQuickTime;
            @QuickTime.performed -= instance.OnQuickTime;
            @QuickTime.canceled -= instance.OnQuickTime;
            @FXButtonL.started -= instance.OnFXButtonL;
            @FXButtonL.performed -= instance.OnFXButtonL;
            @FXButtonL.canceled -= instance.OnFXButtonL;
            @FXButtonR.started -= instance.OnFXButtonR;
            @FXButtonR.performed -= instance.OnFXButtonR;
            @FXButtonR.canceled -= instance.OnFXButtonR;
            @Start.started -= instance.OnStart;
            @Start.performed -= instance.OnStart;
            @Start.canceled -= instance.OnStart;
            @Secret.started -= instance.OnSecret;
            @Secret.performed -= instance.OnSecret;
            @Secret.canceled -= instance.OnSecret;
        }

        public void RemoveCallbacks(IInputsActions instance)
        {
            if (m_Wrapper.m_InputsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInputsActions instance)
        {
            foreach (var item in m_Wrapper.m_InputsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InputsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InputsActions @Inputs => new InputsActions(this);
    public interface IInputsActions
    {
        void OnKnobInput(InputAction.CallbackContext context);
        void OnQuickTime(InputAction.CallbackContext context);
        void OnFXButtonL(InputAction.CallbackContext context);
        void OnFXButtonR(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
        void OnSecret(InputAction.CallbackContext context);
    }
}
