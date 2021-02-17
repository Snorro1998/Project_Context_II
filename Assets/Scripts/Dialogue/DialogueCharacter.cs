using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Dialogue System/Character")]
public class DialogueCharacter : ScriptableObject
{
    public string fullName;
    public Sprite portrait;
    public AudioClip speakSound;
}
