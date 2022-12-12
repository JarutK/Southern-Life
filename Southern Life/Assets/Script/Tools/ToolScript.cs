using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolScript : MonoBehaviour
{
    GameObject inventoryPanel;
    GameObject shop;
    GameObject shippingBox;
    public static string currentTool = "none";
    public static int fillWaterCan = 10;
    GameObject seedBagPanel;

    private void Start()
    {
        seedBagPanel = GameManager.instance.seedBagPanel;
        shop = GameManager.instance.shopPanel;
        shippingBox = GameManager.instance.shippingBoxPanel;
        inventoryPanel = GameManager.instance.inventoryPanel;
    }
    public void UseHoe()
    {
        currentTool = "Hoe";
        seedBagPanel.SetActive(false);
    }

    public void UseSeedBag()
    {
        currentTool = "SeedBag";
        if (shop.activeInHierarchy == false && shippingBox.activeInHierarchy == false && inventoryPanel.activeInHierarchy == false)
        {
            seedBagPanel.SetActive(!seedBagPanel.activeInHierarchy);
        }
    }

    public void UseWateringCan()
    {
        currentTool = "WateringCan";
        seedBagPanel.SetActive(false);
    }
    public void UseFertilizerBag()
    {
        currentTool = "FertilizerBag";
        seedBagPanel.SetActive(false);
    }
    public void UseScythe()
    {
        currentTool = "Scythe";
        seedBagPanel.SetActive(false);
    }

    public void Empty()
    {
        currentTool = "None";
        seedBagPanel.SetActive(false);
    }
}
