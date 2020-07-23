using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class BoardTrainNode : MoveToLocationNode
{

    public override NodeStatus OnBehave(Context context, GameObject peep)
    {
        if (startFlag)
        {
            Debug.Log("Set Path");
            // choose a boarding point
            float minDistance = Mathf.Infinity;
            Vector2 currentPos = peep.GetComponent<Rigidbody2D>().position;
            foreach(Vector2 boardingPoint in context.trainBoardingPoints)
            {
                if ((boardingPoint - currentPos).magnitude < minDistance)
                {
                    destination = boardingPoint;
                }
            }
            CalculatePath(peep);
        }
        return PathFind(context, peep);
    }
}
