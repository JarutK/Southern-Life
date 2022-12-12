using BayatGames.SaveGameFree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;

    public ItemContainer inventoryContainer;
    public ItemContainer shippingBox;
    public SeedContainer seedBagContainer;
    public PlantContainer plantContainer;
    public PlantContainer treeContainer;

    public CropManager cropManager;
    public TreeCropManager treeCropManager;

    public DragAndDropItem dragAndDropItem;
    public DragAndSowSeed dragAndSowSeed;
    public MoneyManager moneyManager;
    public DayTimeController dayTimeController;

    public GameObject inventoryPanel;
    public GameObject seedBagPanel;
    public GameObject plantation;
    public GameObject field;
    public GameObject quickSlotUI;
    public GameObject shopPanel;
    public GameObject shippingBoxPanel;

    public ItemDatabase itemDatabase;
    public PlantDatabase plantDatabase;

    [SerializeField] Text notificationText;
    [SerializeField] GameObject notification;

    [SerializeField] Text questText;
    [SerializeField] GameObject quest;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        for (int i = 0; i < seedBagContainer.slots.Count; i++)
        {
            seedBagContainer.slots[i].Clear();
        }
        for (int i = 0; i < inventoryContainer.slots.Count; i++)
        {
            inventoryContainer.slots[i].Clear();
        }
    }

    public void Goal()
    {
        if (dayTimeController.days == 29 && moneyManager.money >= 500)
        {
            moneyManager.money -= 500;
            notification.SetActive(true);
            notificationText.text = "คุณได้จ่ายหนี้ในเดือนนี้ไปแล้ว 500 Coin";
            quest.SetActive(true);
            questText.text = "คุณต้องจ่ายหนี้จำนวน 1000 Coin \nในวันที่ 1 เดือน 3";
        }
        else if (dayTimeController.days == 57 && moneyManager.money >= 1000)
        {
            moneyManager.money -= 1000;
            notification.SetActive(true);
            notificationText.text = "คุณได้จ่ายหนี้ในเดือนนี้ไปแล้ว 1000 Coin";
            quest.SetActive(true);
            questText.text = "คุณต้องจ่ายหนี้จำนวน 1500 Coin \nในวันที่ 1 เดือน 4";
        }
        else if (dayTimeController.days == 85 && moneyManager.money >= 1500)
        {
            moneyManager.money -= 1500;
            notification.SetActive(true);
            notificationText.text = "คุณได้จ่ายหนี้ในเดือนนี้ไปแล้ว 1500 Coin";
            quest.SetActive(true);
            questText.text = "คุณต้องจ่ายหนี้จำนวน 2000 Coin \nในวันที่ 1 เดือน 1 ของปีหน้า";
        }
        else if (dayTimeController.days == 113 && moneyManager.money >= 2000)
        {
            moneyManager.money -= 2000;
            notification.SetActive(true);
            notificationText.text = "คุณได้จ่ายหนี้ในเดือนนี้ไปแล้ว 2000 Coin \nคุณได้ใช้หนี้จนหมดแล้ว";
            quest.SetActive(false);
            notification.GetComponentInChildren<NotificationButton>().gameOver = true;
        }
        else
        {
            notification.SetActive(true);
            notificationText.text = "คุณไม่มีเงินพอที่จะจ่ายหนี้ในเดือนนี้";
            notification.GetComponentInChildren<NotificationButton>().gameOver = true;
        }
    }

    public void SetAndSaveData(int id)
    {
        dayTimeController.NextDay();
        GameData data = new GameData(player, dayTimeController, moneyManager, inventoryContainer, seedBagContainer, plantContainer, treeContainer);
        StartCoroutine(Saving(data, id));
    }
    IEnumerator Saving(GameData data, int id)
    {
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<PlayerController>().rigidbody2d.velocity = Vector2.zero;
        yield return new WaitForSeconds(2);
        SaveAndLoadSystem.SaveData(data, id);
        player.GetComponent<PlayerController>().enabled = true;
    }

    public void LoadAndGetData(int id)
    {
        GameData data = SaveAndLoadSystem.LoadData(id);
        if(data != null)
        {
            Vector2 position;
            position.x = data.position[0] - 1;
            position.y = data.position[1];
            player.transform.position = position;

            moneyManager.money = data.money;

            for (int i = 0; i < inventoryPanel.GetComponentInChildren<InventoryPanel>().inventory.slots.Count; i++)
            {
                inventoryPanel.GetComponentInChildren<InventoryPanel>().inventory.slots[i].ID = data.itemID[i];
                inventoryPanel.GetComponentInChildren<InventoryPanel>().inventory.slots[i].count = data.itemCount[i];
            }
            inventoryContainer.OnAfterDeserialize();
            for (int i = 0; i < seedBagPanel.GetComponent<SeedBagPanel>().seedBag.slots.Count; i++)
            {
                seedBagPanel.GetComponent<SeedBagPanel>().seedBag.slots[i].ID = data.seedID[i];
                seedBagPanel.GetComponent<SeedBagPanel>().seedBag.slots[i].count = data.seedCount[i];
            }
            seedBagContainer.OnAfterDeserialize();
            for (int i = 0; i < plantContainer.slots.Count; i++)
            {
                plantContainer.slots[i] = data.cropSlots[i];
                plantation.GetComponent<CropManager>().crops[i].LoadCrop();
            }

            for (int i = 0; i < treeContainer.slots.Count; i++)
            {
                treeContainer.slots[i] = data.treeCropSlots[i];
                field.GetComponent<TreeCropManager>().treeCrops[i].LoadCrop();
            }

            dayTimeController.time = 21600;
            dayTimeController.days = data.days;
            dayTimeController.calendarDay = data.calendarDay;
            dayTimeController.month = data.month;
        }
    }
}