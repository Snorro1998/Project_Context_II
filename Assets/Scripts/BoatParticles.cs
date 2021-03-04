using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SmokeMode
{
    engineIdle,
    engineRunning
}

public class BoatParticles : MonoBehaviour
{
    private SmokeMode _smokeMode;

    public SmokeMode smokeMode
    {
        get { return _smokeMode; }
        set { _smokeMode = value; }
    }

    public ParticleSystem smokeStack;
}
