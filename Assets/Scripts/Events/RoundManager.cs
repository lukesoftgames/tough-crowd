using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RoundManager : MonoBehaviour
{
    public static RoundManager current { get; private set; }
    private int curRoundNum;
    private int p1score;
    private int p2score;
    private PlayerRole p1role;
    private PlayerRole p2role;
    private int completeInstructions;
    private PlayerIndex curHunted;
    [SerializeField] private int instructionsToWin = 3;

    private Dictionary<PlayerRole, PlayerIndex> playerRolesDict = new Dictionary<PlayerRole, PlayerIndex>();
    private Dictionary<PlayerIndex, int> playerScoreDict= new Dictionary<PlayerIndex, int>();

    private void Awake() {
        if (current == null) {
            current = this;
            DontDestroyOnLoad(gameObject);

        } else {
            Destroy(gameObject);
            return;
        }
    }

    private void Start() {
        curRoundNum = 0;
        curHunted = PlayerIndex.Player1;
        completeInstructions = 0;

        playerScoreDict.Add(PlayerIndex.Player1, 0);
        playerScoreDict.Add(PlayerIndex.Player2, 0);

        playerRolesDict.Add(PlayerRole.Hunter, PlayerIndex.Player2);
        playerRolesDict.Add(PlayerRole.Hunted, PlayerIndex.Player1);

        GameEvents.current.onTimerEnd += EndRound;
        GameEvents.current.onPlayerKilled += EndRound;
        GameEvents.current.onInstructionComplete += CheckInstructions;
    }

    private void SwapRoles() {
        if (playerRolesDict[PlayerRole.Hunter] == PlayerIndex.Player1) {
            playerRolesDict[PlayerRole.Hunter] = PlayerIndex.Player2;
            playerRolesDict[PlayerRole.Hunted] = PlayerIndex.Player1;
        } else {
            playerRolesDict[PlayerRole.Hunter] = PlayerIndex.Player1;
            playerRolesDict[PlayerRole.Hunted] = PlayerIndex.Player2;
        }
    }

    public PlayerIndex getCurHunted() {
        return playerRolesDict[PlayerRole.Hunted];
    }

    private void CheckInstructions() {
        completeInstructions += 1;
        if (completeInstructions >= instructionsToWin) {
            EndRound(getCurHunted());
        }
    }

    private void EndRound(PlayerIndex id) {
        Debug.Log("Player " + id + " won");
        GameEvents.current.RoundEnd();
        playerScoreDict[id] += 1;
        curRoundNum++;
        SwapRoles();
        completeInstructions = 0;
        GameEvents.current.ResetLevel(playerRolesDict);
    }

    private void Update() {
        p1score = playerScoreDict[PlayerIndex.Player1];
        p2score = playerScoreDict[PlayerIndex.Player1];
    }


}
