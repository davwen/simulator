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
            ""name"": ""Editor"",
            ""id"": ""eba1b37c-3256-4561-8863-777565522ec1"",
            ""actions"": [
                {
                    ""name"": ""changeMode"",
                    ""type"": ""Button"",
                    ""id"": ""5e506849-0773-4aa0-8deb-ea1db86f7ab7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""begin"",
                    ""type"": ""Button"",
                    ""id"": ""957a9930-0f53-406f-b159-1c8c13d99ea1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""stop"",
                    ""type"": ""Button"",
                    ""id"": ""2e4519e4-9570-4090-8bac-d7c60aa5cb6d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""pause"",
                    ""type"": ""Button"",
                    ""id"": ""544aa477-58a2-4823-8c20-f2138830a4d3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""resume"",
                    ""type"": ""Button"",
                    ""id"": ""3e3e00b9-a9cf-4621-96bd-793a4f1bfc1c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""spawn"",
                    ""type"": ""Button"",
                    ""id"": ""ad94b1bc-7f3c-4a7a-8b9b-5c4fbea172e8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""select"",
                    ""type"": ""Button"",
                    ""id"": ""993a25d5-f484-425e-bdba-1c43d7edbcdb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""deselect"",
                    ""type"": ""Button"",
                    ""id"": ""e62e3de7-43ef-4350-91d5-ca04d9ab8c12"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""drag"",
                    ""type"": ""Button"",
                    ""id"": ""081e87ca-6732-44f5-901f-0b75c461fda6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""destroy"",
                    ""type"": ""Button"",
                    ""id"": ""86222d09-6437-4175-8755-d85ec62c3ff5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""togglePause"",
                    ""type"": ""Button"",
                    ""id"": ""c0e1bc22-0833-4a82-acba-d2e345d67fd2"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""5309c62b-255f-4d62-bdb4-26d3af752368"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""windows"",
                    ""action"": ""begin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1b55332-030b-4de9-b3f7-6c81c2c74354"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""windows"",
                    ""action"": ""stop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87d89f2f-6105-4457-aaff-9ccd19b2c777"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""windows"",
                    ""action"": ""pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd36c2f8-e9e5-4345-94a4-078908ac9f80"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""windows"",
                    ""action"": ""resume"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53132f5e-21f3-4e0f-9071-ee56003ca48c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""windows"",
                    ""action"": ""spawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""232e6f79-cd55-4fd6-8ff2-6a287cc0a479"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""windows"",
                    ""action"": ""select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""719313e7-a631-48af-bfc0-c19b7044ac7a"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""windows"",
                    ""action"": ""deselect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0415d8c-d9bf-4504-a59c-f285a3d400fa"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""windows"",
                    ""action"": ""drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cdc4dfba-7e3b-4f93-99c6-31e22d3fb4f4"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""destroy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48aeb649-78c8-4b38-8960-abbbf3712866"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""togglePause"",
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
        // Editor
        m_Editor = asset.FindActionMap("Editor", throwIfNotFound: true);
        m_Editor_changeMode = m_Editor.FindAction("changeMode", throwIfNotFound: true);
        m_Editor_begin = m_Editor.FindAction("begin", throwIfNotFound: true);
        m_Editor_stop = m_Editor.FindAction("stop", throwIfNotFound: true);
        m_Editor_pause = m_Editor.FindAction("pause", throwIfNotFound: true);
        m_Editor_resume = m_Editor.FindAction("resume", throwIfNotFound: true);
        m_Editor_spawn = m_Editor.FindAction("spawn", throwIfNotFound: true);
        m_Editor_select = m_Editor.FindAction("select", throwIfNotFound: true);
        m_Editor_deselect = m_Editor.FindAction("deselect", throwIfNotFound: true);
        m_Editor_drag = m_Editor.FindAction("drag", throwIfNotFound: true);
        m_Editor_destroy = m_Editor.FindAction("destroy", throwIfNotFound: true);
        m_Editor_togglePause = m_Editor.FindAction("togglePause", throwIfNotFound: true);
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

    // Editor
    private readonly InputActionMap m_Editor;
    private IEditorActions m_EditorActionsCallbackInterface;
    private readonly InputAction m_Editor_changeMode;
    private readonly InputAction m_Editor_begin;
    private readonly InputAction m_Editor_stop;
    private readonly InputAction m_Editor_pause;
    private readonly InputAction m_Editor_resume;
    private readonly InputAction m_Editor_spawn;
    private readonly InputAction m_Editor_select;
    private readonly InputAction m_Editor_deselect;
    private readonly InputAction m_Editor_drag;
    private readonly InputAction m_Editor_destroy;
    private readonly InputAction m_Editor_togglePause;
    public struct EditorActions
    {
        private @InputMaster m_Wrapper;
        public EditorActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @changeMode => m_Wrapper.m_Editor_changeMode;
        public InputAction @begin => m_Wrapper.m_Editor_begin;
        public InputAction @stop => m_Wrapper.m_Editor_stop;
        public InputAction @pause => m_Wrapper.m_Editor_pause;
        public InputAction @resume => m_Wrapper.m_Editor_resume;
        public InputAction @spawn => m_Wrapper.m_Editor_spawn;
        public InputAction @select => m_Wrapper.m_Editor_select;
        public InputAction @deselect => m_Wrapper.m_Editor_deselect;
        public InputAction @drag => m_Wrapper.m_Editor_drag;
        public InputAction @destroy => m_Wrapper.m_Editor_destroy;
        public InputAction @togglePause => m_Wrapper.m_Editor_togglePause;
        public InputActionMap Get() { return m_Wrapper.m_Editor; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(EditorActions set) { return set.Get(); }
        public void SetCallbacks(IEditorActions instance)
        {
            if (m_Wrapper.m_EditorActionsCallbackInterface != null)
            {
                @changeMode.started -= m_Wrapper.m_EditorActionsCallbackInterface.OnChangeMode;
                @changeMode.performed -= m_Wrapper.m_EditorActionsCallbackInterface.OnChangeMode;
                @changeMode.canceled -= m_Wrapper.m_EditorActionsCallbackInterface.OnChangeMode;
                @begin.started -= m_Wrapper.m_EditorActionsCallbackInterface.OnBegin;
                @begin.performed -= m_Wrapper.m_EditorActionsCallbackInterface.OnBegin;
                @begin.canceled -= m_Wrapper.m_EditorActionsCallbackInterface.OnBegin;
                @stop.started -= m_Wrapper.m_EditorActionsCallbackInterface.OnStop;
                @stop.performed -= m_Wrapper.m_EditorActionsCallbackInterface.OnStop;
                @stop.canceled -= m_Wrapper.m_EditorActionsCallbackInterface.OnStop;
                @pause.started -= m_Wrapper.m_EditorActionsCallbackInterface.OnPause;
                @pause.performed -= m_Wrapper.m_EditorActionsCallbackInterface.OnPause;
                @pause.canceled -= m_Wrapper.m_EditorActionsCallbackInterface.OnPause;
                @resume.started -= m_Wrapper.m_EditorActionsCallbackInterface.OnResume;
                @resume.performed -= m_Wrapper.m_EditorActionsCallbackInterface.OnResume;
                @resume.canceled -= m_Wrapper.m_EditorActionsCallbackInterface.OnResume;
                @spawn.started -= m_Wrapper.m_EditorActionsCallbackInterface.OnSpawn;
                @spawn.performed -= m_Wrapper.m_EditorActionsCallbackInterface.OnSpawn;
                @spawn.canceled -= m_Wrapper.m_EditorActionsCallbackInterface.OnSpawn;
                @select.started -= m_Wrapper.m_EditorActionsCallbackInterface.OnSelect;
                @select.performed -= m_Wrapper.m_EditorActionsCallbackInterface.OnSelect;
                @select.canceled -= m_Wrapper.m_EditorActionsCallbackInterface.OnSelect;
                @deselect.started -= m_Wrapper.m_EditorActionsCallbackInterface.OnDeselect;
                @deselect.performed -= m_Wrapper.m_EditorActionsCallbackInterface.OnDeselect;
                @deselect.canceled -= m_Wrapper.m_EditorActionsCallbackInterface.OnDeselect;
                @drag.started -= m_Wrapper.m_EditorActionsCallbackInterface.OnDrag;
                @drag.performed -= m_Wrapper.m_EditorActionsCallbackInterface.OnDrag;
                @drag.canceled -= m_Wrapper.m_EditorActionsCallbackInterface.OnDrag;
                @destroy.started -= m_Wrapper.m_EditorActionsCallbackInterface.OnDestroy;
                @destroy.performed -= m_Wrapper.m_EditorActionsCallbackInterface.OnDestroy;
                @destroy.canceled -= m_Wrapper.m_EditorActionsCallbackInterface.OnDestroy;
                @togglePause.started -= m_Wrapper.m_EditorActionsCallbackInterface.OnTogglePause;
                @togglePause.performed -= m_Wrapper.m_EditorActionsCallbackInterface.OnTogglePause;
                @togglePause.canceled -= m_Wrapper.m_EditorActionsCallbackInterface.OnTogglePause;
            }
            m_Wrapper.m_EditorActionsCallbackInterface = instance;
            if (instance != null)
            {
                @changeMode.started += instance.OnChangeMode;
                @changeMode.performed += instance.OnChangeMode;
                @changeMode.canceled += instance.OnChangeMode;
                @begin.started += instance.OnBegin;
                @begin.performed += instance.OnBegin;
                @begin.canceled += instance.OnBegin;
                @stop.started += instance.OnStop;
                @stop.performed += instance.OnStop;
                @stop.canceled += instance.OnStop;
                @pause.started += instance.OnPause;
                @pause.performed += instance.OnPause;
                @pause.canceled += instance.OnPause;
                @resume.started += instance.OnResume;
                @resume.performed += instance.OnResume;
                @resume.canceled += instance.OnResume;
                @spawn.started += instance.OnSpawn;
                @spawn.performed += instance.OnSpawn;
                @spawn.canceled += instance.OnSpawn;
                @select.started += instance.OnSelect;
                @select.performed += instance.OnSelect;
                @select.canceled += instance.OnSelect;
                @deselect.started += instance.OnDeselect;
                @deselect.performed += instance.OnDeselect;
                @deselect.canceled += instance.OnDeselect;
                @drag.started += instance.OnDrag;
                @drag.performed += instance.OnDrag;
                @drag.canceled += instance.OnDrag;
                @destroy.started += instance.OnDestroy;
                @destroy.performed += instance.OnDestroy;
                @destroy.canceled += instance.OnDestroy;
                @togglePause.started += instance.OnTogglePause;
                @togglePause.performed += instance.OnTogglePause;
                @togglePause.canceled += instance.OnTogglePause;
            }
        }
    }
    public EditorActions @Editor => new EditorActions(this);
    private int m_windowsSchemeIndex = -1;
    public InputControlScheme windowsScheme
    {
        get
        {
            if (m_windowsSchemeIndex == -1) m_windowsSchemeIndex = asset.FindControlSchemeIndex("windows");
            return asset.controlSchemes[m_windowsSchemeIndex];
        }
    }
    public interface IEditorActions
    {
        void OnChangeMode(InputAction.CallbackContext context);
        void OnBegin(InputAction.CallbackContext context);
        void OnStop(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnResume(InputAction.CallbackContext context);
        void OnSpawn(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnDeselect(InputAction.CallbackContext context);
        void OnDrag(InputAction.CallbackContext context);
        void OnDestroy(InputAction.CallbackContext context);
        void OnTogglePause(InputAction.CallbackContext context);
    }
}
