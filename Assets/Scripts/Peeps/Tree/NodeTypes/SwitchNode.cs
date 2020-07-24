using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchNode : BehaviourNode
{

    [SerializeField] private string key;
    private Blackboard bb;
    [Output] public BehaviourNode runOnTrue;
    [Output] public BehaviourNode runOnFalse;
    public override void OnReset()
    {
        GetFalseNode().Reset();
        GetTrueNode().Reset();

    }

    public override NodeStatus OnBehave(Context context, GameObject peep)
    {
        if (startFlag)
        {
            bb = peep.GetComponent<PeepAI>().blackboard;
        }
        if (bb.GetValue<bool>(key))
        {
            return GetTrueNode().Behave(context, peep);
        }else
        {
            return GetFalseNode().Behave(context, peep);
        }
    }
    protected BehaviourNode GetTrueNode()
    {
        return (BehaviourNode)GetOutputPort("runOnTrue").GetConnection(0).node;
    }
    protected BehaviourNode GetFalseNode()
    {
        return (BehaviourNode)GetOutputPort("runOnFalse").GetConnection(0).node;
    }

}


