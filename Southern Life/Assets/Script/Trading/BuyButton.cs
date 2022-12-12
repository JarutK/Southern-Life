using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Text nameText;
    [SerializeField] Text priceText;
    [SerializeField] Plant plant;
    MoneyManager moneyManager;
    public int count = 1;
    int price;

    private void Start()
    {
        icon.sprite = plant.icon;
        nameText.text = plant.Name;
        priceText.text = plant.price.ToString();
        price = plant.price;
    }
    public void Buy()
    {
        moneyManager = GameManager.instance.moneyManager;
        if (moneyManager.money >= price)
        {
            GameManager.instance.seedBagContainer.Add(plant, count);
            GameManager.instance.seedBagContainer.OnAfterDeserialize();
            moneyManager.money -= price;
        }
    }
}
