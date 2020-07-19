using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentToNode : LeafNode
{
    private string parent;
    private Transform peepTransform;
    public ParentToNode(string _stateName, string _parent, Transform _transform) 
        : base (_stateName)
    {
        parent = _parent;
        peepTransform = _transform;
    }

    public override NodeStatus OnBehave(Context context)
    {
        GameObject newParent = GameObject.Find(parent);
        if (newParent == null)
        {
            return NodeStatus.RUNNING;
        }
        peepTransform.parent = newParent.transform;
        return NodeStatus.SUCCESS;
    }
}
