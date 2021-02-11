using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyRotation : MonoBehaviour
{
    public Transform targetObject;
    public bool inverse = false;

    private void Update()
    {
        transform.rotation = inverse ? Quaternion.Inverse(targetObject.rotation) : targetObject.rotation;
    }
}
