using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Win_Test : MonoBehaviour, IInteractable { 
    public void interact(GameObject interactor) {
        if (interactor.GetComponent<PlayerController>().getPlayerRole() == 1) {
            Debug.Log(interactor.name + " has interacted with " + transform.name);
            GameEvents.current.InstructionComplete();
        }
    }
}
