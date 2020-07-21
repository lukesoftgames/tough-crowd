using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentToNode : BehaviourNode
{
    public string parentName;
 

    public override void OnReset()
    {
        return;
    }
    public override NodeStatus OnBehave(Context context, GameObject peep)
    {
        GameObject newParent = GameObject.Find(parentName);
        if (newParent == null)
        {
            return NodeStatus.RUNNING;
        }
        peep.GetComponent<Transform>().parent = newParent.transform;
        return NodeStatus.SUCCESS;
    }
}
