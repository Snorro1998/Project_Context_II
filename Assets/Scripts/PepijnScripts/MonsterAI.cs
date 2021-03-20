using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    private bool boatIsDestroying = true;
    public float speed;
    public float chaseDistance;

    private float distance;
    private float maxDistance;
    private int randX;
    private int randY;

    private Transform boat;

    public Rigidbody2D rb;
    public LayerMask layers;

    private EnemyState currentState;
    private Vector3 wanderPosition;

    private int stateInt;

    public enum EnemyState
    {
        Wander,
        Chasing,
        Fleeing,
    }

    void Start()
    {
        boat = GameObject.FindGameObjectWithTag("Boat").GetComponent<Transform>();
    }

    void Update()
    {
        Debug.Log(currentState);
        distance = Vector2.Distance(transform.position, boat.position);

        switch (currentState)
        {
            case EnemyState.Chasing:
                {
                    if (boatIsDestroying)
                    {
                        currentState = EnemyState.Fleeing;
                    }
                    if (distance > maxDistance)
                    {
                        currentState = EnemyState.Wander;
                    }
                    chasing();
                    break;
                }
            case EnemyState.Wander:
                {
                    if (distance < maxDistance && !boatIsDestroying)
                    {
                        currentState = EnemyState.Chasing;
                    }
                    else if (boatIsDestroying)
                    {
                        currentState = EnemyState.Fleeing;
                    }
                    wander();
                    break;
                }
            case EnemyState.Fleeing:
                {
                    if (!boatIsDestroying)
                    {
                        currentState = EnemyState.Wander;
                    }
                    fleeing();
                    break;
                }
        }
    }
    void chasing()
    {
        transform.position = Vector2.MoveTowards(transform.position, boat.position, speed * Time.deltaTime);
        stateInt = 1;
    }

    void wander()
    {
        if (wanderPosition.Equals(transform.position))
        {
            getWanderPos();
        }
        transform.position = Vector2.MoveTowards(transform.position, wanderPosition, speed * Time.deltaTime);
        stateInt = 3;
    }
    void fleeing()
    {
        Vector3 fleeDirection = transform.position - boat.position;
        transform.position = Vector2.MoveTowards(transform.position, fleeDirection, speed * Time.deltaTime);
        stateInt = 4;
    }

    void getWanderPos()
    {
        randX = Random.Range(10, 20);
        randY = Random.Range(10, 20);
        wanderPosition = new Vector3(randX, randY, 0f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
    }
}