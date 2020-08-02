using System.Collections;
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
        interact();
    }
    
    public void setTryInteract(bool interactInput) {
        tryInteract = interactInput;
    }

    private void interact() {
        if(!tryInteract) return;
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, interactDistance, Vector2.zero);

        foreach(RaycastHit2D hit in hits) {
            if(hit.collider.gameObject.GetComponent<Interactable>() != null) {
                hit.collider.gameObject.GetComponent<Interactable>().interact(gameObject);

                break;
            }
        }
        tryInteract = false;
    }

    //private void getInput() {
    //    tryInteract = Input.GetKeyDown(KeyCode.E);

    //    return;
    //}
}