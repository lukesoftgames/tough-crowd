﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PeepAI : MonoBehaviour
{

    public BehaviourTree behaviourTree;
    private BehaviourNode behaviourTreeRoot;
    private Context context = Context.GetInstance();


    void Start()
    {
        behaviourTree = (BehaviourTree)behaviourTree.Copy();
        XNode.Node entry = ((BehaviourTree)behaviourTree.Copy()).FindEntryNode();
        behaviourTreeRoot = (BehaviourNode)entry.GetOutputPort("child").GetConnection(0).node;
        behaviourTreeRoot.Reset();
    }

    void FixedUpdate()
    {
        NodeStatus s = behaviourTreeRoot.Behave(context, gameObject);
    }
}