using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDisplay : MonoBehaviour
{
    public DialogueConversation conversation;

    public GameObject speaker;
    private SpeakerUI speakerUI;

    private int activeLineIndex = 0;
    private Line currentLine;

    public Coroutine cor;
    private AudioSource aud;

    private void Start()
    {
        speakerUI = speaker.GetComponent<SpeakerUI>();
        aud = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            AdvanceConversation();
        }
    }

    void AdvanceConversation()
    {
        if (cor == null)
        {
            if (activeLineIndex < conversation.lines.Length)
            {
                speakerUI.Show();
                currentLine = conversation.lines[activeLineIndex];
                speakerUI.portrait.sprite = currentLine.character.portrait;
                speakerUI.fullName.text = currentLine.character.fullName;
                aud.clip = currentLine.character.speakSound;
                cor = StartCoroutine(NextLine());
                activeLineIndex++;
            }
            else
            {
                activeLineIndex = 0;
                speakerUI.Hide();
            }
        }
        else
        {
            StopCoroutine(cor);
            cor = null;
            speakerUI.dialogue.text = currentLine.text;
        }
    }

    private IEnumerator NextLine()
    {
        int len = currentLine.text.Length;
        int i = 0;
        string txt = "";

        while(i < len)
        {
            txt += currentLine.text[i];
            speakerUI.dialogue.text = txt;
            if (aud.clip != null)
            {
                aud.PlayOneShot(aud.clip, 1f);
            }
            i++;
            yield return new WaitForSeconds(.05f);
        }
        cor = null;
    }

    void SetDialogue(SpeakerUI speaker, Line line)
    {
        speaker.dialogue.text = line.text;
        speaker.fullName.text = line.character.fullName;
        speaker.portrait.sprite = line.character.portrait;
        speaker.Show();
    }
}
