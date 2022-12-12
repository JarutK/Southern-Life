using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    public ItemContainer inventory;
    public List<SlotButton> buttons;
    void Start()
    {
        SetIndex();
        Show();
    }

    private void OnEnable()
    {
        Show();
    }

    private void SetIndex()
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            buttons[i].SetIndex(i);
        }
    }

    public void Show()
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            if (inventory.slots[i].item == null || inventory.slots[i].count == 0)
            {
                buttons[i].Clean();
                inventory.slots[i].Clear();
            }
            else
            {
                buttons[i].Set(inventory.slots[i]);
            }
        }

    }
}
