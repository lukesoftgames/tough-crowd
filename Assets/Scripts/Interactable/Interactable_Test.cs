using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Test : Interactable {
    private void Awake() {
        associatedInstruction = GetComponent<Instruction>();

        if(associatedInstruction != null) {
            associatedInstruction.init();
        }
    }

    public override void interact(GameObject interactor) {
        Debug.Log(interactor.name + " has interacted with " + transform.name);
        associatedInstruction.onStart();
    }
}