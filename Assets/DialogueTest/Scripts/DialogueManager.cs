using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueManager : PersistentSingleton<DialogueManager>
{

    private void Start()
    {
        var files = Resources.LoadAll("dialogue/characters", typeof(CharacterProfile));
        foreach (object o in files)
        {
            CharacterProfile prof = o as CharacterProfile;

            if (prof != null)
            {
                //Debug.Log("adding: " + prof.name.ToLower() + ", " + prof.myName);
                characterNames.Add(prof.name.ToLower(), prof.myName);
            }
        }
    }

    public GameObject dialogueBox;

    public Text dialogueName;
    public Text dialogueText;
    public Image dialoguePortrait;
    public float delay = 0.001f;

    public Queue<DialogueBase.Info> dialogueInfo = new Queue<DialogueBase.Info>();

    private bool isDialogueOption;
    public GameObject dialogueOptionUI;
    public bool inDialogue;
    public GameObject[] optionButtons;
    private int optionsAmount;
    public Text questionText;

    private bool isCurrentlyTyping;
    private string completeText;

    private Dictionary<string, string> characterNames = new Dictionary<string, string>();

    public void EnqueueDialogue(DialogueBase db)
    {
        if (inDialogue) return;
        inDialogue = true;

        dialogueBox.SetActive(true);
        dialogueInfo.Clear();

        OptionsParser(db);

        foreach(DialogueBase.Info info in db.dialogueInfo)
        {
            dialogueInfo.Enqueue(info);
        }

        DequeueDialogue();
    }

    public void DequeueDialogue()
    {
        if (isCurrentlyTyping)
        {
            CompleteText();
            StopAllCoroutines();
            isCurrentlyTyping = false;
            return;
        }

        if (dialogueInfo.Count == 0)
        {
            EndOfDialogue();
            return;
        }

        DialogueBase.Info info = dialogueInfo.Dequeue();
        info.startEvent?.Invoke();
        //completeText = info.myText;

        dialogueName.text = info.character != null ? info.character.myName : null;
        //dialogueName.text = info.character.myName;
        dialogueText.text = info.myText;
        //dialoguePortrait.sprite = info.character.myPortrait;
        dialoguePortrait.sprite = info.character != null ? info.character.myPortrait : null;
        dialoguePortrait.gameObject.SetActive(dialoguePortrait.sprite == null ? false : true);

        dialogueText.text = "";

        if (info.myText == "")
        {
            DequeueDialogue();
        }
        //dialogueBox.SetActive(!(info.myText == ""));

        StartCoroutine(TypeText(info));
    }

    private string GetName(string inputName)
    {
        string name = inputName.Substring(1, inputName.Length - 2).ToLower();
        if (characterNames.ContainsKey(name))
        {
            name = characterNames[name];
        }
        return name;
    }

    private string ParseNames(string sentence)
    {
        var tmpSentence = sentence;
        //zal wel meer dan genoeg zijn en niet unity compleet laten crashen zoals een onjuiste whileloop
        for (int i = 0; i < 50; i++)
        {
            var openingBracketPos = sentence.IndexOf("{");
            var closingBracketPos = sentence.IndexOf("}");

            if (closingBracketPos > openingBracketPos && openingBracketPos != -1)
            {
                var name = sentence.Substring(openingBracketPos, closingBracketPos - openingBracketPos + 1);
                var realname = GetName(name);
                tmpSentence = tmpSentence.Replace(name, realname);
            }
            else
            {
                break;
            }
        }
        

        return tmpSentence;
    }

    IEnumerator TypeText(DialogueBase.Info info)
    {
        isCurrentlyTyping = true;
        var txt = ParseNames(info.myText);
        completeText = txt;

        foreach (char c in txt.ToCharArray())
        {
            yield return new WaitForSeconds(delay);
            dialogueText.text += c;
            if (info.character != null)
            {
                if (info.character.myVoice != null)
                {
                    AudioManager.instance.PlayClip(info.character.myVoice);
                }
            }      
        }
        isCurrentlyTyping = false;
    }

    private void CompleteText()
    {
        dialogueText.text = completeText;
    }

    public void EndOfDialogue()
    {
        dialogueBox.SetActive(false);
        OptionsLogic();
    }

    public void OptionsLogic()
    {
        if (isDialogueOption)
        {
            dialogueOptionUI.SetActive(true); 
        }
        else
        {
            inDialogue = false;
        }
    }

    public void CloseOptions()
    {
        dialogueOptionUI.SetActive(false);
    }

    private void OptionsParser(DialogueBase db)
    {
        if (db is DialogueOptions)
        {
            isDialogueOption = true;
            DialogueOptions dialogueOptions = db as DialogueOptions;
            optionsAmount = dialogueOptions.optionsInfo.Length;
            questionText.text = dialogueOptions.questionText;

            for (int i = 0; i < optionButtons.Length; i++)
            {
                optionButtons[i].SetActive(false);
            }

            for (int i = 0; i < optionsAmount; i++)
            {
                optionButtons[i].SetActive(true);
                optionButtons[i].transform.GetChild(0).GetComponent<Text>().text = dialogueOptions.optionsInfo[i].buttonName;
                UnityEventHandler myEventHandler = optionButtons[i].GetComponent<UnityEventHandler>();
                myEventHandler.eventHandler = dialogueOptions.optionsInfo[i].myEvent;
                if (dialogueOptions.optionsInfo[i].nextDialogue != null)
                {
                    myEventHandler.myDialogue = dialogueOptions.optionsInfo[i].nextDialogue;
                }
                else
                {
                    myEventHandler.myDialogue = null;
                }
            }
        }
        else
        {
            isDialogueOption = false;
        }
    }
}
