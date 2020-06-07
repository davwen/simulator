// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputMaster.inputactions'

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
                },
                {
                    ""name"": ""mousePos"",
                    ""type"": ""Button"",
                    ""id"": ""23a431f9-4eb0-4d78-b6f1-e4880c146c7d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""dragCamera"",
                    ""type"": ""Button"",
                    ""id"": ""8e09c615-5571-4d58-b7b4-7c971fa751f0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""zoom"",
                    ""type"": ""PassThrough"",
                    ""id"": ""821835e3-453f-4dae-84fc-926f85a666ad"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""copy"",
                    ""type"": ""Button"",
                    ""id"": ""44a61ec1-d992-4d67-a7fd-9ed21f33637c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""multiSelect"",
                    ""type"": ""Button"",
                    ""id"": ""32a1016d-5513-4482-9417-5dbe06374bc7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""freeRelease"",
                    ""type"": ""Button"",
                    ""id"": ""743ff649-7150-4b1a-96d4-52608e878613"",
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
                    ""groups"": ""windows"",
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
                    ""groups"": ""windows"",
                    ""action"": ""togglePause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e1bfd22-32ab-4bbf-b7e9-84a1a7afa2a7"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""windows"",
                    ""action"": ""mousePos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""66651214-deef-4e34-abaa-50cf17f82812"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""windows"",
                    ""action"": ""dragCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""54680b97-27f1-43fb-9a7c-777a19cc0488"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""windows"",
                    ""action"": ""zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""ba1ea50a-5eb5-4299-b75f-78b74bef92b1"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""copy"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Modifier"",
                    ""id"": ""0c16a75a-8af4-41f7-9682-570d94f86037"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""windows"",
                    ""action"": ""copy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button"",
                    ""id"": ""be6cf3f0-d538-46f4-a9ba-4015ef9efeef"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""windows"",
                    ""action"": ""copy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8322b52a-d74a-482b-8d92-023c5327b7df"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""multiSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c1ac1d4d-3e94-4975-81d4-d5059ae63ebd"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""freeRelease"",
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
        m_Editor_mousePos = m_Editor.FindAction("mousePos", throwIfNotFound: true);
        m_Editor_dragCamera = m_Editor.FindAction("dragCamera", throwIfNotFound: true);
        m_Editor_zoom = m_Editor.FindAction("zoom", throwIfNotFound: true);
        m_Editor_copy = m_Editor.FindAction("copy", throwIfNotFound: true);
        m_Editor_multiSelect = m_Editor.FindAction("multiSelect", throwIfNotFound: true);
        m_Editor_freeRelease = m_Editor.FindAction("freeRelease", throwIfNotFound: true);
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
    private readonly InputAction m_Editor_mousePos;
    private readonly InputAction m_Editor_dragCamera;
    private readonly InputAction m_Editor_zoom;
    private readonly InputAction m_Editor_copy;
    private readonly InputAction m_Editor_multiSelect;
    private readonly InputAction m_Editor_freeRelease;
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
        public InputAction @mousePos => m_Wrapper.m_Editor_mousePos;
        public InputAction @dragCamera => m_Wrapper.m_Editor_dragCamera;
        public InputAction @zoom => m_Wrapper.m_Editor_zoom;
        public InputAction @copy => m_Wrapper.m_Editor_copy;
        public InputAction @multiSelect => m_Wrapper.m_Editor_multiSelect;
        public InputAction @freeRelease => m_Wrapper.m_Editor_freeRelease;
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
                @mousePos.started -= m_Wrapper.m_EditorActionsCallbackInterface.OnMousePos;
                @mousePos.performed -= m_Wrapper.m_EditorActionsCallbackInterface.OnMousePos;
                @mousePos.canceled -= m_Wrapper.m_EditorActionsCallbackInterface.OnMousePos;
                @dragCamera.started -= m_Wrapper.m_EditorActionsCallbackInterface.OnDragCamera;
                @dragCamera.performed -= m_Wrapper.m_EditorActionsCallbackInterface.OnDragCamera;
                @dragCamera.canceled -= m_Wrapper.m_EditorActionsCallbackInterface.OnDragCamera;
                @zoom.started -= m_Wrapper.m_EditorActionsCallbackInterface.OnZoom;
                @zoom.performed -= m_Wrapper.m_EditorActionsCallbackInterface.OnZoom;
                @zoom.canceled -= m_Wrapper.m_EditorActionsCallbackInterface.OnZoom;
                @copy.started -= m_Wrapper.m_EditorActionsCallbackInterface.OnCopy;
                @copy.performed -= m_Wrapper.m_EditorActionsCallbackInterface.OnCopy;
                @copy.canceled -= m_Wrapper.m_EditorActionsCallbackInterface.OnCopy;
                @multiSelect.started -= m_Wrapper.m_EditorActionsCallbackInterface.OnMultiSelect;
                @multiSelect.performed -= m_Wrapper.m_EditorActionsCallbackInterface.OnMultiSelect;
                @multiSelect.canceled -= m_Wrapper.m_EditorActionsCallbackInterface.OnMultiSelect;
                @freeRelease.started -= m_Wrapper.m_EditorActionsCallbackInterface.OnFreeRelease;
                @freeRelease.performed -= m_Wrapper.m_EditorActionsCallbackInterface.OnFreeRelease;
                @freeRelease.canceled -= m_Wrapper.m_EditorActionsCallbackInterface.OnFreeRelease;
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
                @mousePos.started += instance.OnMousePos;
                @mousePos.performed += instance.OnMousePos;
                @mousePos.canceled += instance.OnMousePos;
                @dragCamera.started += instance.OnDragCamera;
                @dragCamera.performed += instance.OnDragCamera;
                @dragCamera.canceled += instance.OnDragCamera;
                @zoom.started += instance.OnZoom;
                @zoom.performed += instance.OnZoom;
                @zoom.canceled += instance.OnZoom;
                @copy.started += instance.OnCopy;
                @copy.performed += instance.OnCopy;
                @copy.canceled += instance.OnCopy;
                @multiSelect.started += instance.OnMultiSelect;
                @multiSelect.performed += instance.OnMultiSelect;
                @multiSelect.canceled += instance.OnMultiSelect;
                @freeRelease.started += instance.OnFreeRelease;
                @freeRelease.performed += instance.OnFreeRelease;
                @freeRelease.canceled += instance.OnFreeRelease;
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
        void OnMousePos(InputAction.CallbackContext context);
        void OnDragCamera(InputAction.CallbackContext context);
        void OnZoom(InputAction.CallbackContext context);
        void OnCopy(InputAction.CallbackContext context);
        void OnMultiSelect(InputAction.CallbackContext context);
        void OnFreeRelease(InputAction.CallbackContext context);
    }
}
