using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FileTextManager : MonoBehaviour
{
    [SerializeField] Text dataText1;
    [SerializeField] Text dataText2;
    [SerializeField] Text dataText3;
    GameData data;
    private void Start()
    {
        data = SaveAndLoadSystem.LoadData(1);
        if (data != null)
        {
            dataText1.text = "Day: " + data.calendarDay + " , Month: " + data.month + "\n Money: " + data.money;
        }
        else
            dataText1.text = "Empty";

        data = SaveAndLoadSystem.LoadData(2);
        if (data != null)
        {
            dataText2.text = "Day: " + data.calendarDay + " , Month: " + data.month + "\n Money: " + data.money;
        }
        else
            dataText2.text = "Empty";

        data = SaveAndLoadSystem.LoadData(3);
        if (data != null)
        {
            dataText3.text = "Day: " + data.calendarDay + " , Month: " + data.month + "\n Money: " + data.money;
        }
        else
            dataText3.text = "Empty";
    }
}
