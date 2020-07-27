using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private int playerIndex;

    [SerializeField] private int playerRole = 0;

    private void Awake() {
        GameEvents.current.onChangeRoles += SwapRoles;
        //playerIndex=RoundManager.current.getRoles()[playerRole];
    }

    private void Start() {
        Debug.Log("start");
        //GameEvents.current.onChangeRoles += SwapRoles;
    }

    private void SwapRoles(Dictionary<int, int> roles) {
        //Debug.Log("hunter "+roles[0]);
        //Debug.Log("hunted "+roles[1]);
        playerIndex = roles[playerRole];
        Debug.Log(playerIndex);
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
        Debug.Log("destroy");
        GameEvents.current.onChangeRoles -= SwapRoles;
    }
}
