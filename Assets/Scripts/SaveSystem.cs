using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Een smerig savesysteem dat alleen werkt zolang je het spel niet afsluit
/// </summary>
public class SaveSystem : Singleton<SaveSystem>
{
    public KeyCode switchSceneKey = KeyCode.P;

    SaveCollection saveCollection;
    private Dictionary<string, GameObject> savedScenes = new Dictionary<string, GameObject>();
    // Dit is om het te testen
    private Queue<string> sceneIDs = new Queue<string>();

    protected override void Awake()
    {
        base.Awake();
        sceneIDs.Enqueue("secondScene");
        sceneIDs.Enqueue("nieuwetestscene");
        SceneManager.sceneLoaded += OnSceneLoaded;
        saveCollection = FindObjectOfType<SaveCollection>();
    }

    // Wordt aangeroepen als de scene is geladen
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
    }

    // Laadt een andere scene
    private void ChangeScene(string sceneToLoad)
    {
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
        
        SceneManager.LoadScene(sceneToLoad);
    }

    private void Update()
    {        
        if (Input.GetKeyDown(switchSceneKey))
        {
            string id = sceneIDs.Dequeue();
            sceneIDs.Enqueue(id);
            ChangeScene(id);
        }
    }
}
