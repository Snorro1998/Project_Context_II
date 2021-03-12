using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Een goede plek om alle belangijke variables en bools bij te houden.
    public static bool boatIsMoving;
    public static bool canBoatmove = true;
    public static bool isInCutscene;
    int counter;
    public static Vector3 boatPosition = new Vector3();
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
