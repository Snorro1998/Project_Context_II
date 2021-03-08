using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Event", menuName = "Dialogue System/Dialogue Event")]
public class EventBehaviour : ScriptableObject
{
    public void DoSomethingGoodEvent()
    {
        References.instance.DoSomethingGood();
    }

    public void DoSomethingBadEvent()
    {
        References.instance.DoSomethingBad();
    }
}
