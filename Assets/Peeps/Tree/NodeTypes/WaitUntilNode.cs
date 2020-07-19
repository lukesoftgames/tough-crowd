using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WaitUntilNode : BehaviourNode
{
    private BehaviourNode waitNode;
    private BehaviourNode conditionNode;
    protected bool conditionMet = false;

    public WaitUntilNode(string _stateName, BehaviourNode _waitNode, BehaviourNode _conditionNode)
    : base(_stateName)
    {
        waitNode = new RepeaterNode(_waitNode.stateName+" Repeater", _waitNode);
        conditionNode = _conditionNode;

    }


    protected abstract bool WaitCondition(Context context);

    public override void OnReset()
    {
        conditionMet = false;
    }

    public override NodeStatus OnBehave(Context context)
    {
        // this wacky looking thing makes sure that our condition is a one shot and
        // doesn't disable after 
        if (conditionMet)
        {
            return conditionNode.Behave(context);
        }
        conditionMet = WaitCondition(context);
        if (conditionMet)
        {
            return conditionNode.Behave(context);
        }
        else
        {
            return waitNode.Behave(context);
        }


    }
}
