using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PublicEventTest : MonoBehaviour
{
    public UnityEvent myUnityEvent;

    void Awake()
    {
        if (myUnityEvent == null)
        {
            myUnityEvent = new UnityEvent();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myUnityEvent.Invoke();
        }
    }
    /*
    onmou

    public void OnMouseDown()
    {
        myUnityEvent.Invoke();
    }*/

    public void printMessage(string message)
    {
        Debug.Log(message);
    }
}
