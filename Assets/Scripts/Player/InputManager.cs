using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject Hunter;
    [SerializeField] private GameObject Hunted;

    static private bool swapedRoles;

    private Vector2 p1InputDirection;
    private Vector2 p2InputDirection;

    private Controls controls = null;

    private void Awake() {
        controls = new Controls();
    }

    private void P1OnInteract(InputAction.CallbackContext context) {
        if (swapedRoles) {
            Hunter.GetComponent<PlayerInteract>().setTryInteract(true);
        } else {
            Hunted.GetComponent<PlayerInteract>().setTryInteract(true);
        }
    }

    private void P2OnInteract(InputAction.CallbackContext context) {
        if (!swapedRoles) {
            Hunter.GetComponent<PlayerInteract>().setTryInteract(true);
        } else {
            Hunted.GetComponent<PlayerInteract>().setTryInteract(true);
        }
    }

    private void Start() {
        GameEvents.current.onResetLevel += SwapRoles;
    }

    private void SwapRoles(Dictionary<PlayerRole, PlayerIndex> roles) {
        swapedRoles = !swapedRoles;
    }

    private void OnEnable() {
        controls.Player.P1Interact.performed += P1OnInteract;
        controls.Player.P2Interact.performed += P2OnInteract;
        controls.Player.Enable();
    }

    private void OnDisable() {
        controls.Player.P1Interact.performed -= P1OnInteract;
        controls.Player.P2Interact.performed -= P2OnInteract;
        controls.Player.Disable();
    }

    private void getInput() {
        p1InputDirection = controls.Player.P1Movement.ReadValue<Vector2>();
        p2InputDirection = controls.Player.P2Movement.ReadValue<Vector2>();
    }

    private void passInput() {
        if (swapedRoles) {
            Hunter.GetComponent<PlayerMovement>().SetInputVector(p1InputDirection);
            Hunted.GetComponent<PlayerMovement>().SetInputVector(p2InputDirection);
        } else {
            Hunter.GetComponent<PlayerMovement>().SetInputVector(p2InputDirection);
            Hunted.GetComponent<PlayerMovement>().SetInputVector(p1InputDirection);
        }
    }

    private void Update() {
        getInput();
        passInput();
    }

    private void OnDestroy() {
        GameEvents.current.onChangeRoles -= SwapRoles;
        Destroy(Hunter);
        Destroy(Hunted);
    }
}
