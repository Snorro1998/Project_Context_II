using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapManager : Singleton<MinimapManager>
{
    //public KeyCode mapToggleKey = KeyCode.M;
    public GameObject fullScreenMap;
    public GameObject mapObj;

    public enum MapMode
    {
        normal,
        fullScreen,
        hidden
    }

    private MapMode mapMode = MapMode.hidden;

    public MapMode Mode
    {
        get { return mapMode; }
        set
        {
            mapMode = value;
            UpdateMap();
        }
    }


    private void Start()
    {
        UpdateMap();
    }

    private void UpdateMap()
    {
        Debug.Log("mapmode= " + mapMode);
        switch(mapMode)
        {
            case MapMode.fullScreen:
                mapObj.SetActive(false);
                fullScreenMap.SetActive(true);
                break;
            case MapMode.hidden:
                mapObj.SetActive(false);
                fullScreenMap.SetActive(false);
                break;
            default:
                mapObj.SetActive(true);
                fullScreenMap.SetActive(false);
                break;

        }
    }
    /*
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
        switch(mapMode)
        {
            case MapMode.hidden:
                mapObj.SetActive(false);
                break;
        }

        mapMode = mapMode == MapMode.normal ? MapMode.fullScreen : MapMode.normal;
        fullScreenMap?.SetActive(mapMode == MapMode.fullScreen ? true : false);
    }

    bool KeyPressed(KeyCode key)
    {
        return Input.GetKeyDown(key);
    }
    */
}
