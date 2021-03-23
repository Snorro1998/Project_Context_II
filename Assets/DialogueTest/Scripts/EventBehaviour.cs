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

    public void GotoStartGameScene()
    {
        SaveSystem.Instance.ChangeScene("2 StartGame");
    }

    public void GotoGrandmaScene()
    {
        SaveSystem.Instance.ChangeScene("5 Grandma");
    }

    public void GotoCaptainScene1()
    {
        SaveSystem.Instance.ChangeScene("6 Captain");
    }

    public void GotoReflect1Scene()
    {
        SaveSystem.Instance.ChangeScene("reflect1");
    }

    public void GotoReflect2Scene()
    {
        SaveSystem.Instance.ChangeScene("reflect2");
    }

    public void GotoEval2Scene()
    {
        SaveSystem.Instance.ChangeScene("eval2");
    }

    public void GotoEval3Scene()
    {
        SaveSystem.Instance.ChangeScene("eval3");
    }

    public void ReturnToMap()
    {
        SaveSystem.Instance.ChangeScene("nieuwetestscene");
    }
}
