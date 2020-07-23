using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundTimer : MonoBehaviour {
    [SerializeField] private float roundTime = 10;
    private float timeLeft;

    private void Start() {
        timeLeft = roundTime;
    }

    private void EndRound() {
        GameEvents.current.EndRound();
    }

    private void Update() {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0) {
            EndRound();
            timeLeft = roundTime;
        }
    }
}
