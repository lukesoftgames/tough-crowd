using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : BehaviourNode
{
    float timePassed = 0f;
    float timeLimit = Mathf.Infinity;
    public float minTime = 1f;
    public float maxTime = 2f;
    
    public override NodeStatus OnBehave(Context context, GameObject peep)
    {
        if (startFlag)
        {
            timeLimit = Random.Range(minTime, maxTime);
        }
        if (timePassed > timeLimit)
        {
            Reset();
            return NodeStatus.SUCCESS;
        }
        else
        {
            timePassed += Time.deltaTime;
            return NodeStatus.RUNNING;
        }
    }
    public override void OnReset()
    {
        startFlag = true;
        timeLimit = Mathf.Infinity;
        timePassed = 0f;
    }
}
