using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiasedSelectorNode : CompositeNode
{
    private int currentNode = -1;
    public List<float> probability;
    public override NodeStatus OnBehave(Context context, GameObject peep)
    {
        if (currentNode == -1)
        {
            float x = Random.Range(0f,1f);
            float sum = 0f;
            int i = 0;

            foreach(float p in probability)
            {
                sum += p;
                if (x < sum)
                {
                    currentNode = i;
                    break;
                } else
                {
                   
                    i++;
                }
            }
            if (currentNode == -1)
                currentNode = children.Count - 1;
        }
        NodeStatus childStatus = GetChild(currentNode).Behave(context, peep);
        if (childStatus != NodeStatus.RUNNING)
        {
            currentNode = -1;
        }
        return childStatus;
    }

    public override void OnReset()
    {
        currentNode = -1;
        for (int i = 0; i < children.Count; i++)
        {
            GetChild(i).Reset();
        }
    }
}
