using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using XNode;

public enum NodeStatus
{
    FAILURE,
    SUCCESS,
    RUNNING
}

[Serializable]
public abstract class BehaviourNode : XNode.Node
{
    [Input] public XNode.Node parent;
    protected bool startFlag = true;

    public virtual NodeStatus OnBehave(Context context, GameObject peep)
    {
        return NodeStatus.SUCCESS;
    }

    public virtual NodeStatus Behave(Context context, GameObject peep)
    {
        NodeStatus ret = OnBehave(context, peep);
        if (startFlag == true)
            startFlag = false;
        return ret;
    }
    public void Reset()
    {
        startFlag = true;
        OnReset();
    }
    public abstract void OnReset();
}
