using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour{
    protected Instruction associatedInstruction;

    public virtual void interact(GameObject interactor) { }
    public virtual Instruction getAssociatedInstruction() { return associatedInstruction; }
}