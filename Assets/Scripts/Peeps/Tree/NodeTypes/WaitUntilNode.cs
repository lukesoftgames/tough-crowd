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
        GetConditionNode().Reset();
        GetWaitNode().Reset();
    }

    protected BehaviourNode GetWaitNode()
    {
        return (BehaviourNode)GetOutputPort("waitNode").GetConnection(0).node;
    }
    protected BehaviourNode GetConditionNode()
    {
        return (BehaviourNode)GetOutputPort("conditionNode").GetConnection(0).node;
    }

    public override NodeStatus OnBehave(Context context, GameObject peep)
    {
        // this wacky looking thing makes sure that our condition is a one shot and
        // doesn't disable after 
        if (conditionMet)
        {
            return GetConditionNode().Behave(context, peep);
        }
        conditionMet = WaitCondition(context);
        if (conditionMet)
        {
            conditionNode.Reset();
            return GetConditionNode().Behave(context, peep);
        }
        else
        {
            GetWaitNode().Behave(context, peep);
            return NodeStatus.RUNNING;
        }


    }
}
