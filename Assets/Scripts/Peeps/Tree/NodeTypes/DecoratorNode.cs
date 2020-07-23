using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public abstract class DecoratorNode : BehaviourNode
{
    [Output] public Node child;

    public BehaviourNode GetChild()
    {
        return (BehaviourNode)GetOutputPort("child").GetConnection(0).node;
    }

    public virtual void SetChild(BehaviourNode node)
    {
        if (child != null)
        {
            child = node;
        }
    }
}
