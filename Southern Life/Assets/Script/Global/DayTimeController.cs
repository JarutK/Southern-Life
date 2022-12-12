using BayatGames.SaveGameFree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class DayTimeController : MonoBehaviour
{
    const float secondInDay = 86400f;
    [SerializeField] Color nightLightColor;
    [SerializeField] AnimationCurve nightTimeCurve;
    [SerializeField] Color dayLightColor = Color.white;
    

    public float time = 21600;
    [SerializeField] float timeScale = 80.2973978f;
    [SerializeField] Text timerText;
    [SerializeField] Text dayText;
    [SerializeField] Text monthText;

    [SerializeField] UnityEngine.Rendering.Universal.Light2D globalLight;
    public int days = 1;
    public int calendarDay = 1;
    public int month = 1;
    float Hours
    {
        get { return time / 3600f; }
    }
    float Minutes
    {
        get { return time % 3600f / 60f; }
    }
    void Update()
    {
        time += Time.deltaTime * timeScale;
        int hh = (int)Hours;
        int mm = (int)Minutes;
        timerText.text = hh.ToString("00") + ":" + mm.ToString("00");
        
        dayText.text = calendarDay.ToString();
        monthText.text = month.ToString();

        float v = nightTimeCurve.Evaluate(Hours);
        Color c = Color.Lerp(dayLightColor, nightLightColor, v);
        globalLight.color = c;
        if (time > secondInDay)
        {
            NextDay();
        }
    }
    public void NextDay()
    {
        time = 21600;
        days += 1;
        calendarDay += 1;
        if (calendarDay > 28)
        {
            calendarDay = 1;
            month += 1;
            GameManager.instance.Goal();
        }
        if (month == 5)
        {
            month = 1;
        }
    }
}
