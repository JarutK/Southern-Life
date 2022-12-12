using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float[] position;

    public int days;
    public int calendarDay;
    public int month;

    public int money;

    public int[] itemID;
    public int[] itemCount;
    public int[] seedID;
    public int[] seedCount;
    public CropSlot[] cropSlots;
    public CropSlot[] treeCropSlots;

    public PlantContainer field;

    public GameData(GameObject player,
                    DayTimeController dayTimeController,
                    MoneyManager moneyManager,
                    ItemContainer inventory, 
                    SeedContainer seedBag,
                    PlantContainer plantContainer,
                    PlantContainer treeContainer)
    {
        this.itemID = new int[36];
        this.itemCount = new int[36];
        this.seedID = new int[8];
        this.seedCount = new int[8];
        cropSlots = new CropSlot[36];
        treeCropSlots = new CropSlot[6];
        position = new float[2] { player.transform.position.x, player.transform.position.y };

        days = dayTimeController.days;
        calendarDay = dayTimeController.calendarDay;
        month = dayTimeController.month;

        money = moneyManager.money;

        for (int i = 0; i < inventory.slots.Count; i++)
        {
            this.itemID[i] = inventory.slots[i].ID;
            this.itemCount[i] = inventory.slots[i].count;
        }
        for (int i = 0; i < seedBag.slots.Count; i++)
        {
            seedID[i] = seedBag.slots[i].ID;
            seedCount[i] = seedBag.slots[i].count;
        }
        for (int i = 0; i < plantContainer.slots.Count; i++)
        {
            cropSlots[i] = plantContainer.slots[i];
        }
        for (int i = 0; i < treeContainer.slots.Count; i++)
        {
            treeCropSlots[i] = treeContainer.slots[i];
        }
    }
}
