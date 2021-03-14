using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement2 : MonoBehaviour
{

    private Vector3 targetPosition;
    [SerializeField]
    private int moveSpeed = 5;

    Vector2 currentPosition = new Vector2();
    Vector2 lastPosition = new Vector2();

    private void Start()
    {
        lastPosition = Vector2.zero;
    }
    private void Update()
    {

        //Als de speler klikt dat punt opslaan.
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        //if (GameManager.canBoatmove == true)
        //{
        //    //Ervoor zorgen dat de boot naar het punt gaat waar de speler op geklikt heeft.
        //    transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * moveSpeed); //Speed Lerpen voor leuk effect?
        //}

        //Variables meegeven aan de gamemanager
        //GameManager.boatPosition = transform.position;
        GameManager.boatIsMoving = ismoving();
    }
    private bool ismoving()
    {
        //Kijken of de boot aan het bewegen is en dat in de gamemanager zetten.
        currentPosition = transform.position;
        if (currentPosition != lastPosition)
        {
            lastPosition = transform.position;
            return true;
        }
        else if(currentPosition == lastPosition)
        {
            lastPosition = transform.position;
            return false;
        }
        else
        {
            lastPosition = transform.position;
            return false;
        }

    }
}