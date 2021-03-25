using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Event", menuName = "Dialogue System/Dialogue Event")]
public class EventBehaviour : ScriptableObject
{

    public void PlayMonsterSound1()
    {
        BGMusic.Instance.PlayMonsterSound1();
    }

    public void PlayMonsterSound2()
    {
        BGMusic.Instance.PlayMonsterSound2();
    }

    public void GotoScene(string scenename)
    {
        SaveSystem.Instance.ChangeScene(scenename);
    }

    public void ShowMiniMap()
    {
        MinimapManager.Instance.Mode = MinimapManager.MapMode.normal;
    }
}
