using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupCreator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int groupSizeLimit = 4;
    [SerializeField] GameObject peepTemplate;
    [SerializeField] private int numberOfGroups;
    
    private GameObject groupLeader; 
    

    void MakeGroup(int size)
    {
        List<PeepAI> aiInGroup = new List<PeepAI>();
        List<Rigidbody2D> rbInGroup = new List<Rigidbody2D>();
        Vector2 spawnPos = new Vector2(Random.Range(0f, 18f), Random.Range(14f, -14f));
        // Check if spawn is clear

        Collider2D collider = Physics2D.OverlapCircle(spawnPos, 0f);
        if (collider != null)
        {
            // The spawn location is inside a collider
            return;
        }

        groupLeader = Instantiate(peepTemplate, spawnPos, Quaternion.identity);
        Blackboard groupBlackboard = ScriptableObject.CreateInstance<Blackboard>();
        PeepAI leaderAi = groupLeader.GetComponent<PeepAI>();
        leaderAi.groupBlackboard = groupBlackboard;
        leaderAi.blackboard.UpdateBlackboard("isGroupLeader", true);
        rbInGroup.Add(groupLeader.GetComponent<Rigidbody2D>());
        for (int i = 1; i < size; i++)
        {
            GameObject peepInstance = Instantiate(peepTemplate, spawnPos, Quaternion.identity);
            PeepAI peepAI = peepInstance.GetComponent<PeepAI>();
            peepAI.blackboard.UpdateBlackboard("leader", groupLeader);
            peepAI.blackboard.UpdateBlackboard("isGroupLeader", false);
            peepAI.groupBlackboard = groupBlackboard;
            aiInGroup.Add(peepAI);
            rbInGroup.Add(peepInstance.GetComponent<Rigidbody2D>());
        }
        for (int j = 0; j < aiInGroup.Count; j++)
        {
            aiInGroup[j].blackboard.UpdateBlackboard("group", rbInGroup);
        }
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
