using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEditor.Experimental.GraphView;

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
    private Rigidbody2D leaderRb;
    private Rigidbody2D peepRb;
    private List<Rigidbody2D> group;
    private PeepAI peepAI;

    [SerializeField] private int numberOfCollisionRays = 16;
    [SerializeField] private float awarenessRadius = 2f;


    public override void OnReset()
    {
        startFlag = true;
        path = null;
    }
    public void SetDestination(Vector2 _destination, PeepAI ai)
    {
        destination = _destination;
        ai.groupBlackboard.UpdateBlackboard("destination", destination);
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
    
    public NodeStatus Move(Context context, GameObject peep)
    {
        if (startFlag)
        {
            peepAI = peep.GetComponent<PeepAI>();
            peepRb = peep.GetComponent<Rigidbody2D>();


            
            if (peepAI.GetValueFromGroupBlackboard<List<Rigidbody2D>>("group") != null)
            {
                group = peepAI.GetValueFromGroupBlackboard<List<Rigidbody2D>>("group");
            }
        }
        peepAI = peep.GetComponent<PeepAI>();
        if (peepAI.isLeader)
        {
            return PathFind(context, peep);
        }
        else
        {
            return Follow(peep);
        }
      
         
        
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
        direction += GetSeperationForce();
        Vector2 force = direction * speed * Time.deltaTime;
        rb.position += force;

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < changeWaypointTolerance)
        {
            currentWaypoint++;
        }

        return NodeStatus.RUNNING;
    }

    private NodeStatus Follow(GameObject peep)
    {
        if (startFlag)
        {
            if (peepAI.GetValueFromGroupBlackboard<GameObject>("leader") != null)
            {
                leaderRb = peepAI.GetValueFromGroupBlackboard<GameObject>("leader").GetComponent<Rigidbody2D>();

            }
            else
            {
                Debug.LogWarning("Leader is null");
            }
        }

        if (leaderRb != null && group != null)
        {

            Vector2 dir = leaderRb.position - peepRb.position;
            dir += GetObstacleForces();
            dir += GetSeperationForce();
            // Make the vector length 1, so we can scale it with speed
            dir.Normalize();
            peepRb.position = peepRb.position + (dir * Time.deltaTime * speed);
        }
        destination = peepAI.GetValueFromGroupBlackboard<Vector2>("destination");
        // Have reached Destination
        if (destination != null && peepRb != null)
        {
            
            if ((destination - peepRb.position).magnitude < changeWaypointTolerance)
            {
                reachedEndOfPath = true;
                return NodeStatus.SUCCESS;
            }
        }

        return NodeStatus.RUNNING;
    }
    private Vector2 UnitCircleVector(float angle)
    {
        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }
    private Vector2 CheckForObstaclesAlongRay(float angle)
    {
        Vector2 dir = UnitCircleVector(angle) * awarenessRadius;
        RaycastHit2D hit = Physics2D.Raycast(peepRb.position, dir);
        if (hit.collider != null)
        {
            // Get distance to object, the closer the person is to an object the more they will avoid it
            Vector2 directionVector = (hit.point - peepRb.position);
            if (directionVector.sqrMagnitude < awarenessRadius * awarenessRadius)
            {
                Debug.DrawRay(peepRb.position, dir, Color.red); ;

                Vector2 repulsionForce = 1f / (directionVector.sqrMagnitude) * -directionVector;
                return repulsionForce;
            }
        }
        return Vector2.zero;
    }
    private Vector2 GetObstacleForces()
    {
        Vector2 totalRepulstionForce = Vector2.zero;
        int angleSegment = 360 / 16;
        for (int i = 0; i < 360; i += angleSegment)
        {
            totalRepulstionForce = totalRepulstionForce + CheckForObstaclesAlongRay(i * Mathf.Deg2Rad);
        }
        return totalRepulstionForce;
    }
    private Vector2 GetSeperationForce()
    {
        Vector2 totalSeperationForce = Vector2.zero;
        foreach (Rigidbody2D rb in group)
        {
            if (Vector2.Distance(rb.position, peepRb.position) < 0.5f)
            {
                totalSeperationForce += totalSeperationForce - (rb.position - peepRb.position);
            }
        }

        return totalSeperationForce;

    }

    public override NodeStatus OnBehave(Context context, GameObject peep)
    {
        return PathFind(context, peep);
    }

}
