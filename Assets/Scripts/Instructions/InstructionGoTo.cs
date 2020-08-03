using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionGoTo : Instruction {
    public const float radius = 1.0f;
    public string locationName;

    private void Awake() {
        instructionName = ("Go to " + locationName);
    }

    private void Start() {
        onStart();
    }

    public override void completing() {
        base.completing();
        if(Vector3.Distance(transform.position, PlayerInstructionHandler.player.transform.position) < radius) onComplete();
    }
}