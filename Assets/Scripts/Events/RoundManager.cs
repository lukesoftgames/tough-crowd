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
    private int p1role;
    private int p2role;
    private int completeInstructions;
    private int curHunted;
    [SerializeField] private int instructionsToWin = 3;

    private Dictionary<int, int> playerRolesDict = new Dictionary<int, int>();
    private Dictionary<int, int> playerScoreDict= new Dictionary<int, int>();

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
        curHunted = 0;
        completeInstructions = 0;

        playerScoreDict.Add(0, 0);
        playerScoreDict.Add(1, 0);

        playerRolesDict.Add(0, 1);
        playerRolesDict.Add(1, 0);

        GameEvents.current.onTimerEnd += EndRound;
        GameEvents.current.onPlayerKilled += EndRound;
        GameEvents.current.onInstructionComplete += CheckInstructions;
        GameEvents.current.onRoundEnd += SwapRoles;
    }

    private void SwapRoles() {
        if (playerRolesDict[0] == 0) {
            playerRolesDict[0] = 1;
            playerRolesDict[1] = 0;
        } else {
            playerRolesDict[0] = 0;
            playerRolesDict[1] = 1;
        }
        GameEvents.current.ChangeRoles(playerRolesDict);
    }

    public int getCurHunted() {
        return curHunted;
    }

    private void CheckInstructions() {
        completeInstructions += 1;
        if (completeInstructions >= instructionsToWin) {
            EndRound(curHunted);
        }
    }

    private void EndRound(int id) {
        Debug.Log("Player " + id + " won");
        GameEvents.current.RoundEnd();
        playerScoreDict[id] += 1;
        curRoundNum++;
        SceneManager.LoadScene("RoundSceneTest");
        SwapRoles();
        GameEvents.current.ChangeRoles(playerRolesDict);
        completeInstructions = 0;
    }

    private void Update() {
        p1score = playerScoreDict[0];
        p2score = playerScoreDict[1];

        p1role = playerRolesDict[0];
        p2role = playerRolesDict[1];

    }


}
