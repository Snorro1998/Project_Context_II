using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyRotation : MonoBehaviour
{
    RectTransform rect;
    public Transform targetObject;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        rect.rotation = Quaternion.Inverse(targetObject.rotation);
    }
}
