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
                    ""type"": ""Button"",
                    ""id"": ""50a0796e-2280-488c-a6d6-bd16e223b150"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FX-Buttons"",
                    ""type"": ""Value"",
                    ""id"": ""09b3e939-6a80-42d8-82af-29d22fed769f"",
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
                    ""name"": """",
                    ""id"": ""e075430a-12b4-4a90-a416-7c898b996816"",
                    ""path"": ""<HID::VIRGOO TURBOCHARGER VIRGOO TURBOCHARGER>/button5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickTime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""996bc09c-1b71-4e93-bc7e-d2abaef0ac4a"",
                    ""path"": ""<HID::VIRGOO TURBOCHARGER VIRGOO TURBOCHARGER>/button7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickTime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""06f3546f-19f1-4d80-a0f5-77b034352acc"",
                    ""path"": ""<HID::VIRGOO TURBOCHARGER VIRGOO TURBOCHARGER>/button8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickTime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""43ed4535-45bc-42e1-b773-28f164867f81"",
                    ""path"": ""<HID::VIRGOO TURBOCHARGER VIRGOO TURBOCHARGER>/button6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickTime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f23442c2-96ec-4e04-9288-dd376e2f1b34"",
                    ""path"": ""<HID::VIRGOO TURBOCHARGER VIRGOO TURBOCHARGER>/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FX-Buttons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""716d80bb-b716-44f2-8bac-b447a8795b0b"",
                    ""path"": ""<HID::VIRGOO TURBOCHARGER VIRGOO TURBOCHARGER>/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FX-Buttons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
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
                    ""id"": ""06ce33c2-9925-489e-9e7f-ebd154e2fb96"",
                    ""path"": ""<HID::VIRGOO TURBOCHARGER VIRGOO TURBOCHARGER>/button4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Secret"",
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
        m_Inputs_FXButtons = m_Inputs.FindAction("FX-Buttons", throwIfNotFound: true);
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
    private readonly InputAction m_Inputs_FXButtons;
    private readonly InputAction m_Inputs_Start;
    private readonly InputAction m_Inputs_Secret;
    public struct InputsActions
    {
        private @PlayerInputs m_Wrapper;
        public InputsActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @KnobInput => m_Wrapper.m_Inputs_KnobInput;
        public InputAction @QuickTime => m_Wrapper.m_Inputs_QuickTime;
        public InputAction @FXButtons => m_Wrapper.m_Inputs_FXButtons;
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
            @FXButtons.started += instance.OnFXButtons;
            @FXButtons.performed += instance.OnFXButtons;
            @FXButtons.canceled += instance.OnFXButtons;
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
            @FXButtons.started -= instance.OnFXButtons;
            @FXButtons.performed -= instance.OnFXButtons;
            @FXButtons.canceled -= instance.OnFXButtons;
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
        void OnFXButtons(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
        void OnSecret(InputAction.CallbackContext context);
    }
}
