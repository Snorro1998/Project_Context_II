using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{
    private Vector3 wantedCameraPosition = new Vector3();

    [SerializeField]
    private Transform playerPos;

    [SerializeField]
    private float maxCameraDistance = 5f;
    [SerializeField]
    private float moveSpeed = 1;
    private float zero = 0;
    private void Start()
    {
        wantedCameraPosition = transform.position;
    }
    private void Update()
    {
        Vector3 wantedCameraPosition = new Vector3(playerPos.position.x, playerPos.position.y, -10f);
        if (!IsCameraInPosition(wantedCameraPosition, transform.position))
        {
            if (IsCameraOutOfPosition(wantedCameraPosition, transform.position))
            {
                transform.position = Vector3.MoveTowards(transform.position, wantedCameraPosition, moveSpeed * Time.deltaTime);
            }
        }
    }
    private bool IsCameraInPosition(Vector3 _boatPos, Vector3 _cameraPos)
    {
        if (transform.position == wantedCameraPosition)
        {
            wantedCameraPosition = new Vector3(_boatPos.x, _boatPos.y, -10);
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool IsCameraOutOfPosition(Vector3 _boatPos, Vector3 _cameraPos)
    {
        if(_boatPos.x > (_cameraPos.x + maxCameraDistance) || _boatPos.x < _cameraPos.x - maxCameraDistance)
        {
            return true;
        }
        else if(_boatPos.y > (_cameraPos.y + maxCameraDistance) || _boatPos.y < _cameraPos.y - maxCameraDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
