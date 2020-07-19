using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CompositeNode : BehaviourNode
{
    protected List<BehaviourNode> children;

    public CompositeNode(string _stateName)
       : base(_stateName)
    {
       children = new List<BehaviourNode>();
    }
    public CompositeNode(string _stateName, BehaviourNode[] nodes)
      : base(_stateName)
    {
        children = new List<BehaviourNode>();
        children.AddRange(nodes);
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
