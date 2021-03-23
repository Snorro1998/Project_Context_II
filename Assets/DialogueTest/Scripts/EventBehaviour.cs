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

    public void GotoEval4Scene()
    {
        SaveSystem.Instance.ChangeScene("eval4");
    }

    public void GotoEndScene()
    {
        SaveSystem.Instance.ChangeScene("11 Endscene");
    }

    public void ReturnToMap()
    {
        SaveSystem.Instance.ChangeScene("nieuwetestscene");
    }

    public void GotoCredits()
    {
        SaveSystem.Instance.ChangeScene("credits");
    }

    public void GotoMainMenu()
    {
        SaveSystem.Instance.ChangeScene("MainMenu");
    }

    public void GotoTeaser()
    {
        SaveSystem.Instance.ChangeScene("credits");
    }

    public void PlayMonsterSound1()
    {
        BGMusic.Instance.PlayMonsterSound1();
    }

    public void PlayMonsterSound2()
    {
        BGMusic.Instance.PlayMonsterSound2();
    }

    public void GotoBottleScene()
    {
        SaveSystem.Instance.ChangeScene("1_1 BottleScene");
    }
}
