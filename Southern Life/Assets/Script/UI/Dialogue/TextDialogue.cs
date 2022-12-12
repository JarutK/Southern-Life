using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDialogue : MonoBehaviour
{
    public Dialogue dialogue1;

    void Start()
    {
        DialogueManager.instance.StartDialogue(dialogue1);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (DialogueManager.instance.canvas.activeInHierarchy == true)
            {
                DialogueManager.instance.Next();
            }
            else
            {
                DialogueManager.instance.StartDialogue(dialogue1);
            }
        }
    }
}
