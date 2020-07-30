using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private PlayerIndex playerIndex = 0;
    [SerializeField] private PlayerRole playerRole = 0;

    private void Start() {
        // Debug.Log("start");
        GameEvents.current.onResetLevel += SwapRoles;
    }

    private void SwapRoles(Dictionary<PlayerRole, PlayerIndex> roles) {
        playerIndex = roles[playerRole];
        resetPosition();
    }

    public PlayerIndex getPlayerIndex() {
        return playerIndex;
    }

    public PlayerRole getPlayerRole() {
        return playerRole;
    }

    public void setPlayerRole(PlayerRole newRole) {
        playerRole = newRole;
    }

    private void resetPosition() {
        this.transform.position = new Vector2(Random.Range(-8.8f, 8.8f), Random.Range(-5f, 5f));
    }

    private void OnDestroy() {
        // Debug.Log("destroy");
        GameEvents.current.onChangeRoles -= SwapRoles;
    }
}
