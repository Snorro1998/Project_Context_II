using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackObject : MonoBehaviour
{
    public GameObject followObject;
    public bool xPos = false;
    public bool yPos = false;
    public bool zPos = false;

    public enum UpdateMethod
    {
        Update,
        FixedUpdate
    }

    public UpdateMethod updateMethod;
    
    private void Update()
    {
        if (updateMethod == UpdateMethod.Update)
        {
            UpdatePosition();
        }
    }

    private void FixedUpdate()
    {
        if (updateMethod == UpdateMethod.FixedUpdate)
        {
            UpdatePosition();
        }
    }

    private void UpdatePosition()
    {
        if (followObject == null) return;
        transform.position = new Vector3(
            xPos ? followObject.transform.position.x : transform.position.x,
            yPos ? followObject.transform.position.y : transform.position.y,
            zPos ? followObject.transform.position.z : transform.position.z);
    }
}
