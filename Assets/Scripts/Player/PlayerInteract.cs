﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {
    private bool tryInteract;
    private float interactDistance;

    private void Start() {
        tryInteract = false;
        interactDistance = 5.0f;
    }

    private void Update() {
        getInput();
        interact();
    }

    private void interact() {
        if(!tryInteract) return;
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, interactDistance, Vector2.zero);

        foreach(RaycastHit2D hit in hits) {
            if(hit.collider.gameObject.GetComponent<IInteractable>() != null) {
                hit.collider.gameObject.GetComponent<IInteractable>().interact(gameObject);

                break;
            }
        }
    }

    private void getInput() {
        tryInteract = Input.GetKeyDown(KeyCode.E);

        return;
    }
}