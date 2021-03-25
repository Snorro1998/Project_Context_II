using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// Custom event class for dialogue buttons
/// </summary>
public class UnityEventHandler : MonoBehaviour, IPointerDownHandler
{
    public UnityEvent eventHandler;
    public DialogueBase myDialogue;

    //Executes when you click the button
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        eventHandler.Invoke();
        DialogueManager.Instance.CloseOptions();
        DialogueManager.Instance.inDialogue = false;

        if (myDialogue != null)
        {
            DialogueManager.Instance.EnqueueDialogue(myDialogue);
        }
    }
}
