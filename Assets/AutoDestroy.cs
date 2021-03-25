using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    private DialogueStarter starter;

    // Start is called before the first frame update
    void Start()
    {
        starter = GetComponent<DialogueStarter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (starter.hasTriggered)
        {
            Destroy(gameObject);
        }
    }
}
