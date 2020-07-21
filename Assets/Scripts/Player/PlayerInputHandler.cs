using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour {
    public int playerIndex=0;
    private Vector2 inputDirection;
    private PlayerMovement playerMovement;
    private Controls controls = null;
    private string a;
    private void Awake() {
        playerMovement = GetComponent<PlayerMovement>();
        controls = new Controls();
    }
    private void OnEnable() {
        controls.Player.Enable();
    }
    private void getInput() {
        // movement
        if (playerIndex == 0) {
            inputDirection = controls.Player.P1Movement.ReadValue<Vector2>();
            Debug.Log(controls.Player.P1Interact.ReadValue<double>());
        }
        else if (playerIndex == 1) {
            inputDirection = controls.Player.P2Movement.ReadValue<Vector2>();
        }

    }



    private void Update() {
        getInput();
        playerMovement.SetInputVector(inputDirection);
    }


}
