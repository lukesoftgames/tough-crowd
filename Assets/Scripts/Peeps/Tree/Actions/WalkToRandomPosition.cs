using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToRandomPosition : MoveToLocationNode
{
    public float minSearchRadius = 2f;
    public float maxSearchRadius = 5f;
    public int attemptsToFindATarget = 10;

    

    public override NodeStatus OnBehave(Context context, GameObject peep)
    {
        if (startFlag && peep.GetComponent<PeepAI>().isLeader)
        {
            
            // choose a boarding point
            int i = 0;
            while (path == null && i < attemptsToFindATarget)
            {

                Vector2 dest = peep.GetComponent<Rigidbody2D>().position + (new Vector2(
                    Random.Range(-maxSearchRadius, maxSearchRadius),
                    Random.Range(-maxSearchRadius, maxSearchRadius)
                ));
                SetDestination(dest, peep.GetComponent<PeepAI>());
                // SetDestination(dest);
                CalculatePath(peep);
                i++;
            }
            
        }
        return Move(context, peep);
    }

    
}
