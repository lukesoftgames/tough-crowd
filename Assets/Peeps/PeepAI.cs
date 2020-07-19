using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class PeepAI : MonoBehaviour
{

    private BehaviourNode behaviourTreeRoot;
    private Context context = Context.GetInstance();
    private Seeker seeker;
    private Rigidbody2D rigidbody2D;

    BehaviourNode CreateBehaviourTree()
    {

        MoveToLocationNode moveNode = new MoveToLocationNode(
            "MoveTo00",
            seeker,
            new Vector2(0f, 0f),
            rigidbody2D,
            0.5f,
            2f
            );
        EchoAfterNSeconds echoAfterNSeconds = new EchoAfterNSeconds(
            "WaitingForTrain",
            1f
         );
        BoardTrainNode boardTrainNode = new BoardTrainNode("MoveTo00",
            seeker,
            rigidbody2D,
            0.5f,
            2f
            );
        WaitForTrainNode waitForTrainNode = new WaitForTrainNode(
            "WaitForTrain",
            echoAfterNSeconds,
            boardTrainNode
        );
        ParentToNode parentToNode = new ParentToNode(
            "ParentToNode",
            "TrainBody",
            transform);
        BehaviourNode[] seq = { moveNode, waitForTrainNode, parentToNode };
        SequenceNode sequenceNode = new SequenceNode(
            "PeepDemo",
            seq
            );
         return sequenceNode;
    }

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        behaviourTreeRoot = CreateBehaviourTree();
    }

    void FixedUpdate()
    {
        NodeStatus s = behaviourTreeRoot.Behave(context);
    }
}
