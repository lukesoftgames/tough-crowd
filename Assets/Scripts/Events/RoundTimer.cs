using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundTimer : MonoBehaviour {
    [SerializeField] private float roundTime = 60;
    private float timeLeft;

    private void Start() {
        GameEvents.current.onRoundEnd += ResetTimer;
        timeLeft = roundTime;

    }

    private void ResetTimer() {
        timeLeft = roundTime;
    }

    private void EndTimer() {
        Debug.Log("TimerDone");
        GameEvents.current.TimerEnd(this.GetComponent<RoundManager>().getCurHunted());
        timeLeft = roundTime;
    }

    private void Update() {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0) {
            EndTimer();
        }
    }
}
