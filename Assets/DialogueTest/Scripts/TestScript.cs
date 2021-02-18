using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A test script to initiate a conversation
/// </summary>
public class TestScript : MonoBehaviour
{
    public DialogueBase dialogue;

    public void TriggerDialogue()
    {
        DialogueManager.instance.EnqueueDialogue(dialogue);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TriggerDialogue();
        }
    }
}
