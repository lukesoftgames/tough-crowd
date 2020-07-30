using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SelectorNode : CompositeNode
{
    private int currentNode = -1;
    public override NodeStatus OnBehave(Context context, GameObject peep)
    {


        if (currentNode == -1)
        {
            currentNode = Random.Range(0, children.Count);
        }
        NodeStatus childStatus = GetChild(currentNode).Behave(context, peep);
        if (childStatus != NodeStatus.RUNNING)
        {
            currentNode = -1;
        }
        return childStatus;
    }

    public override void OnReset()
    {
        currentNode = -1;
        for (int i = 0; i < children.Count; i++)
        {
            GetChild(i).Reset();
        }
    }
}
