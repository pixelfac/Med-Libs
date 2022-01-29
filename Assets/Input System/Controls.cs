// GENERATED AUTOMATICALLY FROM 'Assets/Input System/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Record"",
            ""id"": ""0b4a0fdf-b7f8-409a-88a8-504b5f422c9c"",
            ""actions"": [
                {
                    ""name"": ""Record"",
                    ""type"": ""Button"",
                    ""id"": ""b3aefe37-7b2c-4291-a982-b40ada7c1779"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e02e39a6-2a61-448a-9635-b2786ca888c3"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Record"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Record
        m_Record = asset.FindActionMap("Record", throwIfNotFound: true);
        m_Record_Record = m_Record.FindAction("Record", throwIfNotFound: true);
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

    // Record
    private readonly InputActionMap m_Record;
    private IRecordActions m_RecordActionsCallbackInterface;
    private readonly InputAction m_Record_Record;
    public struct RecordActions
    {
        private @Controls m_Wrapper;
        public RecordActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Record => m_Wrapper.m_Record_Record;
        public InputActionMap Get() { return m_Wrapper.m_Record; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RecordActions set) { return set.Get(); }
        public void SetCallbacks(IRecordActions instance)
        {
            if (m_Wrapper.m_RecordActionsCallbackInterface != null)
            {
                @Record.started -= m_Wrapper.m_RecordActionsCallbackInterface.OnRecord;
                @Record.performed -= m_Wrapper.m_RecordActionsCallbackInterface.OnRecord;
                @Record.canceled -= m_Wrapper.m_RecordActionsCallbackInterface.OnRecord;
            }
            m_Wrapper.m_RecordActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Record.started += instance.OnRecord;
                @Record.performed += instance.OnRecord;
                @Record.canceled += instance.OnRecord;
            }
        }
    }
    public RecordActions @Record => new RecordActions(this);
    public interface IRecordActions
    {
        void OnRecord(InputAction.CallbackContext context);
    }
}
