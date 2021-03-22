using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public static AudioClip boatHorn5;
    public static AudioClip menuClick;
    public static AudioClip typeWriterEnd;

    [SerializeField]
    private AudioClip[] boatHorns = new AudioClip[4];
    [SerializeField]
    private AudioClip[] monsterGrowls = new AudioClip[4];
    [SerializeField]
    private static AudioClip[] typeWriterPresses = new AudioClip[6];

    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        boatHorns[0] = Resources.Load<AudioClip>("boatHorn1");
        boatHorns[1] = Resources.Load<AudioClip>("boatHorn2");
        boatHorns[2] = Resources.Load<AudioClip>("boatHorn3");
        boatHorns[3] = Resources.Load<AudioClip>("boatHorn4");

        monsterGrowls[0] = Resources.Load<AudioClip>("monsterGrowl1");
        monsterGrowls[1] = Resources.Load<AudioClip>("monsterGrowl2");
        monsterGrowls[2] = Resources.Load<AudioClip>("monsterGrowl3");
        monsterGrowls[3] = Resources.Load<AudioClip>("monsterGrowl4");

        typeWriterPresses[0] = Resources.Load<AudioClip>("TypeWriterPress1");
        typeWriterPresses[1] = Resources.Load<AudioClip>("TypeWriterPress2");
        typeWriterPresses[2] = Resources.Load<AudioClip>("TypeWriterPress3");
        typeWriterPresses[3] = Resources.Load<AudioClip>("TypeWriterPress4");
        typeWriterPresses[4] = Resources.Load<AudioClip>("TypeWriterPress5");
        typeWriterPresses[5] = Resources.Load<AudioClip>("TypeWriterPress6");

        boatHorn5 = Resources.Load<AudioClip>("boatHorn5");
        menuClick = Resources.Load<AudioClip>("MenuClick1");
        typeWriterEnd = Resources.Load<AudioClip>("TypeWriterEnd");

        //audioSource.PlayOneShot(typeWriterEnd);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void MenuClick()
    {
        audioSource.PlayOneShot(menuClick);
    }
    public static void DialogueSFX(bool isEnd)
    {
        if (isEnd)
        {
            audioSource.PlayOneShot(typeWriterEnd);
        }
        else
        {
            audioSource.PlayOneShot(typeWriterPresses[Random.Range(0, 5)]);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "VissersBoot")//Een trigger collider om de vissersboot.
        {
            audioSource.PlayOneShot(boatHorns[Random.Range(0, 3)]);
        }
        if(collision.tag == "CruiseShip")//Een grote trigger collider om het cruiseschip heen zetten.
        {
            audioSource.PlayOneShot(boatHorn5);
        }
        if(collision.tag == "Monster")
        {
            audioSource.PlayOneShot(boatHorns[Random.Range(0, 3)]);
        }
    }
}
