// GENERATED AUTOMATICALLY FROM 'Assets/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Test"",
            ""id"": ""eba1b37c-3256-4561-8863-777565522ec1"",
            ""actions"": [
                {
                    ""name"": ""changeMode"",
                    ""type"": ""Button"",
                    ""id"": ""5e506849-0773-4aa0-8deb-ea1db86f7ab7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b51ace65-a69b-4f81-8bcc-5a6881dc6516"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""windows"",
                    ""action"": ""changeMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""windows"",
            ""bindingGroup"": ""windows"",
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
        }
    ]
}");
        // Test
        m_Test = asset.FindActionMap("Test", throwIfNotFound: true);
        m_Test_changeMode = m_Test.FindAction("changeMode", throwIfNotFound: true);
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

    // Test
    private readonly InputActionMap m_Test;
    private ITestActions m_TestActionsCallbackInterface;
    private readonly InputAction m_Test_changeMode;
    public struct TestActions
    {
        private @InputMaster m_Wrapper;
        public TestActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @changeMode => m_Wrapper.m_Test_changeMode;
        public InputActionMap Get() { return m_Wrapper.m_Test; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TestActions set) { return set.Get(); }
        public void SetCallbacks(ITestActions instance)
        {
            if (m_Wrapper.m_TestActionsCallbackInterface != null)
            {
                @changeMode.started -= m_Wrapper.m_TestActionsCallbackInterface.OnChangeMode;
                @changeMode.performed -= m_Wrapper.m_TestActionsCallbackInterface.OnChangeMode;
                @changeMode.canceled -= m_Wrapper.m_TestActionsCallbackInterface.OnChangeMode;
            }
            m_Wrapper.m_TestActionsCallbackInterface = instance;
            if (instance != null)
            {
                @changeMode.started += instance.OnChangeMode;
                @changeMode.performed += instance.OnChangeMode;
                @changeMode.canceled += instance.OnChangeMode;
            }
        }
    }
    public TestActions @Test => new TestActions(this);
    private int m_windowsSchemeIndex = -1;
    public InputControlScheme windowsScheme
    {
        get
        {
            if (m_windowsSchemeIndex == -1) m_windowsSchemeIndex = asset.FindControlSchemeIndex("windows");
            return asset.controlSchemes[m_windowsSchemeIndex];
        }
    }
    public interface ITestActions
    {
        void OnChangeMode(InputAction.CallbackContext context);
    }
}
