using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu]
public class BehaviourTree : XNode.NodeGraph
{

    public XNode.Node FindEntryNode()
    {
        foreach (XNode.Node n in nodes)
        {
            if (n.GetType() == typeof(EntryNode))
            {
                return n;
            }
        }
        Debug.LogError("No Entry Point specified for " + name);
        return null;
    }
   
       public void DisplayHashCodes()
    {
        foreach (XNode.Node n in nodes)
        {
            Debug.Log(n.name + n.GetHashCode());
        }
    }
    
}
