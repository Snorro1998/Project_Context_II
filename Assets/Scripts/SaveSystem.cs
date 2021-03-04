using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Een smerig savesysteem dat alleen werkt zolang je het spel niet afsluit
/// </summary>
public class SaveSystem : MonoBehaviour
{
    public GameObject objectsToSave;
    private GameObject save1;

    public KeyCode saveKey = KeyCode.S;
    public KeyCode loadKey = KeyCode.L;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void SaveDirty()
    {
        if (save1 != null)
        {
            Destroy(save1);
        }   
        save1 = Instantiate(objectsToSave);
        save1.name = "save1";
        DontDestroyOnLoad(save1);
        save1.SetActive(false);
    }

    private void LoadDirty()
    {
        if (save1 != null)
        {
            string name = "";
            if (objectsToSave != null)
            {
                name = objectsToSave.name;
                Destroy(objectsToSave);
            }
            objectsToSave = Instantiate(save1);
            objectsToSave.name = name;
            objectsToSave.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(saveKey))
        {
            SaveDirty();
        }

        if (Input.GetKeyDown(loadKey))
        {
            LoadDirty();
        }
    }
}
