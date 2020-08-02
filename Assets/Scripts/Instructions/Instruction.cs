using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour{
    public string instructionName;
    
    public virtual void completing() {}
    public virtual void init() {}
    public virtual void onComplete() { PlayerInstructionHandler.completeInstruction(instructionName); }
    public virtual void onStart() { if(PlayerInstructionHandler.instructionListMember(instructionName)) PlayerInstructionHandler.addCompleting(this); }

    public bool sameInstruction(string toCheck) {
        return toCheck == instructionName;
    }
}