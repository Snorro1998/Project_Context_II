using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Profile", menuName = "Dialogue System/Character Profile")]
public class CharacterProfile : ScriptableObject
{
    public string myName;
    public Sprite myPortrait;
    public AudioClip myVoice;
}
