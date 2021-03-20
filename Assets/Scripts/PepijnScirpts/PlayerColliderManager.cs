using UnityEngine;

public class PlayerColliderManager : MonoBehaviour
{
    //All collision taggs
    //Boss
    //Monster
    //Scientist
    //CruiseSchip
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Scientist" && !GameManager.hasVisitedScientist)
        {
            GameManager.hasVisitedScientist = true;
            SaveSystem.Instance.ChangeScene("Scientist");
        }
        if (collision.tag == "CruiseSchip" && GameManager.hasVisitedScientist)
        {
            GameManager.hasVisitedCaptain = true;
            SaveSystem.Instance.ChangeScene("Oma");
        }
        if (collision.tag == "Monster" && GameManager.hasVisitedOma)
        {
            GameManager.hasVisitedMonster = true;
            SaveSystem.Instance.ChangeScene("Monster");
        }
        if (collision.tag == "Boss" && GameManager.hasVisitedMonster)
        {
            GameManager.hasVisitedBoss = true;
            SaveSystem.Instance.ChangeScene("Boss");
        }
        if (collision.tag == "Monster" && GameManager.hasVisitedBoss)
        {
            GameManager.hasVisitedMonster2 = true;
            SaveSystem.Instance.ChangeScene("Monster2");
        }
        if (collision.tag == "CruiseSchip" && !GameManager.hasVisitedMonster2)
        {
            GameManager.hasVisitedCaptain = true;
            SaveSystem.Instance.ChangeScene("Kapitein");
        }
    }
}
