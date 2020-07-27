using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour {
    private int playerIndex;

    [SerializeField] private int playerRole = 0;


    private void Start() {
        // Debug.Log("start");
        GameEvents.current.onChangeRoles += SwapRoles;
    }

    private void SwapRoles(Dictionary<int, int> roles) {
        playerIndex = roles[playerRole];
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

    private void OnDestroy() {
        // Debug.Log("destroy");
        GameEvents.current.onChangeRoles -= SwapRoles;
    }
}
