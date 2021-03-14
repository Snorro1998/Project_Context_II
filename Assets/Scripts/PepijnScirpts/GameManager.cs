using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Een goede plek om alle belangijke variables en bools bij te houden.
    public static bool boatIsMoving;
    public static bool hasVisitedScientist = false;
    public static bool hasVisitedMonster = false;
    public static bool hasVisitedMonster2 = false;
    public static bool hasVisitedBoss = false;
    public static bool hasVisitedCaptain = false;
    public static bool hasVisitedCaptain2 = false;
    public static bool hasVisitedOma = false;
    int counter;
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
    private void Update()
    {
        counter++;
        counter /= 60;
        Debug.Log(counter);
    }
}
