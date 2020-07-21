using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[NodeTint("#1b871d")]
public class EntryNode : XNode.Node
{
    [Output] public BehaviourNode child;
    public override void OnCreateConnection(XNode.NodePort from, XNode.NodePort to)
    {

        base.OnCreateConnection(from, to);
        if (from.node == this)
        {
            if (to.fieldName == "parent")
            {
                child = (BehaviourNode)to.node;
            }
        }
    }
}
