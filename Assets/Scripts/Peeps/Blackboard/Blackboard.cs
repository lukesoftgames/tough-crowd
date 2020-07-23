using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackboard : MonoBehaviour
{
    private Dictionary<string, object> blackboardValues;

    public Blackboard()
    {
        blackboardValues = new Dictionary<string, object>();
    }

    public void UpdateBlackboard(string key, object value)
    {
        if (blackboardValues.ContainsKey(key))
        {
            blackboardValues[key] = value;
        } else
        {
            blackboardValues.Add(key, value);
        }
    }
    public void Clear()
    {
        foreach(string key in blackboardValues.Keys)
        {
            blackboardValues.Remove(key);
        }
    }
   
}
