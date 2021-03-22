using UnityEngine;

public class PlayerColliderManager : MonoBehaviour
{
    //All collision taggs
    //Boss
    //Monster
    //Scientist
    //CruiseSchip
    // Start is called before the first frame update
    private void Update()
    {
        GameManager.playMusic = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Scientist" && GameManager.hasVisitedScientist == false)
        {
            Debug.Log("heyhoi");
            GameManager.hasVisitedScientist = true;
            SaveSystem.Instance.ChangeScene("Scientist");
        }
        if (collision.tag == "CruiseSchip" && GameManager.hasVisitedScientist == true)
        {
            GameManager.hasVisitedCaptain = true;
            GameManager.playMusic = false;
            Debug.Log("helo");
            SaveSystem.Instance.ChangeScene("Oma");
        }
        if (collision.tag == "Monster" && GameManager.hasVisitedOma == true)
        {
            GameManager.hasVisitedMonster = true;
            GameManager.playMusic = false;
            SaveSystem.Instance.ChangeScene("Monster");
        }
        if (collision.tag == "Boss" && GameManager.hasVisitedMonster == true)
        {
            GameManager.hasVisitedBoss = true;
            GameManager.playMusic = false;
            SaveSystem.Instance.ChangeScene("Boss");
        }
        if (collision.tag == "Monster" && GameManager.hasVisitedBoss == true)
        {
            GameManager.hasVisitedMonster2 = true;
            GameManager.playMusic = false;
            SaveSystem.Instance.ChangeScene("Monster2");
        }
        if (collision.tag == "CruiseSchip" && GameManager.hasVisitedMonster2 == true)
        {
            GameManager.hasVisitedCaptain = true;
            GameManager.playMusic = false;
            SaveSystem.Instance.ChangeScene("Kapitein");
        }
    }
}
