using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CompositeNode : BehaviourNode
{
    [Output(dynamicPortList = true)] public List<BehaviourNode> children = new List<BehaviourNode>();


    public BehaviourNode GetChild(int idx)
    {
        string key = "children " + idx;
        return (BehaviourNode)GetOutputPort(key).GetConnection(0).node;
    }

    public void AddChild(BehaviourNode node)
    {
        children.Add(node);
    }
    public void RemoveChild(BehaviourNode node)
    {
        children.Remove(node);
    }
}
