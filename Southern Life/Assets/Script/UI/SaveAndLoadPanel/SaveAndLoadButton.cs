using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveAndLoadButton : MonoBehaviour
{
    [SerializeField] GameObject saveAndLoadPanel;
    [SerializeField] Text dataText;
    int day;
    int month;
    int money;
    bool save;
    public void doSaveOrLoadFile1()
    {
        save = saveAndLoadPanel.GetComponent<SaveAndLoadPanel>().save;
        if (save)
        {
            GameManager.instance.SetAndSaveData(1);
            GetDate();
            dataText.text = "Day: " + day + " , Month: " + month + "\n Money: " + money;
        }
        else
        {
            GameManager.instance.LoadAndGetData(1);
        }
        saveAndLoadPanel.SetActive(false);
    }

    public void doDeleteFile1()
    {
        SaveAndLoadSystem.DeleteData(1);
        dataText.text = "Empty";
    }

    public void doSaveOrLoadFile2()
    {
        save = saveAndLoadPanel.GetComponent<SaveAndLoadPanel>().save;
        if (save)
        {
            GameManager.instance.SetAndSaveData(2);
            GetDate();
            dataText.text = "Day: " + day + " , Month: " + month + "\n Money: " + money;
        }
        else
        {
            GameManager.instance.LoadAndGetData(2);
        }
        saveAndLoadPanel.SetActive(false);
    }

    public void doDeleteFile2()
    {
        SaveAndLoadSystem.DeleteData(2);
        dataText.text = "Empty";
    }

    public void doSaveOrLoadFile3()
    {
        save = saveAndLoadPanel.GetComponent<SaveAndLoadPanel>().save;
        if (save)
        {
            GameManager.instance.SetAndSaveData(3);
            GetDate();
            dataText.text = "Day: " + day + " , Month: " + month + "\n Money: " + money;
        }
        else
        {
            GameManager.instance.LoadAndGetData(3);
        }
        saveAndLoadPanel.SetActive(false);
    }

    public void doDeleteFile3()
    {
        SaveAndLoadSystem.DeleteData(3);
        dataText.text = "Empty";
    }

    public void doCancel()
    {
        saveAndLoadPanel.SetActive(false);
    }

    private void GetDate()
    {
        day = GameManager.instance.dayTimeController.calendarDay;
        month = GameManager.instance.dayTimeController.month;
        money = GameManager.instance.moneyManager.money;
    }
}
