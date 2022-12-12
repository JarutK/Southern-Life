using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class SeedBagPanel : MonoBehaviour
{
    public SeedContainer seedBag;
    public List<SeedSlotButton> buttons;
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
        for (int i = 0; i < seedBag.slots.Count; i++)
        {
            buttons[i].SetIndex(i);
        }
    }

    public void Show()
    {
        for (int i = 0; i < seedBag.slots.Count; i++)
        {
            if (seedBag.slots[i].plant == null || seedBag.slots[i].count == 0)
            {
                buttons[i].Clean();
                seedBag.slots[i].Clear();
            }
            else
            {
                buttons[i].Set(seedBag.slots[i]);
            }
        }

    }
}
