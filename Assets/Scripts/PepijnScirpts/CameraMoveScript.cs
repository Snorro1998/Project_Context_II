using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{
    private Vector3 wantedCameraPosition = new Vector3();
    private Vector3 CameraStartPosition = new Vector3();

    private int cutsceneInt = 0;
    [SerializeField]
    private Vector2[] cutscenePositions;
    [SerializeField]
    private float maxCameraDistance = 5f;
    [SerializeField]
    private float moveSpeed = 1;
    private float lerpTime;
    private float zero = 0;
    private void Start()
    {
        wantedCameraPosition = transform.position;
    }
    private void Update()
    {
        Vector3 wantedCameraPosition = new Vector3(GameManager.boatPosition.x, GameManager.boatPosition.y, -10f);
        //if (IsBoatOutOfPosition() && !IsCameraInPosition())
        //{
        //    //wantedCameraPosition = new Vector3(boatPosition.x, boatPosition.y, -10);
        //    //CameraStartPosition = transform.position;
        //    moveCamera(CameraStartPosition, wantedCameraPosition);
        //    Debug.Log(CameraStartPosition);
        //    Debug.Log(wantedCameraPosition);
        //    Debug.Log("werukt");
        //}
        if (IsBoatOutOfPosition())
        {
            Debug.Log("helo");
            transform.position = Vector3.MoveTowards(transform.position, wantedCameraPosition, moveSpeed * Time.deltaTime);
        }
    }
    private void moveCamera(Vector3 cameraStartPosition, Vector3 wantedCameraPosition)
    {
        transform.position = Lerp(cameraStartPosition, wantedCameraPosition, lerpTime);
    }
    private bool IsCameraInPosition()
    {
        if (transform.position == wantedCameraPosition)
        {
            wantedCameraPosition = new Vector3(GameManager.boatPosition.x, GameManager.boatPosition.y, -10);
            CameraStartPosition = transform.position;
            zero = 0;
            Debug.Log("reset");
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool IsBoatOutOfPosition()
    {
        Vector3 boatPosition = GameManager.boatPosition;
        if(boatPosition.x > (transform.position.x + maxCameraDistance) || boatPosition.x < transform.position.x - maxCameraDistance)
        {
            return true;
        }
        else if(boatPosition.y > (transform.position.y + maxCameraDistance) || boatPosition.y < transform.position.y - maxCameraDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private Vector3 Lerp(Vector3 startPos, Vector3 endPos, float lerptime)
    {
        zero = zero + Time.deltaTime;
        float timeSinceStarted = zero;
        float percentageComplete = timeSinceStarted / lerptime;
        Vector3 result = Vector3.Lerp(startPos, endPos, percentageComplete);
        return new Vector3(result.x, result.y, -10f);
    }
}
