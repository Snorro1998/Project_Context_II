using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Een goede plek om alle belangijke variables en bools bij te houden.
    public static bool boatIsMoving;
    public static bool canBoatmove = true;
    public static bool isInCutscene;
    public static Vector3 boatPosition = new Vector3();

    void Update()
    {
        
    }
}
