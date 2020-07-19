using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Test : MonoBehaviour, IInteractable {
    public void interact(GameObject interactor) {
        Debug.Log(interactor.name + " has interacted with " + transform.name);
    }
}