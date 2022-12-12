using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OpeningDialogue : MonoBehaviour
{
    public Dialogue openingDialogue;
    public PlayableDirector playableDirector;
    public SceneLoader sceneLoader;

    void Start()
    {
        DialogueManager.instance.StartDialogue(openingDialogue);
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
            playableDirector.Play();
        }
    }
}
