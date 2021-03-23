using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : Singleton<BGMusic>
{
    private AudioSource musicPlayer;
    private AudioClip currentMusic = null;

    protected override void Awake()
    {
        base.Awake();
        musicPlayer = gameObject.AddComponent<AudioSource>();
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
                musicPlayer.Play();
            }
        }
        
    }
}
