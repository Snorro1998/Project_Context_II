using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneMusic : MonoBehaviour
{
    public static AudioClip main1;
    public static AudioClip main2;
    public static AudioClip main3;
    static AudioSource audioSource;
    public static bool one;
    public static bool two;
    public static bool three;
    public static bool stop;
    void Awake()
    {
        one = false;
        two = false;
        three = false;
        stop = false;

        audioSource = GetComponent<AudioSource>();
        main1 = Resources.Load<AudioClip>("Main1");
        main2 = Resources.Load<AudioClip>("Main2");
        main3 = Resources.Load<AudioClip>("Main3");
    }
    private void Start()
    {
        audioSource.PlayOneShot(main1);
        Debug.Log("holl!");
    }
    public void Update()
    {
        if (one)
        {
            playMusic(1);
            one = false;
        }
        if (two)
        {
            playMusic(2);
            two = false;
        }
        if (three)
        {
            playMusic(3);
            three = false;
        }

        if (stop) stopMusic();
    }
    public static void playMusic(int layers)
    {
        if(layers == 1)
        {
            audioSource.PlayOneShot(main1);
        }
        else if(layers == 2)
        {
            audioSource.PlayOneShot(main1);
            audioSource.PlayOneShot(main2);
        }
        else if (layers == 3)
        {
            audioSource.PlayOneShot(main1);
            audioSource.PlayOneShot(main2);
            audioSource.PlayOneShot(main3);
        }
    }
    public static void stopMusic()
    {
            audioSource.Stop();
    }
}
