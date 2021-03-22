using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    //Een goede plek om alle belangijke variables en bools bij te houden.
    public static bool boatIsMoving;
    public bool hasVisitedScientist = false;
    public bool hasVisitedMonster = false;
    public bool hasVisitedMonster2 = false;
    public bool hasVisitedBoss = false;
    public bool hasVisitedCaptain = false;
    public bool hasVisitedCaptain2 = false;
    public bool hasVisitedOma = false;
}
