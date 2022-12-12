using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkScene1Dialogue : MonoBehaviour
{
    public Dialogue dialogue;
    public SceneLoader sceneLoader;

    void Start()
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (DialogueManager.instance.canvas.activeInHierarchy == true)
            {
                DialogueManager.instance.Next();
            }
        }
        if (DialogueManager.instance.canvas.activeInHierarchy == false)
        {
            sceneLoader.NewScene("OpeningScene");
        }
    }
}
