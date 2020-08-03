using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractable : Interactable {
    public override void interact(GameObject interactor) {
        Debug.Log(interactor.name + " has interacted with " + transform.name);
        GameEvents.current.PlayerKilled(interactor.GetComponent<PlayerController>().getPlayerIndex());
    }
}