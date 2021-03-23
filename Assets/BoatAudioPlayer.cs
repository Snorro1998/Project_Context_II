using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatAudioPlayer : MonoBehaviour
{
    private AudioClip sndEngine;
    private List<AudioClip> sndsHorn = new List<AudioClip>();
    private AudioSource asEngine;
    private AudioSource asHorn;
    public int possibility = 500;

    public enum ShipType
    {
        small,
        big
    }

    public ShipType shipType;

    private void Awake()
    {
        InitShipSounds();
        SetupAudioSources();
        asEngine.Play();
    }

    private void InitShipSounds()
    {
        sndEngine = Resources.Load<AudioClip>("sfx/Boat Engine 1");

        switch (shipType)
        {
            case ShipType.big:
                sndsHorn.Add(Resources.Load<AudioClip>("sfx/Boat Horn11"));
                sndsHorn.Add(Resources.Load<AudioClip>("sfx/Boat Horn12"));
                break;
            case ShipType.small:
                sndsHorn.Add(Resources.Load<AudioClip>("sfx/Boat Horn 21"));
                sndsHorn.Add(Resources.Load<AudioClip>("sfx/Boat Horn 22"));
                sndsHorn.Add(Resources.Load<AudioClip>("sfx/Boat Horn 23"));
                break;
        }
    }
    private void SetupAudioSources()
    {
        asEngine = gameObject.AddComponent<AudioSource>();
        asEngine.clip = sndEngine;
        asEngine.loop = true;
        asEngine.volume = 0.5f;
        asEngine.spatialBlend = 1;
        asEngine.maxDistance = 20;
        asEngine.rolloffMode = AudioRolloffMode.Linear;

        asHorn = gameObject.AddComponent<AudioSource>();
        asHorn.spatialBlend = 1;
        asHorn.maxDistance = 20;
    }

    private void FixedUpdate()
    {      
        if (Random.Range(0, possibility) == 0 && !asHorn.isPlaying)
        {
            asHorn.clip = sndsHorn[Random.Range(0, sndsHorn.Count)];
            asHorn.Play();
        }
        
    }
}
