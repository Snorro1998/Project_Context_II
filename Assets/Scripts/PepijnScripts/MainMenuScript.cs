using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public static AudioClip mainMenuTheme;
    static AudioSource audioSource;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        mainMenuTheme = Resources.Load<AudioClip>("MainMenu");
    }
    private void Start()
    {
        audioSource.PlayOneShot(mainMenuTheme);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        audioSource.Stop();
    }
    public void QuitGame()
    {
        Debug.Log("Closing game");
        Application.Quit();
    }
}