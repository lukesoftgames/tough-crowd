using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour{
    private bool tryInteract;
    private float interactDistance;

    private void Start() {
        tryInteract = false;
        interactDistance = 1.0f;
    }

    private void Update() {
        interact();
    }
    
    public void setTryInteract(bool interactInput) {
        tryInteract = interactInput;
    }

    private void interact() {
        if(!tryInteract) return;
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, interactDistance, Vector2.zero);
        foreach(RaycastHit2D hit in hits) {
            if (hit.collider.gameObject.GetComponent<IInteractable>() != null) {
                if (hit.collider.gameObject == this.gameObject) {
                    continue;
                }
                hit.collider.gameObject.GetComponent<IInteractable>().interact(gameObject);
				
                break;
            }
        }
        tryInteract = false;
    }

}