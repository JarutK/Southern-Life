using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class SeedSlot
{
    public int ID;
    public Plant plant;
    public int count;

    public void Copy(SeedSlot slot)
    {
        ID = slot.ID;
        plant = slot.plant;
        count = slot.count;
    }

    public void Set(int id, Plant plant, int count)
    {
        this.ID = id;
        this.plant = plant;
        this.count = count;
    }

    public void Clear()
    {
        ID = 5;
        plant = null;
        count = 0;
    }
}

[CreateAssetMenu(menuName = "Data/Seed Container")]
public class SeedContainer : ScriptableObject, ISerializationCallbackReceiver
{
    public PlantDatabase database;
    public List<SeedSlot> slots;

    public void Add(Plant plant, int count = 1)
    {
        SeedSlot seedSlot = slots.Find(x => x.plant == plant);
        if (seedSlot != null)
        {
            seedSlot.count += count;
        }
        else
        {
            seedSlot = slots.Find(x => x.plant == null);
            if (seedSlot != null)
            {
                seedSlot.plant = plant;
                seedSlot.count = count;
            }
        }
    }

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].ID != 5)
                slots[i].plant = database.GetPlant[slots[i].ID];
            else if (slots[i].plant != null)
                slots[i].ID = database.GetId[slots[i].plant];
        }
    }

    public void OnBeforeSerialize()
    {
    }
}
