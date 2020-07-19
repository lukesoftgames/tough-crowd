using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DecoratorNode : BehaviourNode
{
    protected BehaviourNode child;

    public DecoratorNode(string _stateName) 
        : base(_stateName)
    { }

    public DecoratorNode(string _stateName, BehaviourNode node)
        : base(_stateName)
    {
        child = node;
    }

    public virtual void SetChild(BehaviourNode node)
    {
        child = node;
    }
}
