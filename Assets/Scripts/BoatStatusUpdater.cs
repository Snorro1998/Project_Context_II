using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatStatusUpdater : MonoBehaviour
{
    private Pathfinding.AIPath pathObj;
    private Vector3 lastPosition;

    public AudioClip boatIdleSound;
    public AudioClip boatMovingSound;

    public ParticleSystem waves;

    private AudioSource audioSource;

    public enum BoatStatus
    {
        invalid,
        idle,
        moving
    }

    private void PlaySound(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }

    public BoatStatus boatStatus;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        lastPosition = transform.position;
        ChangeBoatStatus(BoatStatus.idle);
    }

    private void ChangeBoatStatus(BoatStatus newBoatStatus)
    {
        if (boatStatus == newBoatStatus) return;
        switch (newBoatStatus)
        {
            case BoatStatus.idle:
                waves.enableEmission = false;
                PlaySound(boatIdleSound);
                break;
            case BoatStatus.moving:
                waves.enableEmission = true;
                PlaySound(boatMovingSound);
                break;
        }
        boatStatus = newBoatStatus;
    }

    private void Update()
    {
        if (transform.position != lastPosition)
        {
            ChangeBoatStatus(BoatStatus.moving);
            lastPosition = transform.position;
        }
        else
        {
            ChangeBoatStatus(BoatStatus.idle);
        }
    }
}
