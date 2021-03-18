using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public static AudioClip mainTheme;
    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        mainTheme = Resources.Load<AudioClip>("Title_Screen");
        audioSource = GetComponent<AudioSource>();

        audioSource.PlayOneShot(mainTheme);
    }
}
