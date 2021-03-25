using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : PersistentSingleton<GameManager>
{
    //Een goede plek om alle belangijke variables en bools bij te houden.
    public bool hasVisitedScientist = false;
    public bool hasVisitedMonster = false;
    public bool hasVisitedMonster2 = false;
    public bool hasVisitedBoss = false;
    public bool hasVisitedCaptain = false;
    public bool hasVisitedOma = false;

    public int musicInt = 1;

    public Sprite sprDieselBoat;
    public Sprite sprElectricBoat;

    public bool insaneSpeed = false;
    public Pathfinding.AIPath boatObj;
    public CameraMoveScript camObj;

    private void Start()
    {
        Debug.Log("GameManagerStart");
        if (insaneSpeed)
        {
            boatObj.maxSpeed = 30;
            camObj.moveSpeed = 30;
        }
    }
}
