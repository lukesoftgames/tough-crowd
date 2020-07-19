using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForTrainNode : WaitUntilNode
{
    public WaitForTrainNode(string _stateName, BehaviourNode wait, BehaviourNode done) :
         base(_stateName, wait, done)
    { }

    protected override bool WaitCondition(Context context)
    {
        return context.trainArrived;
    }

}
