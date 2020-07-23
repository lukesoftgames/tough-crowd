using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToCoords : MoveToLocationNode
{
    public Vector2 goal;
    // Start is called before the first frame update
    public override NodeStatus OnBehave(Context context, GameObject peep)
    {
        if (startFlag)
        {
            // choose a boarding point
            destination = goal;
            CalculatePath(peep);
        }
        return PathFind(context, peep);
    }
}
