using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeaterNode : DecoratorNode
{
    public RepeaterNode(string _stateName, BehaviourNode node) :
         base(_stateName, node)
    { }

    public override NodeStatus OnBehave(Context context)
    {
        NodeStatus childStatus = child.Behave(context);
        if(childStatus == NodeStatus.SUCCESS) {
            Reset();
            return NodeStatus.RUNNING;
        }
        return NodeStatus.RUNNING;
    }

    public override void OnReset()
    {
        child.Reset();
    }
}
