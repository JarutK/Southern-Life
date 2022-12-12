using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public int money = 1000;
    public Text text;
    void Update()
    {
        text.text = money.ToString();
        money = GameManager.instance.moneyManager.money;
    }
}
