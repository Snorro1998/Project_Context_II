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

    [SerializeField]
    bool layer2 = false;
    [SerializeField]
    bool layer3 = false;
    private int counter;
    [SerializeField]
    private int musicLayerCounter;

    public static AudioClip mainTheme1;
    public static AudioClip mainTheme2;
    public static AudioClip mainTheme3;
    static AudioSource audioSource;

    private bool IsPlaying1;
    private bool IsPlaying2;
    private bool IsPlaying3;

    public bool stop;


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
        audioSource = GetComponent<AudioSource>();

        mainTheme1 = Resources.Load<AudioClip>("Main_Theme1");
        mainTheme2 = Resources.Load<AudioClip>("Main_Theme2");
        mainTheme3 = Resources.Load<AudioClip>("Main_Theme3");

        layer2 = false;
        layer3 = false;
        stop = false;
    }
    private void Update()
    {
        if (musicLayerCounter == 1 && !IsPlaying1)
        {
            audioSource.PlayOneShot(mainTheme1);
            IsPlaying1 = true;
        }
        else if (musicLayerCounter == 2 && !IsPlaying2 && layer2)
        {
            audioSource.PlayOneShot(mainTheme2);
            IsPlaying2 = true;
        }
        else if (musicLayerCounter == 3 && !IsPlaying3 && layer3)
        {
            audioSource.PlayOneShot(mainTheme3);
            IsPlaying3 = true;
        }
        if (stop)
        {
            audioSource.Stop();
        }


        counter++;
        counter /= 60;
        Debug.Log(counter);
    }

}
