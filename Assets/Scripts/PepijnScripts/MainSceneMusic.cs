using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneMusic : Singleton<MainSceneMusic>
{
    private AudioSource channel1;
    private AudioSource channel2;
    private AudioSource channel3;


    protected override void Awake()
    {
        base.Awake();

        channel1 = gameObject.AddComponent<AudioSource>();
        channel2 = gameObject.AddComponent<AudioSource>();
        channel3 = gameObject.AddComponent<AudioSource>();

        channel1.clip = Resources.Load<AudioClip>("Main1");
        channel2.clip = Resources.Load<AudioClip>("Main2");
        channel3.clip = Resources.Load<AudioClip>("Main3");
    }
    private void Start()
    {
        switch(GameManager.Instance.musicInt)
        {
            default:
                channel1.Play();
                break;
            case 2:
                channel1.Play();
                channel2.Play();
                break;
            case 3:
                channel1.Play();
                channel2.Play();
                channel3.Play();
                break;

        }
    }
    public void Update()
    {
        /*
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
        */
    }
    public void playMusic(int layers)
    {
        /*
        aud = GetComponent<AudioSource>();
        if (layers == 1)
        {
            aud.PlayOneShot(Resources.Load<AudioClip>("Main1"));
        }
        else if(layers == 2)
        {
            aud.PlayOneShot(Resources.Load<AudioClip>("Main1"));
            aud.PlayOneShot(Resources.Load<AudioClip>("Main2"));
        }
        else if (layers == 3)
        {
            aud.PlayOneShot(Resources.Load<AudioClip>("Main1"));
            aud.PlayOneShot(Resources.Load<AudioClip>("Main2"));
            aud.PlayOneShot(Resources.Load<AudioClip>("Main3"));
        }
        */
    }
    public void stopMusic()
    {
        channel1.Stop();
        channel2.Stop();
        channel3.Stop();
    }
}
