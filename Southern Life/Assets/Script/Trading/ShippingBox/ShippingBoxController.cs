﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShippingBoxController : MonoBehaviour
{
    [SerializeField] GameObject shippingBoxPanel;
    [SerializeField] ShippingBoxManager shippingBoxManager;

    GameObject player;
    Transform playerPosition;
    GameObject inventory;
    GameObject quitSlot;
    GameObject seedBagPanel;
    PlayerController playerController;
    float distance;

    void Start()
    {
        player = GameManager.instance.player;
        playerPosition = player.transform;
        playerController = player.GetComponent<PlayerController>();

        inventory = GameManager.instance.inventoryPanel;
        quitSlot = GameManager.instance.quickSlotUI;
        seedBagPanel = GameManager.instance.seedBagPanel;
    }

    private void OnMouseDown()
    {
        distance = Vector2.Distance(transform.position, playerPosition.position);
        if (distance <= 1.5)
        {
            if (shippingBoxPanel.activeInHierarchy == false)
            {
                if (inventory.activeInHierarchy == false)
                {
                    shippingBoxPanel.SetActive(!shippingBoxPanel.activeInHierarchy);
                    quitSlot.SetActive(false);
                    playerController.enabled = false;
                    playerController.rigidbody2d.velocity = Vector2.zero;
                    seedBagPanel.SetActive(false);
                }
            }
        }
    }

    public void Sell()
    {
        shippingBoxManager.Sell();
    }

    public void Close()
    {
        shippingBoxManager.DrawBack();
        shippingBoxPanel.SetActive(!shippingBoxPanel.activeInHierarchy);
        quitSlot.SetActive(true);
        playerController.enabled = true;
    }
}
