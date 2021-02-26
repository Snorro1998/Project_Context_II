using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Camera cam;
    public float influence = 0.2f;
    Vector3 lastPos;

    public enum MouseButton
    {
        LeftButton,
        RightButton,
        MiddleButton
    }

    public MouseButton mouseButton;

    bool rotating = false;
    
    void Start()
    {
        cam = Camera.main;       
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown((int)mouseButton))
        {
            rotating = true;
            lastPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp((int)mouseButton))
        {
            rotating = false;
        }

        if (rotating)
        {
            Vector3 currentMousePosition = Input.mousePosition;
            float distanceX = currentMousePosition.x - lastPos.x;
            cam.transform.Rotate(new Vector3(0, 0, -influence * (distanceX)));
            lastPos = currentMousePosition;
        }
    }
}
