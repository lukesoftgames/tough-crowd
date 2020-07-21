using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public abstract class WaitUntilNode : BehaviourNode
{
    [Output] public BehaviourNode waitNode;
    [Output] public BehaviourNode conditionNode;
    protected bool conditionMet = false;


    protected abstract bool WaitCondition(Context context);

    public override void OnReset()
    {
        conditionMet = false;
    }

    public override void OnCreateConnection(NodePort from, NodePort to)
    {
        base.OnCreateConnection(from, to);
        if (from.fieldName == "waitNode")
        {
            waitNode = (BehaviourNode)to.node;
        } else if (from.fieldName == "conditionNode")
        {
            conditionNode = (BehaviourNode)to.node;
        }
    }

    public override NodeStatus OnBehave(Context context, GameObject peep)
    {
        // this wacky looking thing makes sure that our condition is a one shot and
        // doesn't disable after 
        if (conditionMet)
        {
            return conditionNode.Behave(context, peep);
        }
        conditionMet = WaitCondition(context);
        if (conditionMet)
        {
            conditionNode.Reset();
            return conditionNode.Behave(context, peep);
        }
        else
        {
            return NodeStatus.RUNNING;
        }


    }
}
