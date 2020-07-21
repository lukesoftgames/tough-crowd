using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour {
    [SerializeField] private int playerIndex=0;
    private Vector2 inputDirection;
    private bool inputTryInteract;
    private PlayerMovement playerMovement;
    private PlayerInteract playerInteract;
    private Controls controls = null;
    private void Awake() {
        playerMovement = GetComponent<PlayerMovement>();
        playerInteract = GetComponent<PlayerInteract>();
        controls = new Controls();
        inputTryInteract = false;
        if (playerIndex == 0) {
            controls.Player.P1Interact.performed += _ => OnInteract();
        } else if (playerIndex == 1) {
            controls.Player.P2Interact.performed += _ => OnInteract();
        }
    }
    private void OnEnable() {
        controls.Player.Enable();
    }
    private void getInput() {
        if (playerIndex == 0) {
            inputDirection = controls.Player.P1Movement.ReadValue<Vector2>();
        }
        else if (playerIndex == 1) {
            inputDirection = controls.Player.P2Movement.ReadValue<Vector2>();
        }

    }

    public void OnInteract() {
        playerInteract.setTryInteract(true);
    }



    private void Update() {
        getInput();
        playerMovement.SetInputVector(inputDirection);
        //playerInteract.setTryInteract(inputTryInteract);
    }


}
