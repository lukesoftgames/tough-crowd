using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public abstract class DecoratorNode : BehaviourNode
{
    [Output] public BehaviourNode child;


    public override void OnCreateConnection(NodePort from, NodePort to)
    {
        
        base.OnCreateConnection(from, to);
        if (from.node == this)
        {
            if (to.fieldName == "parent")
            {
                child = (BehaviourNode) to.node;    
            }
        }
    }
    public virtual void SetChild(BehaviourNode node)
    {
        if (child != null)
        {
            child = node;
        }
    }
}
