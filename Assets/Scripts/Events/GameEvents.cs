using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour {
    public static GameEvents current;
    private void Awake() {
        if (current == null) {
            current = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
            return;
        }
    }

    public event Action<int> onTimerEnd;
    public void TimerEnd(int playerID) {
        if (onTimerEnd != null) {
            onTimerEnd(playerID);
        }
    }

    public event Action onRoundEnd;
    public void RoundEnd() {
        if (onRoundEnd != null) {
            onRoundEnd();
        }
    }

    public event Action<Dictionary<int,int>> onChangeRoles;
    public void ChangeRoles(Dictionary<int,int> roles) {
        if (onChangeRoles != null) {
            onChangeRoles(roles);
        }
    }

    public event Action onInstructionComplete;
    public void InstructionComplete() {
        if (onInstructionComplete != null) {
            onInstructionComplete();
        }
    }


    public event Action<int> onPlayerKilled;
    public void PlayerKilled(int playerID) {
        if (onPlayerKilled != null) {
            onPlayerKilled(playerID);
        }
    }
}
