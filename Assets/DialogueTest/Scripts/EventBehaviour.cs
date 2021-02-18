using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Event", menuName = "Dialogue System/Dialogue Event")]
public class EventBehaviour : ScriptableObject
{
    public void TestEvent()
    {
        Debug.Log("Test event 01");
        Destroy(References.instance.testGameObject);
    }

    public void TestEvent02()
    {
        Debug.Log("Test event 02 succes");
    }
}
