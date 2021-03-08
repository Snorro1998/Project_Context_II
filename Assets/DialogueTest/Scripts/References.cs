using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

/// <summary>
/// Script dat het voor scriptable objects mogelijk maakt om met scene objects te interacteren
/// </summary>
public class References : MonoBehaviour
{
    public static References instance;
    public Volume postVolum;
    private ColorAdjustments cols;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        postVolum.profile.TryGet(out cols);
    }

    public void DoSomethingGood()
    {
        cols.saturation.value = 0;
    }

    public void DoSomethingBad()
    {
        cols.saturation.value = -100;
    }
}
