using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupCreator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int groupSizeLimit = 4;
    [SerializeField] GameObject peepTemplate;
    [SerializeField] private int numberOfGroups;

    [SerializeField] private Vector2 spawnRangeTopLeft;
    [SerializeField] private Vector2 spawnRangeBottomRight;

    private GameObject groupLeader; 
    

    void MakeGroup(int size)
    {
        List<PeepAI> aiInGroup = new List<PeepAI>();
        List<Rigidbody2D> rbInGroup = new List<Rigidbody2D>();
        Vector2 spawnPos = new Vector2(Random.Range(spawnRangeTopLeft.x, spawnRangeBottomRight.x), Random.Range(spawnRangeTopLeft.y, spawnRangeBottomRight.y));
        // Check if spawn is clear

        Collider2D collider = Physics2D.OverlapCircle(spawnPos, 0f);
        if (collider != null)
        {
            return;
        }

        groupLeader = Instantiate(peepTemplate, spawnPos, Quaternion.identity);
        Blackboard groupBlackboard = ScriptableObject.CreateInstance<Blackboard>();
        PeepAI leaderAi = groupLeader.GetComponent<PeepAI>();

        groupBlackboard.UpdateBlackboard("leader", groupLeader);

        leaderAi.groupBlackboard = groupBlackboard;
        leaderAi.isLeader = true;
        rbInGroup.Add(groupLeader.GetComponent<Rigidbody2D>());
        for (int i = 1; i < size; i++)
        {
            GameObject peepInstance = Instantiate(peepTemplate, spawnPos, Quaternion.identity);
            PeepAI peepAI = peepInstance.GetComponent<PeepAI>();
            peepAI.isLeader = false;
            peepAI.groupBlackboard = groupBlackboard;

            aiInGroup.Add(peepAI);
            rbInGroup.Add(peepInstance.GetComponent<Rigidbody2D>());
        }


        leaderAi.groupBlackboard.UpdateBlackboard("group", rbInGroup);
        
    }
    void Start()
    {
       for(int i = 0; i < numberOfGroups; i++)
        {
            int size = Random.Range(1, groupSizeLimit);
            MakeGroup(size);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
