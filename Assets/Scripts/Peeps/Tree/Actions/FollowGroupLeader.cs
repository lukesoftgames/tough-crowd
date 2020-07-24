using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Jobs;

public class FollowGroupLeader : BehaviourNode
{
    private Rigidbody2D leaderRb;
    private Rigidbody2D peepRb;
    private List<Rigidbody2D> group; 
    [SerializeField] private int numberOfCollisionRays = 16;
    [SerializeField] private float awarenessRadius = 2f;
    [SerializeField] private float speed;

    // Group members flock like boids within the group
    // Collision avoidance is handled by raycasting in a circle
    public override NodeStatus OnBehave(Context context, GameObject peep)
    {
        if (startFlag)
        {
            peepRb = peep.GetComponent<Rigidbody2D>();
            PeepAI peepAi = peep.GetComponent<PeepAI>();
          
            if (!peep.GetComponent<PeepAI>().GetValueFromBlackboard<bool>("isGroupLeader"))
            {
                if (peepAi.GetValueFromBlackboard<GameObject>("leader") != null)
                {
                    leaderRb = peepAi.GetValueFromBlackboard<GameObject>("leader").GetComponent<Rigidbody2D>();
                    
                } else
                {
                    Debug.LogWarning("Leader is null");
                }
                if (peepAi.GetValueFromBlackboard<List<Rigidbody2D>>("group") != null)
                {
                    group = peepAi.GetValueFromBlackboard<List<Rigidbody2D>>("group");
                }
            } else
            {
                Debug.LogError("Tried to run follow group leader on group leader!");
                return NodeStatus.FAILURE;
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
      
        return NodeStatus.RUNNING;
    }

    public Vector2 UnitCircleVector(float angle)
    {
        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }
    public Vector2 CheckForObstaclesAlongRay(float angle)
    {
        Vector2 dir = UnitCircleVector(angle) * awarenessRadius;
        RaycastHit2D hit = Physics2D.Raycast(peepRb.position, dir);
        if (hit.collider != null)
        {
            // Get distance to object, the closer the person is to an object the more they will avoid it
            Vector2 directionVector = (hit.point - peepRb.position);
            if (directionVector.sqrMagnitude < awarenessRadius*awarenessRadius)
            {
                Debug.DrawRay(peepRb.position, dir, Color.red); ;

                Vector2 repulsionForce = 1f / (directionVector.sqrMagnitude) * -directionVector;
                return repulsionForce;
            }
        }
        return Vector2.zero;
    }
    public Vector2 GetObstacleForces()
    {
        Vector2 totalRepulstionForce = Vector2.zero;
        int angleSegment = 360 / 16;
        for (int i = 0; i < 360; i+=angleSegment)
        {
            totalRepulstionForce = totalRepulstionForce + CheckForObstaclesAlongRay(i*Mathf.Deg2Rad);
        }
        return totalRepulstionForce;
    }
    public Vector2 GetSeperationForce()
    {
        Vector2 totalSeperationForce = Vector2.zero;
        foreach(Rigidbody2D rb in group)
        {
            if (Vector2.Distance(rb.position, peepRb.position) < 0.5f)
            {
               totalSeperationForce += totalSeperationForce - (rb.position - peepRb.position);
            }
        }

        return totalSeperationForce;
        
    }
    public override void OnReset()
    {
        startFlag = true;
    }

}
