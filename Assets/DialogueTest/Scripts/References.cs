using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Middleman for communication between scriptable objects and scene objects
/// </summary>
public class References : MonoBehaviour
{
    public static References instance;

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

    public GameObject testGameObject;
}
