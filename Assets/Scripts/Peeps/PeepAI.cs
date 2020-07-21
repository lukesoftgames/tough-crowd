using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class PeepAI : MonoBehaviour
{

    public BehaviourTree behaviourTree;
    private BehaviourNode behaviourTreeRoot;
    private Context context = Context.GetInstance();



    void Start()
    {
        XNode.Node entry = behaviourTree.FindEntryNode();
        behaviourTreeRoot = (BehaviourNode) entry.GetOutputPort("child").GetConnection(0).node;
        behaviourTreeRoot.Reset();
    }

    void FixedUpdate()
    {
        NodeStatus s = behaviourTreeRoot.Behave(context, gameObject);
    }
}
