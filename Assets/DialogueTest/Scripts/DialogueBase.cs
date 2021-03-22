using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Conversation", menuName = "Dialogue System/Conversation")]
public class DialogueBase : ScriptableObject
{
    [System.Serializable]
    public class Info
    {
        public CharacterProfile character;
        [TextArea(4, 8)]
        public string myText;
        public UnityEvent startEvent;
    }

    [Header("Insert dialogue information below")]
    public Info[] dialogueInfo;
}
