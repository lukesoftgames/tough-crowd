using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private int playerIndex = 0;
    [SerializeField] private int playerRole = 0;

    private void Start() {
        // Debug.Log("start");
        GameEvents.current.onResetLevel += SwapRoles;
    }

    private void SwapRoles(Dictionary<int, int> roles) {
        playerIndex = roles[playerRole];
        resetPosition();
    }

    public int getPlayerIndex() {
        return playerIndex;
    }

    public int getPlayerRole() {
        return playerRole;
    }

    public void setPlayerRole(int newRole) {
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
