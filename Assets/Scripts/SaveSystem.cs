using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Een smerig savesysteem dat alleen werkt zolang je het spel niet afsluit
/// </summary>
public class SaveSystem : Singleton<SaveSystem>
{
    SaveCollection saveCollection;
    private Dictionary<string, GameObject> savedScenes = new Dictionary<string, GameObject>();
    private string nextScene;

    public Dictionary<string, string> roomNames = new Dictionary<string, string>()
    {
        {"prologue", "BossStart" }
    };

    protected override void Awake()
    {
        base.Awake();
        SceneManager.sceneLoaded += OnSceneLoaded;
        saveCollection = FindObjectOfType<SaveCollection>();
        DontDestroyOnLoad(this.gameObject);
    }

    /// <summary>
    /// Wordt aangeroepen wanneer de scene geladen is
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (savedScenes.ContainsKey(scene.name))
        {
            var save = savedScenes[scene.name];
            saveCollection = FindObjectOfType<SaveCollection>();
            if (saveCollection) DestroyImmediate(saveCollection.gameObject);
            SceneManager.MoveGameObjectToScene(save, SceneManager.GetActiveScene());
            save.SetActive(true);
        }
        /*if (LevelChanger.Instance != null)*/ LevelChanger.Instance?.FadeIn();
        BGMusic.Instance?.UpdateMusic();
    }

    /// <summary>
    /// Laadt de scene met de opgegeven scenenaam
    /// </summary>
    /// <param name="sceneToLoad"></param>
    public void ChangeScene(string sceneToLoad)
    {
        Debug.Log("ChangeScene");
        nextScene = sceneToLoad;
        if (LevelChanger.Instance != null)
        {
            LevelChanger.Instance.FadeOut();
        }
        else
        {
            ChangeSceneP2();
        }
               
    }

    public void ChangeSceneP2()
    {
        Debug.Log("ChangeSceneP2");
        string sceneName = SceneManager.GetActiveScene().name;

        saveCollection = FindObjectOfType<SaveCollection>();
        if (saveCollection)
        {
            DontDestroyOnLoad(saveCollection.gameObject);
            saveCollection.gameObject.SetActive(false);

            if (!savedScenes.ContainsKey(sceneName))
            {
                savedScenes.Add(sceneName, saveCollection.gameObject);
            }
        }

        SceneManager.LoadScene(nextScene);
    }
}
