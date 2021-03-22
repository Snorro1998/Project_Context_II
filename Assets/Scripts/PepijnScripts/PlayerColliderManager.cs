using UnityEngine;

public class PlayerColliderManager : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = GameManager.Instance;
    }

    //All collision taggs
    //Boss
    //Monster
    //Scientist
    //CruiseSchip
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Scientist" && !gm.hasVisitedScientist)
        {
            gm.hasVisitedScientist = true;
            SaveSystem.Instance.ChangeScene("Scientist");
        }

        if (collision.tag == "CruiseSchip")
        {
            if (gm.hasVisitedScientist && !gm.hasVisitedOma)
            {
                gm.hasVisitedOma = true;
                SaveSystem.Instance.ChangeScene("Oma");
            }
            else if (!gm.hasVisitedMonster2)
            {
                gm.hasVisitedCaptain = true;
                SaveSystem.Instance.ChangeScene("Kapitein");
            }          
        }

        if (collision.tag == "Monster")
        {
            if (gm.hasVisitedOma)
            {
                gm.hasVisitedMonster = true;
                SaveSystem.Instance.ChangeScene("Monster");
            }
            else if (gm.hasVisitedBoss)
            {
                gm.hasVisitedMonster2 = true;
                SaveSystem.Instance.ChangeScene("Monster2");
            }            
        }

        if (collision.tag == "Boss" && gm.hasVisitedMonster)
        {
            gm.hasVisitedBoss = true;
            SaveSystem.Instance.ChangeScene("Boss");
        }
    }
}
