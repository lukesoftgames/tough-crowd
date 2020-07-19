using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SequenceNode : CompositeNode
{
    private int currentNode = 0;
   
    public SequenceNode(string _stateName)
        : base(_stateName)
    { }

    public SequenceNode(string _stateName, BehaviourNode[] nodes)
        : base(_stateName, nodes)
    { }

    public override NodeStatus OnBehave(Context context)
    {
        if (currentNode > children.Count - 1)
        {
            Debug.Log("Error in " + stateName + ": Current Node cannot be bigger than number of children");
        }
        NodeStatus childStatus = children[currentNode].Behave(context);
        switch(childStatus)
        {
            case NodeStatus.SUCCESS:
                currentNode++;
                break;
            case NodeStatus.FAILURE:
                return NodeStatus.FAILURE;
        }

        if (currentNode >= children.Count)
        {
            return NodeStatus.SUCCESS;
        }
        return NodeStatus.RUNNING;
    }

    public override void OnReset()
    {
        currentNode = 0;
        foreach (BehaviourNode n in children)
        {
            n.Reset();
        }
    }
}
