using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForTrainNode : WaitUntilNode
{

    protected override bool WaitCondition(Context context)
    {
        return context.trainArrived;
    }

}
