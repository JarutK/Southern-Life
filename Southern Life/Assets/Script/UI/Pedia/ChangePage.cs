using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePage : MonoBehaviour
{
    public PediaManager pediaManager;
    public void NextButton()
    {
        pediaManager.NextPage();
    }

    public void PreviousButton()
    {
        pediaManager.PreviousPage();
    }
}
