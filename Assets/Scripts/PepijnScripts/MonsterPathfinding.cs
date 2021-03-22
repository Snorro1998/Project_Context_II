using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class MonsterPathfinding : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float speed;
    Path path;
    int currentWayPoint = 0;
    bool reachedEndOfPath = false;
    private float nextWayPointDistance = 3;
    // Start is called before the first frame update
    Seeker seeker;
    Rigidbody2D rb;
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(path == null)
        {
            return;
        }
        if(currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }
        Vector3 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);
        if(distance < nextWayPointDistance)
        {
            currentWayPoint++;
        }
    }
}
