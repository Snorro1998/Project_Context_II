using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    private Camera cam;
    private Vector2 lastPosition;
    private Vector2 screenCenterPosition;

    float lastRot = 0;

    bool rotating = false;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        
    }

    private void Update()
    {
        screenCenterPosition = new Vector2(Screen.width / 2, Screen.height / 2);
        if (Input.GetMouseButtonDown(1))
        {
            rotating = true;
            lastPosition = Input.mousePosition;
            lastRot = GetAngle();
        }

        else if (Input.GetMouseButtonUp(1))
        {
            rotating = false;
        }
        
        if (rotating)
        {
            float rot = GetAngle();
            //Debug.Log(rot - lastRot);
            lastPosition = Input.mousePosition;
            cam.transform.Rotate(new Vector3(0, 0, -1 * (rot - lastRot)));
            lastRot = rot;
            
        }
    }

    float GetAngle()
    {
        float dx = lastPosition.x - screenCenterPosition.x;
        float dy = lastPosition.y - screenCenterPosition.y;

        float schuine = Mathf.Sqrt((dx * dx) + (dy * dy));

        float graden = Mathf.Rad2Deg * Mathf.Asin(dy / schuine);

        if (dx < 0 && dy < 0)
        {
            graden = -graden - 180;
            //graden = -1 * (graden + 90) - 90;
            
        //graden += 90;
            //graden *= -1;
            //graden -= 90;
        }

        if (dx < 0 && dy > 0)
        {
            graden = 180 - graden;
        }

        if (graden < 0)
        {
            graden += 360;
        }

        return graden;
    }
}
