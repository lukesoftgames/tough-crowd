using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;


public class PeepAI : MonoBehaviour
{

    public BehaviourTree behaviourTree;
    private BehaviourNode behaviourTreeRoot;
    private Context context = Context.GetInstance();
    public Blackboard blackboard;
    public Blackboard groupBlackboard;

    public T GetValueFromBlackboard<T>(string key)
    {
        // Make sure blackboard is set.
        if (blackboard == null) { return default(T); }
        return blackboard.GetValue<T>(key);
    }
    public T GetValueFromGroupBlackboard<T>(string key)
    {
        // Make sure blackboard is set.
        if (groupBlackboard == null) { return default(T); }
        return groupBlackboard.GetValue<T>(key);
    }
    void Awake()
    {
        blackboard = ScriptableObject.CreateInstance<Blackboard>();
    }
    void Start()
    {
        // Create a copy of the behaviour tree so we can indivudually set values
        behaviourTree = (BehaviourTree)behaviourTree.Copy();
        XNode.Node entry = ((BehaviourTree)behaviourTree.Copy()).FindEntryNode();
        behaviourTreeRoot = (BehaviourNode)entry.GetOutputPort("child").GetConnection(0).node;
        behaviourTreeRoot.Reset();
    }

    void FixedUpdate()
    {
        NodeStatus s = behaviourTreeRoot.Behave(context, gameObject);
    }
}
