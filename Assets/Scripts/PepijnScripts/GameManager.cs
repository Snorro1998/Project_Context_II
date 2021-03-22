using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Een goede plek om alle belangijke variables en bools bij te houden.
    public static bool hasVisitedScientist;
    public static bool hasVisitedMonster;
    public static bool hasVisitedMonster2;
    public static bool hasVisitedBoss;
    public static bool hasVisitedCaptain;
    public static bool hasVisitedOma;
    public static bool playMusic;
    public static GameManager Instance
    {
        get;
        private set;
    }

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        hasVisitedScientist = false;
        hasVisitedMonster = false;
        hasVisitedMonster2 = false;
        hasVisitedBoss = false;
        hasVisitedCaptain = false;
        hasVisitedOma = false;
        playMusic = false;
    }
    private void Update()
    {
        if(hasVisitedScientist == true)
        {
            Debug.Log("wtf");
        }
    }
}
