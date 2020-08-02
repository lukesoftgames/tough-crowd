using UnityEngine;

public class InstructionAcquire : Instruction {
    public string objectName;

    private void Awake() {
        instructionName = ("Acquire " + objectName);
    }

    public override void completing() {
        base.completing();
        onComplete();
    }

    public override void onComplete() {
        base.onComplete();
        Debug.Log("Acquired " + objectName);
        Destroy(gameObject);
    }
}