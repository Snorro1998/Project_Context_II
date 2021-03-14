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
            SceneManager.LoadScene(7);
        }
        if (collision.tag == "Monster" && !GameManager.hasVisitedMonster)
        {
            GameManager.hasVisitedMonster = true;
            SceneManager.LoadScene(3);
        }
        if (collision.tag == "Monster" && !GameManager.hasVisitedMonster2 && GameManager.hasVisitedMonster)
        {
            GameManager.hasVisitedMonster2 = true;
            SceneManager.LoadScene(4);
        }
        if (collision.tag == "Scientist" && !GameManager.hasVisitedScientist)
        {
            GameManager.hasVisitedScientist = true;
            SceneManager.LoadScene(6);
        }
        if (collision.tag == "CruiseSchip" && !GameManager.hasVisitedCaptain && GameManager.hasVisitedOma)
        {
            GameManager.hasVisitedCaptain = true;
            SceneManager.LoadScene(2);
        }
        if (collision.tag == "CruiseSchip" && !GameManager.hasVisitedCaptain2 && GameManager.hasVisitedCaptain)
        {
            GameManager.hasVisitedCaptain = true;
            SceneManager.LoadScene(2);
        }
        if (collision.tag == "CruiseSchip" && !GameManager.hasVisitedOma)
        {
            GameManager.hasVisitedCaptain = true;
            SceneManager.LoadScene(5);
        }
    }
}
