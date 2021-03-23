using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextroomOnclikc : MonoBehaviour
{
    bool clicked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !clicked)
        {
            SaveSystem.Instance.ChangeScene("12 Teaser");
            clicked = true;
        }
    }
}
