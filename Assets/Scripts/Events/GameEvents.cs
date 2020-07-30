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

    public event Action<PlayerIndex> onTimerEnd;
    public void TimerEnd(PlayerIndex playerID) {
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

    public event Action<Dictionary<PlayerRole,PlayerIndex>> onChangeRoles;
    public void ChangeRoles(Dictionary<PlayerRole, PlayerIndex> roles) {
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


    public event Action<PlayerIndex> onPlayerKilled;
    public void PlayerKilled(PlayerIndex playerID) {
        if (onPlayerKilled != null) {
            onPlayerKilled(playerID);
        }
    }

    public event Action<Dictionary<PlayerRole, PlayerIndex>> onResetLevel;
    public void ResetLevel(Dictionary<PlayerRole, PlayerIndex> roles) {
        if (onResetLevel != null) {
            onResetLevel(roles);
        }
    }
}
