using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    //private Pathfinding.AIDestinationSetter destObj;
    private Vector2 lastPosition;

    public enum Direction
    {
        left,
        right
    }

    private Direction currentDirection;
    private Direction lastDirection;
    private float origXScale;

    private IEnumerator flip;

    private void Start()
    {
        origXScale = Mathf.Abs(transform.localScale.x);
    }

    private IEnumerator FlipIt(Direction dir)
    {
        Vector2 newScale = transform.localScale;
        var xEndScale = currentDirection == Direction.left ? origXScale : -origXScale;
        //float x = newScale.x;

        while (newScale.x != xEndScale)
        {
            // Draait naar links
            if (xEndScale > newScale.x)
            {
                newScale.x = Mathf.Min(xEndScale, newScale.x + Mathf.Abs(origXScale) * 5 * Time.deltaTime);
            }

            // Draait naar rechts
            else
            {
                newScale.x = Mathf.Max(xEndScale, newScale.x - Mathf.Abs(origXScale) * 5 * Time.deltaTime);
            }

            transform.localScale = newScale;
            yield return new WaitForEndOfFrame();
        }

        flip = null;
        yield return null;
    }

    private void DetermineDirection(Vector2 origPosition, Vector2 targetPosition)
    {
        // Schitterend
        currentDirection = targetPosition.x == origPosition.x ? currentDirection : targetPosition.x < origPosition.x ? Direction.left : Direction.right;
        if (currentDirection != lastDirection)
        {
            lastDirection = currentDirection;
            if (flip != null) StopCoroutine(flip);
            flip = FlipIt(currentDirection);
            StartCoroutine(flip);
        }
    }


    private void Update()
    {
        DetermineDirection(lastPosition, transform.position);
        lastPosition = transform.position;
    }
}
