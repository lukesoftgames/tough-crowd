using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoAfterNSeconds : LeafNode
{
    float timePassed = 0f;
    float timeLimit = 0f;

    public EchoAfterNSeconds(string _stateName, float _timeLimit) : base (_stateName)
    {
        timeLimit = _timeLimit;
    }
    public override NodeStatus OnBehave(Context context)
    {
        if (timePassed > timeLimit)
        {
            Debug.Log(stateName);
            return NodeStatus.SUCCESS;
        } else
        {
            timePassed += Time.deltaTime;
            return NodeStatus.RUNNING;
        }
    }
    public override void OnReset()
    {
        timePassed = 0f;
    }
}
