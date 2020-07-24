using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToRandomPosition : MoveToLocationNode
{
    public float minSearchRadius = 2f;
    public float maxSearchRadius = 5f;
    public int attemptsToFindATarget = 10;
    // Start is called before the first frame update
    public override NodeStatus OnBehave(Context context, GameObject peep)
    {
        if (startFlag)
        {
            // choose a boarding point
            int i = 0;
            while (this.path == null && i < attemptsToFindATarget)
            {

                destination = peep.GetComponent<Rigidbody2D>().position + (new Vector2(
                    Random.Range(-maxSearchRadius, maxSearchRadius),
                    Random.Range(-maxSearchRadius, maxSearchRadius)
                ));
                CalculatePath(peep);
                i++;
            }
            return NodeStatus.FAILURE;
        }
        else
        {

            return PathFind(context, peep);
        }
    }
}
