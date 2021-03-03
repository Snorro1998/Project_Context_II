using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapManager : MonoBehaviour
{
    public KeyCode mapToggleKey = KeyCode.M;
    public GameObject fullScreenMap;

    public enum MapMode
    {
        normal,
        fullScreen,
        hidden
    }

    public MapMode mapMode;


    // Update is called once per frame
    void Update()
    {
        if (KeyPressed(mapToggleKey))
        {
            ChangeMapMode();
        }
    }

    private void ChangeMapMode()
    {
        mapMode = mapMode == MapMode.normal ? MapMode.fullScreen : MapMode.normal;
        fullScreenMap?.SetActive(mapMode == MapMode.fullScreen ? true : false);
    }

    bool KeyPressed(KeyCode key)
    {
        return Input.GetKeyDown(key);
    }
}
