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
    }
    private void Update()
    {
        if(musicAllowed == true)
        {
            if(musicInt == 1)
            {
                MainSceneMusic.playMusic(1);
            }
            else if(musicInt == 2)
            {
                MainSceneMusic.playMusic(2);
            }
            else if (musicInt == 3)
            {
                MainSceneMusic.playMusic(3);
            }

            musicAllowed = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Scientist" && scientist == false)
        {
            scientist = true;
            musicAllowed = true;
            MainSceneMusic.stopMusic();

            SaveSystem.Instance.ChangeScene("Scientist");
        }
        if (collision.tag == "CruiseSchip" && GameManager.hasVisitedScientist == true)
        {
            GameManager.hasVisitedCaptain = true;
            musicAllowed = true;

            musicInt = 2;
            MainSceneMusic.stopMusic();
            SaveSystem.Instance.ChangeScene("Oma");
        }
        if (collision.tag == "Monster" && GameManager.hasVisitedOma == true)
        {
            GameManager.hasVisitedMonster = true;
            musicAllowed = true;
            MainSceneMusic.stopMusic();
            SaveSystem.Instance.ChangeScene("Monster");
        }
        if (collision.tag == "Boss" && GameManager.hasVisitedMonster == true)
        {
            GameManager.hasVisitedBoss = true;
            musicInt = 3;
            musicAllowed = true;
            MainSceneMusic.stopMusic();
            SaveSystem.Instance.ChangeScene("Boss");
        }
        if (collision.tag == "Monster" && GameManager.hasVisitedBoss == true)
        {
            GameManager.hasVisitedMonster2 = true;
            musicAllowed = true;
            MainSceneMusic.stopMusic();
            SaveSystem.Instance.ChangeScene("Monster2");
        }
        if (collision.tag == "CruiseSchip" && GameManager.hasVisitedMonster2 == true)
        {
            GameManager.hasVisitedCaptain = true;
            musicAllowed = true;
            MainSceneMusic.stopMusic();
            SaveSystem.Instance.ChangeScene("Kapitein");
        }
    }
}
