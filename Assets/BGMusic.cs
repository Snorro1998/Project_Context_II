using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : Singleton<BGMusic>
{
    private AudioSource musicPlayer;
    private AudioClip currentMusic = null;

    private AudioSource sfxPlayer;
    public AudioClip monsterSound;
    public AudioClip monsterSound2;

    public void PlayMonsterSound1()
    {
        sfxPlayer.clip = monsterSound;
        sfxPlayer.Play();
    }

    public void PlayMonsterSound2()
    {
        sfxPlayer.clip = monsterSound2;
        sfxPlayer.Play();
    }

    protected override void Awake()
    {
        base.Awake();
        musicPlayer = gameObject.AddComponent<AudioSource>();
        sfxPlayer = gameObject.AddComponent<AudioSource>();
    }

    private void Start()
    {       
        UpdateMusic();
    }

    public void UpdateMusic()
    {
        var rmSettings = FindObjectOfType<RoomSettings>();
        if (rmSettings)
        {
            if (rmSettings.music != musicPlayer.clip)
            {
                musicPlayer.Stop();
                musicPlayer.clip = rmSettings.music;
                musicPlayer.loop = rmSettings.musicLoop;
                if (musicPlayer.clip != null) musicPlayer.Play();
            }
        }
        
    }
}
