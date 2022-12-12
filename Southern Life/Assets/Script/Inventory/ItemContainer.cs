using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class ItemSlot
{
    public int ID;
    public Item item;
    public int count;

    public void Copy(ItemSlot slot)
    {
        ID = slot.ID;
        item = slot.item;
        count = slot.count;
    }

    public void Set(Item item, int count)
    {
        this.item = item;
        this.count = count;
    }

    public void Clear()
    {
        ID = 5;
        item = null;
        count = 0;
    }
}

[CreateAssetMenu(menuName = "Data/Item Container")]
public class ItemContainer : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemDatabase database;
    public List<ItemSlot> slots;

    public void Add(Item item, int count = 1)
    {
        ItemSlot itemSlot = slots.Find(x => x.item == item);
        if (itemSlot != null)
        {
            itemSlot.count += count;
        }
        else
        {
            itemSlot = slots.Find(x => x.item == null);
            if (itemSlot != null)
            {
                itemSlot.item = item;
                itemSlot.count = count;
            }
        }
    }

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].ID != 5)
            {
                slots[i].item = database.GetItem[slots[i].ID];
            }
            else if (slots[i].item != null)
            {
                slots[i].ID = database.GetId[slots[i].item];
            }
        }
    }

    public void OnBeforeSerialize()
    {
    }
}
