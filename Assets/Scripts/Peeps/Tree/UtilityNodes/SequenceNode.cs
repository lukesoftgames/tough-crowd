using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SequenceNode : CompositeNode
{
   
    private int currentNode = 0;
   
    public override NodeStatus OnBehave(Context context, GameObject peep)
    {

        if (currentNode > children.Count - 1)
        {
            Debug.Log("Error in " + name + ": Current Node cannot be bigger than number of children");
        }
        NodeStatus childStatus = GetChild(currentNode).Behave(context, peep);
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
            currentNode = 0;
            return NodeStatus.SUCCESS;
        }
        return NodeStatus.RUNNING;
    }
   
    public override void OnReset()
    {
        currentNode = 0;
        for (int i = 0; i < children.Count; i++)
        {
            GetChild(i).Reset();
        }
    }
}
