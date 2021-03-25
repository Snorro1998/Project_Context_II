using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A test script to initiate a conversation
/// </summary>
public class DialogueStarter : MonoBehaviour
{
    public DialogueBase dialogue;
    public bool playOnStart = false;
    public bool playOnce = true;
    private bool hasTriggered = false;

    private void Start()
    {
        if (playOnStart)
        {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        DialogueManager.Instance.EnqueueDialogue(dialogue);
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
