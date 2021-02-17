using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public struct Line
{
    public DialogueCharacter character;

    [TextArea(2, 5)]
    public string text;

    public UnityEvent actionToPerform;
}

[CreateAssetMenu(fileName = "New Conversation", menuName = "Dialogue System/Conversation")]
public class DialogueConversation : ScriptableObject
{
    public Line[] lines;
    public DialogueConversation nextConversation;
}
