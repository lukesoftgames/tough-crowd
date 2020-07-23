using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoAfterNSeconds : BehaviourNode
{
    float timePassed = 0f;
    public float timeLimit = 0f;
    public string messageToEcho = "";
   
    public override NodeStatus OnBehave(Context context, GameObject peep)
    {
        if (timePassed > timeLimit)
        {
            Debug.Log(messageToEcho);
            Reset();
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
