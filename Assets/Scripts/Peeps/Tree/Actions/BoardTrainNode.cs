using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEditor.Experimental.GraphView;

public class BoardTrainNode : MoveToLocationNode
{

    public override NodeStatus OnBehave(Context context, GameObject peep)
    {
        if (startFlag && peep.GetComponent<PeepAI>().isLeader)
        {
            // choose a boarding point
            float minDistance = Mathf.Infinity;
            Vector2 currentPos = peep.GetComponent<Rigidbody2D>().position;
            foreach(Vector2 boardingPoint in context.trainBoardingPoints)
            {
                if ((boardingPoint - currentPos).sqrMagnitude < minDistance)
                {
                    SetDestination(boardingPoint, peep.GetComponent<PeepAI>());
                    minDistance = (boardingPoint - currentPos).sqrMagnitude;
                }
            }
            CalculatePath(peep);
        }

        if (reachedEndOfPath == true)
            return NodeStatus.SUCCESS;
        NodeStatus n = Move(context, peep);
        if (n == NodeStatus.SUCCESS)
        {
            Debug.Log("boarded train");
        }
        return n;
    }
}
