// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/Controls.inputactions'

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
            ""name"": ""Player"",
            ""id"": ""4ab8c8c9-4455-4df4-9099-582c66173308"",
            ""actions"": [
                {
                    ""name"": ""P1Movement"",
                    ""type"": ""Button"",
                    ""id"": ""335e8e75-0b1e-4c8f-ab42-8eeca9205e9e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""P2Movement"",
                    ""type"": ""Button"",
                    ""id"": ""fbf4607c-bdda-4890-b2c7-bd274f21129d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""P1Interact"",
                    ""type"": ""Button"",
                    ""id"": ""ef8b07b6-038a-4cf4-8c78-ba5beadcde39"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""P2Interact"",
                    ""type"": ""Button"",
                    ""id"": ""fb4fddb9-7d5d-4431-a981-6def72174631"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""f1b51b96-d5f6-4edd-b1f4-647add3eb852"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P1Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""80201dc4-cccd-4c49-b937-42a2af896bcd"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P1Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fcbff69d-2c6f-45e6-8622-431e0586cd64"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P1Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""029bfea6-84df-4403-825a-ed38f59d59db"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P1Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""52ca0988-de19-47cb-83f1-670d2aa2abf9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P1Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""IJKL"",
                    ""id"": ""8a33a3fd-0505-406d-aace-7974d4545fc1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P2Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0809938d-5def-42fa-a9a9-d5f9a5d795ab"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P2Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c81967be-ab53-417c-8b92-7d7cdd472a7d"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P2Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c0e7cb20-3bdf-4174-a5c4-60402c90e8ca"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P2Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""cf9642aa-a7e9-464b-8e62-da91435dc467"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P2Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f9ea619e-aaa4-4260-842a-49cdfcfa5b97"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P1Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71459885-6014-4989-91e4-31e4a0c3bb24"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P2Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_P1Movement = m_Player.FindAction("P1Movement", throwIfNotFound: true);
        m_Player_P2Movement = m_Player.FindAction("P2Movement", throwIfNotFound: true);
        m_Player_P1Interact = m_Player.FindAction("P1Interact", throwIfNotFound: true);
        m_Player_P2Interact = m_Player.FindAction("P2Interact", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_P1Movement;
    private readonly InputAction m_Player_P2Movement;
    private readonly InputAction m_Player_P1Interact;
    private readonly InputAction m_Player_P2Interact;
    public struct PlayerActions
    {
        private @Controls m_Wrapper;
        public PlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @P1Movement => m_Wrapper.m_Player_P1Movement;
        public InputAction @P2Movement => m_Wrapper.m_Player_P2Movement;
        public InputAction @P1Interact => m_Wrapper.m_Player_P1Interact;
        public InputAction @P2Interact => m_Wrapper.m_Player_P2Interact;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @P1Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnP1Movement;
                @P1Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnP1Movement;
                @P1Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnP1Movement;
                @P2Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnP2Movement;
                @P2Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnP2Movement;
                @P2Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnP2Movement;
                @P1Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnP1Interact;
                @P1Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnP1Interact;
                @P1Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnP1Interact;
                @P2Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnP2Interact;
                @P2Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnP2Interact;
                @P2Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnP2Interact;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @P1Movement.started += instance.OnP1Movement;
                @P1Movement.performed += instance.OnP1Movement;
                @P1Movement.canceled += instance.OnP1Movement;
                @P2Movement.started += instance.OnP2Movement;
                @P2Movement.performed += instance.OnP2Movement;
                @P2Movement.canceled += instance.OnP2Movement;
                @P1Interact.started += instance.OnP1Interact;
                @P1Interact.performed += instance.OnP1Interact;
                @P1Interact.canceled += instance.OnP1Interact;
                @P2Interact.started += instance.OnP2Interact;
                @P2Interact.performed += instance.OnP2Interact;
                @P2Interact.canceled += instance.OnP2Interact;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnP1Movement(InputAction.CallbackContext context);
        void OnP2Movement(InputAction.CallbackContext context);
        void OnP1Interact(InputAction.CallbackContext context);
        void OnP2Interact(InputAction.CallbackContext context);
    }
}
