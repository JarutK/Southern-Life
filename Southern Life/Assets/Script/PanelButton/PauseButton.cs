using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] PauseController pauseController;

    public void PauseControl()
    {
        pauseController.isPasued = !pauseController.isPasued;
    }
}
