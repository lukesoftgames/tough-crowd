using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{

    private void Start() {
        GameEvents.current.onEndRound += EndRound;
    }

    private void EndRound() {
        Debug.Log("End of round");
    }
}
