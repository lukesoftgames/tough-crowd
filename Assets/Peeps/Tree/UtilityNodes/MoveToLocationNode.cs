using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MoveToLocationNode : LeafNode
{
    protected Vector2 destination;
    private Seeker seeker;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    protected Rigidbody2D rb;
    private float changeWaypointTolerance;
    private float speed;



    public MoveToLocationNode(string _stateName, Seeker _seeker, Vector2 _destination, Rigidbody2D _rb, float _changeWaypointTolerance, float _speed) :
         base(_stateName)
    {
        destination = _destination;
        seeker = _seeker;
        rb = _rb;
        changeWaypointTolerance = _changeWaypointTolerance;
        speed = _speed;
    }

    public MoveToLocationNode(string _stateName, Seeker _seeker, Rigidbody2D _rb, float _changeWaypointTolerance, float _speed) :
        base(_stateName)
    {
        destination = Vector2.zero;
        seeker = _seeker;
        rb = _rb;
        changeWaypointTolerance = _changeWaypointTolerance;
        speed = _speed;
    }

    
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
        else
        {
            Debug.Log(p.error);
        }
    }
    public void CalculatePath()
    {
        if (destination != null)
            seeker.StartPath(rb.position, destination, OnPathComplete);
    }
    public NodeStatus PathFind(Context context)
    {
        // if we have just started, calculate a palth
        if (startFlag)
        {
            seeker.StartPath(rb.position, destination, OnPathComplete);
        }
        if (path == null)
            return NodeStatus.RUNNING;
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return NodeStatus.SUCCESS;
        }
        reachedEndOfPath = false;
        // find out which way to go
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        // calculate the force to reach the location
        Vector2 force = direction * speed * Time.deltaTime;
        Debug.Log(force);
        rb.position += force;

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < changeWaypointTolerance)
        {
            currentWaypoint++;
        }

        return NodeStatus.RUNNING;
    }
    public override NodeStatus OnBehave(Context context)
    {
        return PathFind(context);
    }

}
