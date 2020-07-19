using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum NodeStatus
{
    FAILURE,
    SUCCESS,
    RUNNING
}

[Serializable]
[CreateAssetMenu()]
public abstract class BehaviourNode : ScriptableObject
{
    public string stateName;
    protected bool startFlag = true;

    public BehaviourNode(string _stateName)
    {
        stateName = _stateName;
    }


    public virtual NodeStatus OnBehave(Context context)
    {
        return NodeStatus.SUCCESS;
    }
    public virtual NodeStatus Behave(Context context)
    {
        NodeStatus ret = OnBehave(context);
        if (startFlag == true)
            startFlag = false;
        return ret;
    }
    public void Reset()
    {
        startFlag = true;
        OnReset();
    }
    public abstract void OnReset();
}
