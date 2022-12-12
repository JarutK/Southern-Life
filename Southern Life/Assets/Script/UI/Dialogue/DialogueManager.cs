using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public Text nameText, dialogueText;
    public GameObject canvas;
    Queue<string> text;
    Queue<string> characterName;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        text = new Queue<string>();
        characterName = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        canvas.SetActive(true);

        text.Clear();
        characterName.Clear();

        for (int i = 0; i < dialogue.text.Length; i++)
        {
            text.Enqueue(dialogue.text[i]);
            characterName.Enqueue(dialogue.characterName[i]);
        }

        Next();
    }

    public void Next()
    {
        if (text.Count == 0)
        {
            canvas.SetActive(false);
        }
        else
        {
            string ch = characterName.Dequeue();
            nameText.text = ch;
            dialogueText.text = text.Dequeue();
        }
    }
}
