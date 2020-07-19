using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class IdleMovementNode : MoveToLocationNode
{
    public IdleMovementNode(string _stateName, Seeker _seeker, Rigidbody2D _rb, float _changeWaypointTolerance, float _speed)
        : base(_stateName, _seeker, _rb, _changeWaypointTolerance, _speed)
    { }

    public override NodeStatus OnBehave(Context context)
    {
        return NodeStatus.RUNNING;
    }
}
