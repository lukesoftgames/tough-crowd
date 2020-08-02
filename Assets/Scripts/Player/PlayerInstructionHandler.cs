using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInstructionHandler : MonoBehaviour {
    private const int NUMBER_OF_TASKS = 3;
    [SerializeField] private static List<UnityEngine.UI.Text> displayInstructions;
    private static List<Instruction> completing = new List<Instruction>();
    private static List<Instruction> instructionList = new List<Instruction>();

    private void Start() {
        displayInstructions = new List<UnityEngine.UI.Text>(gameObject.GetComponentsInChildren<UnityEngine.UI.Text>());
        generateInstructions();
    }

    private void Update() {
        List<Instruction> copyCompleting = new List<Instruction>(completing);
        foreach(Instruction instruction in copyCompleting) instruction.completing();
    }

    public static void addCompleting(Instruction toAdd) {
        foreach(Instruction instruction in completing) if(instruction.instructionName == toAdd.instructionName) return;
        completing.Add(toAdd);
    }

    public static void completeInstruction(string toComplete) {
        for(int i = 0; i < instructionList.Count; i++) {
            if(instructionList[i].instructionName == toComplete) {
                instructionList.RemoveAt(i);
                displayInstructions[i].GetComponent<UnityEngine.UI.Text>().text += "\n---COMPLETED---";
                displayInstructions[i].GetComponent<UnityEngine.UI.Text>().color = new Color(1.0f, 0.0f, 0.0f, 0.3f);
                break;
            }
        }

        for(int i = 0; i < completing.Count; i++) {
            if(completing[i].instructionName == toComplete) { completing.RemoveAt(i); }
            break;
        }
    }

    public void generateInstructions() {
        //Code to find instructions from available interactables
        var enumPot = FindObjectsOfType<MonoBehaviour>().OfType<Interactable>();
        List<Interactable> potentials = new List<Interactable>();

        foreach(Interactable e in enumPot) potentials.Add(e);

        if(potentials.Count <= 3) {
            foreach(Interactable pot in potentials) {
                instructionList.Add(pot.getAssociatedInstruction());
            }
        } else {
            Debug.Log("Random selection of tasks");
        }

        for(int i = 0; i < instructionList.Count && i < displayInstructions.Count && i < NUMBER_OF_TASKS; i++) {
            UnityEngine.UI.Text text = displayInstructions[i].GetComponent<UnityEngine.UI.Text>();
            text.text = instructionList[i].instructionName;
            text.fontStyle = FontStyle.Bold;
        }
    }

    public static bool instructionListMember(string toCheck) {
        foreach(Instruction instruction in instructionList) if(instruction.instructionName == toCheck) return true;
        return false;
    }
}