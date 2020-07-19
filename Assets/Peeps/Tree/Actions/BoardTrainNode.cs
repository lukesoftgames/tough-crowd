using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class BoardTrainNode : MoveToLocationNode
{
    public BoardTrainNode(string _stateName, Seeker _seeker, Rigidbody2D _rb, float _changeWaypointTolerance, float _speed)
        : base(_stateName, _seeker, _rb, _changeWaypointTolerance, _speed)
    {}

    public override NodeStatus OnBehave(Context context)
    {
        if (startFlag)
        {
            // choose a boarding point
            float minDistance = Mathf.Infinity;
            Vector2 currentPos = rb.position;
            foreach(Vector2 boardingPoint in context.trainBoardingPoints)
            {
                if ((boardingPoint - currentPos).magnitude < minDistance)
                {
                    destination = boardingPoint;
                }
            }
            CalculatePath();
        }
        return PathFind(context);
    }


}
