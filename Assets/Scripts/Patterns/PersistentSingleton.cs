using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton object die tussen scenes blijft bestaan
/// </summary>
public class PersistentSingleton<T> : Singleton<T> where T : Component
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
    }
}
