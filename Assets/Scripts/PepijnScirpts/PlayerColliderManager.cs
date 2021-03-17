using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerColliderManager : MonoBehaviour
{
    //All collision taggs
    //Boss
    //Monster
    //Scientist
    //CruiseSchip
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Boss" && !GameManager.hasVisitedBoss)
        {
            GameManager.hasVisitedBoss = true;
            SaveSystem.Instance.ChangeScene("Boss");
            //SceneManager.LoadScene(7);
        }
        if (collision.tag == "Monster" && !GameManager.hasVisitedMonster)
        {
            GameManager.hasVisitedMonster = true;
            SaveSystem.Instance.ChangeScene("Monster");
            //SceneManager.LoadScene(3);
        }
        if (collision.tag == "Monster" && !GameManager.hasVisitedMonster2 && GameManager.hasVisitedMonster)
        {
            GameManager.hasVisitedMonster2 = true;
            SaveSystem.Instance.ChangeScene("Monster2");
            //SceneManager.LoadScene(4);
        }
        if (collision.tag == "Scientist" && !GameManager.hasVisitedScientist)
        {
            GameManager.hasVisitedScientist = true;
            SaveSystem.Instance.ChangeScene("Scientist");
            //SceneManager.LoadScene(6);
        }
        if (collision.tag == "CruiseSchip" && !GameManager.hasVisitedCaptain && GameManager.hasVisitedOma)
        {
            GameManager.hasVisitedCaptain = true;
            SaveSystem.Instance.ChangeScene("Kapitein");
            //SceneManager.LoadScene(2);
        }
        if (collision.tag == "CruiseSchip" && !GameManager.hasVisitedCaptain2 && GameManager.hasVisitedCaptain)
        {
            GameManager.hasVisitedCaptain = true;
            SaveSystem.Instance.ChangeScene("Kapitein");
            //SceneManager.LoadScene(2);
        }
        if (collision.tag == "CruiseSchip" && !GameManager.hasVisitedOma)
        {
            GameManager.hasVisitedCaptain = true;
            SaveSystem.Instance.ChangeScene("Oma");
            //SceneManager.LoadScene(5);
        }
    }
}
