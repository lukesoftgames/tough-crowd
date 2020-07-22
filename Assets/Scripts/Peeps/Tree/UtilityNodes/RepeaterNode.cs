using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeaterNode : DecoratorNode
{

    
    public override NodeStatus OnBehave(Context context, GameObject peep)
    {
        NodeStatus childStatus = GetChild().Behave(context, peep);
        if(childStatus == NodeStatus.SUCCESS) {
            Reset();
            return NodeStatus.RUNNING;
        }
        return NodeStatus.RUNNING;
    }

    public override void OnReset()
    {
        if (GetChild() != null)
        {
            GetChild().Reset();
        }
    }
}
