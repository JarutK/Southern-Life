using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestButton : MonoBehaviour
{
    [SerializeField] GameObject questBoard;

    public void toggleQuest()
    {
        questBoard.SetActive(!questBoard.activeInHierarchy);
    }
}
