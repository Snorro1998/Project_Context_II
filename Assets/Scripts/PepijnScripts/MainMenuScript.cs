using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public static AudioClip mainMenuTheme;
    static AudioSource audioSource;
    /*
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        mainMenuTheme = Resources.Load<AudioClip>("MainMenu");
    }
    private void Start()
    {
        audioSource.PlayOneShot(mainMenuTheme);
    }*/
    public void StartGame()
    {
        SaveSystem.Instance.ChangeScene("1 BossStart");
        //audioSource.Stop();
        //SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Debug.Log("Closing game");
        Application.Quit();
    }
}