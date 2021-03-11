using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRockingAnimation : MonoBehaviour
{
    public GameObject obj;
    private float xVal = 0;
    private float yVal = 0;
    public float period = 2;
    public float amplitude = 20;

    public bool xAxis = false;
    public bool yAxis = false;
    public bool zAxis = true;

    // Geeft een willekeurige startwaarde zodat niet alle boten synchroon bewegen
    private void Start()
    {
        xVal += UnityEngine.Random.Range(0.0f, 1.0f) * period;
    }

    // Past sinusoide toe op rotatie
    private void Update()
    {
        // Simpele sinusformule die ik veel te vaak vergeet
        //y = a + b sin(c(x – d))
        xVal = (xVal + Time.deltaTime) % period;
        yVal = amplitude * Mathf.Sin(Mathf.PI * 2 / period * xVal);

        var rot = obj.transform.rotation;
        Vector3 rots = rot.eulerAngles;
        if (xAxis) rots.x = yVal;
        if (yAxis) rots.y = yVal;
        if (zAxis) rots.z = yVal;
        obj.transform.rotation = Quaternion.Euler(rots);
    }
}
