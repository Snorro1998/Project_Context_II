using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPathMover : MonoBehaviour
{
    public Transform player;
    public Transform pathObject;
    public float remainingDistanceForNext = 0.5f;

    private Queue<Transform> nodes = new Queue<Transform>();
    private Pathfinding.AIDestinationSetter destinationSetter;
    // Niet nodig, want AIPath.remainingdistance werkt niet lekker
    //private Pathfinding.AIPath pathFinder;

    private void Awake()
    {
        destinationSetter = GetComponent<Pathfinding.AIDestinationSetter>();
        //pathFinder = GetComponent<Pathfinding.AIPath>();
    }

    private void Start()
    {
        if (pathObject != null)
        {
            // Pad bevat nodes
            if (pathObject.childCount > 0)
            {
                // Stopt nodes in queue
                foreach (Transform t in pathObject)
                {
                    nodes.Enqueue(t);
                }
            }
            if (destinationSetter.target == null) GetNextNode();
        }

    }

    private void Update()
    {
        //werkt niet goed
        //if (pathFinder.remainingDistance < remainingDistanceForNext)
        if (GameManager.Instance.hasVisitedBoss)
        {
            destinationSetter.target = player;
        }
        else
        {
            // Pak volgende node als de afstand tot de huidige node kleiner is dan de drempelwaarde
            if (Vector3.Distance(transform.position, destinationSetter.target.position) < remainingDistanceForNext)
            {
                GetNextNode();
            }
        }
    }

    private void GetNextNode()
    {
        Transform nextNode = nodes.Dequeue();
        destinationSetter.target = nextNode;
        nodes.Enqueue(nextNode);
    }
}