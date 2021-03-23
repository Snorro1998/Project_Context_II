using UnityEngine;

public class PlayerColliderManager : MonoBehaviour
{
    //All collision taggs
    //Boss
    //Monster
    //Scientist
    //CruiseSchip
    // Start is called before the first frame update
    private bool musicAllowed;
    private int musicInt = 0;
    private bool scientist;

    private void Start()
    {
        scientist = false;
        musicAllowed = true;
    }
    private void Update()
    {
        if(musicAllowed == true)
        {
            if(musicInt == 1)
            {
                MainSceneMusic.Instance.playMusic(1);
            }
            else if(musicInt == 2)
            {
                MainSceneMusic.Instance.playMusic(2);
            }
            else if (musicInt == 3)
            {
                MainSceneMusic.Instance.playMusic(3);
            }

            musicAllowed = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //klaar
        if (collision.tag == "Scientist" && scientist == false)
        {
            scientist = true;
            GameManager.Instance.hasVisitedScientist = true;
            musicAllowed = true;
            MainSceneMusic.Instance.stopMusic();

            SaveSystem.Instance.ChangeScene("3 Scientist");
        }
        //klaar
        if (collision.tag == "CruiseSchip" && GameManager.Instance.hasVisitedScientist == true && !GameManager.Instance.hasVisitedOma)
        {
            GameManager.Instance.hasVisitedCaptain = true;
            GameManager.Instance.hasVisitedOma = true;
            musicAllowed = true;

            musicInt = 2;
            MainSceneMusic.Instance.stopMusic();
            SaveSystem.Instance.ChangeScene("4 Cruise");
        }

        if (collision.tag == "Monster" && GameManager.Instance.hasVisitedOma == true && !GameManager.Instance.hasVisitedMonster)
        {
            GameManager.Instance.hasVisitedMonster = true;
            musicAllowed = true;
            MainSceneMusic.Instance.stopMusic();
            SaveSystem.Instance.ChangeScene("7 Monster");
        }
        if (collision.tag == "Boss" && GameManager.Instance.hasVisitedMonster == true)
        {
            GameManager.Instance.hasVisitedBoss = true;
            musicInt = 3;
            musicAllowed = true;
            MainSceneMusic.Instance.stopMusic();
            SaveSystem.Instance.ChangeScene("Boss");
        }
        if (collision.tag == "Monster" && GameManager.Instance.hasVisitedBoss == true)
        {
            GameManager.Instance.hasVisitedMonster2 = true;
            musicAllowed = true;
            MainSceneMusic.Instance.stopMusic();
            SaveSystem.Instance.ChangeScene("Monster2");
        }
        if (collision.tag == "CruiseSchip" && GameManager.Instance.hasVisitedMonster2 == true)
        {
            GameManager.Instance.hasVisitedCaptain = true;
            musicAllowed = true;
            MainSceneMusic.Instance.stopMusic();
            SaveSystem.Instance.ChangeScene("Kapitein");
        }
    }
}
