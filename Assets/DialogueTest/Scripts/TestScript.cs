using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A test script to initiate a conversation
/// </summary>
public class TestScript : MonoBehaviour
{
    public DialogueBase dialogue;
    public bool hasTriggered = false;

    public void TriggerDialogue()
    {
        DialogueManager.instance.EnqueueDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasTriggered)
        {
            TriggerDialogue();
            hasTriggered = true;
        }
    }
}
