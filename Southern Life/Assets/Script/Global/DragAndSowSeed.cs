using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndSowSeed : MonoBehaviour
{
    public SeedSlot seedSlot;
    [SerializeField] GameObject seedIcon;
    [SerializeField] Text countText;
    RectTransform iconTransform;
    Image seedIconImage;

    private void Start()
    {
        seedSlot = new SeedSlot();
        iconTransform = seedIcon.GetComponent<RectTransform>();
        seedIconImage = seedIcon.GetComponent<Image>();
    }

    private void Update()
    {
        countText.text = seedSlot.count.ToString();
        if (seedIcon.activeInHierarchy == true)
        {
            iconTransform.position = Input.mousePosition;

            if (seedSlot.count == 0)
            {
                seedSlot.plant = null;
                UpdateIcon();
            }
        }
    }

    internal void OnClick(SeedSlot seedSlot)
    {
        if (this.seedSlot.plant == null)
        {
            this.seedSlot.Copy(seedSlot);
            seedSlot.Clear();
        }
        else
        {
            Plant plant = seedSlot.plant;
            int count = seedSlot.count;
            if (this.seedSlot.plant == plant)
            {
                this.seedSlot.Set(seedSlot.ID , plant, count + this.seedSlot.count);
                seedSlot.plant = null;
            }
            else
            {
                seedSlot.Copy(this.seedSlot);
                this.seedSlot.Set(seedSlot.ID, plant, count);
            }
        }
        UpdateIcon();
    }

    private void UpdateIcon()
    {
        if (seedSlot.plant == null)
        {
            seedIcon.SetActive(false);
        }
        else
        {
            seedIcon.SetActive(true);
            seedIconImage.sprite = seedSlot.plant.icon;
            countText.text = seedSlot.count.ToString();
        }
    }
}
