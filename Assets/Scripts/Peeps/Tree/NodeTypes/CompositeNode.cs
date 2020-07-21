using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CompositeNode : BehaviourNode
{
    [Output(dynamicPortList = true)] public List<BehaviourNode> children = new List<BehaviourNode>();

    public override void OnCreateConnection(XNode.NodePort from, XNode.NodePort to)
    {

        base.OnCreateConnection(from, to);
        if (from.node == this)
        {
            if (to.fieldName == "parent")
            {
                int idx = int.Parse(from.fieldName.Substring(from.fieldName.Length - 1));
                children[idx] = (BehaviourNode)to.node;
            }
        }
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
