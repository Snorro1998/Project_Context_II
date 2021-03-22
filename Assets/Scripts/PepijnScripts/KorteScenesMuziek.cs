using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KorteScenesMuziek : MonoBehaviour
{
    public static AudioClip intermissionTheme;
    static AudioSource audioSource;
    float audioTimer;
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        intermissionTheme = Resources.Load<AudioClip>("Intermission");

        //audioSource.PlayOneShot(intermissionTheme);
    }
    private void Start()
    {
        audioSource.PlayOneShot(intermissionTheme);
    }
    private void Update()
    {
        audioTimer += Time.deltaTime;
        if(audioTimer >= 46)
        {
            audioTimer = 0f;
            audioSource.PlayOneShot(intermissionTheme);
        }
    }
}
