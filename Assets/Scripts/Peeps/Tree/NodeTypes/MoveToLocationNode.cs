using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public abstract class MoveToLocationNode : BehaviourNode
{

    protected Vector2 destination;
    private Seeker seeker;
    protected Path path;
    int currentWaypoint = 0;
    protected bool reachedEndOfPath = false;
    protected Rigidbody2D rb;
    public float changeWaypointTolerance = 0.5f;
    public float speed = 1f;

    public override void OnReset()
    {
        startFlag = true;
        path = null;
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
    protected void CalculatePath(GameObject peep)
    {
        if (rb == null)
            rb = peep.GetComponent<Rigidbody2D>();
        if (seeker == null)
            seeker = peep.GetComponent<Seeker>();
        if (destination != null)
            path = null;
            seeker.StartPath(rb.position, destination, OnPathComplete);
    }
    public NodeStatus PathFind(Context context, GameObject peep)
    {
        // if we have just started, calculate a palth
        if (startFlag)
        {
           
            if (destination != null)
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
        rb.position += force;

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < changeWaypointTolerance)
        {
            currentWaypoint++;
        }

        return NodeStatus.RUNNING;
    }
    public override NodeStatus OnBehave(Context context, GameObject peep)
    {
        return PathFind(context, peep);
    }

}
