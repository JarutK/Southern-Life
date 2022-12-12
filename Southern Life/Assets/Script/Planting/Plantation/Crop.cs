using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour, ISerializationCallbackReceiver
{
    public Sprite soil;
    public Sprite wetSoil;
    public SpriteRenderer dirtSprite;

    public bool sowed = false;
    public bool watered = false;

    public SpriteRenderer plantSprite;
    
    private Transform playerPosition;

    DragAndSowSeed dragAndSowSeed;
    [SerializeField] PlantContainer plantContainer;

    public int dayCheck = 1;
    public int growCheck;
    public int growTime;
    public int pickTime;
    public int pickCoolDown;
    public Plant cropPlant;
    public int id = 5;
    public int stateCheck = 0;
    [SerializeField] PlantDatabase database;
    int myIndex;

    private void Start()
    {
        dragAndSowSeed = GameManager.instance.GetComponent<DragAndSowSeed>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void SetIndex(int index)
    {
        myIndex = index;
    }

    private void Update()
    {
        int day = GameManager.instance.dayTimeController.days;
        if (dayCheck < day)
        {
            dayCheck = day;
            NextDay();
            StoreData();
        }
    }

    private void OnMouseDown() {
        if (Vector2.Distance(transform.position, playerPosition.position) <= 1.5)
        {
            if (ToolScript.currentTool == "Hoe")
            {
                dirtSprite.sprite = soil;
            }

            if (dragAndSowSeed.seedSlot.plant != null && sowed == false && dragAndSowSeed.seedSlot.plant.tree == false)
            {
                if (dirtSprite.sprite == soil || dirtSprite.sprite == wetSoil)
                {
                    cropPlant = dragAndSowSeed.seedSlot.plant;
                    pickTime = cropPlant.pickTime;
                    plantSprite.sprite = cropPlant.state0;
                    sowed = true;
                    dragAndSowSeed.seedSlot.count -= 1;
                    OnAfterDeserialize();
                }
            }
            if (ToolScript.currentTool == "WateringCan" && ToolScript.fillWaterCan > 0 && dirtSprite.sprite == soil)
            {
                dirtSprite.sprite = wetSoil;
                watered = true;
                ToolScript.fillWaterCan -= 1;
            }

            if(sowed == true)
            {
                if (plantSprite.sprite == cropPlant.state3 && ToolScript.currentTool == "Scythe" && cropPlant.pickable == false)
                {
                    Harvest();
                    GroundReset();
                }
                else if (plantSprite.sprite == cropPlant.state3 && ToolScript.currentTool == "None" && cropPlant.pickable == true)
                {
                    if (pickTime > 1)
                    {
                        plantSprite.sprite = cropPlant.state2;
                        stateCheck = 2;
                        Harvest();
                        pickTime -= 1;
                    }
                    else
                    {
                        Harvest();
                        GroundReset();
                    }
                }
            }
        }
    }

    public void NextDay()
    {
        growCheck += 1;
        if (watered == true && cropPlant != null)
        {
            Growth();
            dirtSprite.sprite = soil;
            watered = false;
        }

        if (plantSprite.sprite == null)
        {
            GroundReset();
        }
        if (growCheck > growTime + 1)
        {
            GroundReset();
        }
    }

    public void GroundReset()
    {
        plantContainer.slots[myIndex].CropClear(this);
        id = 5;
        dirtSprite.sprite = null;
        plantSprite.sprite = null;
        stateCheck = 0;
        cropPlant = null;
        growCheck = 0;
        growTime = 0;
        watered = false;
        sowed = false;
        OnAfterDeserialize();
    }

    private void Growth()
    {
        growTime += 1;
        if (growTime == cropPlant.timeToGrow1 && watered == true && stateCheck == 0)
        {
            plantSprite.sprite = cropPlant.state1;
            growTime = 0;
            growCheck = 0;
            stateCheck = 1;
        }

        else if (growTime == cropPlant.timeToGrow2 && watered == true && stateCheck == 1)
        {
            plantSprite.sprite = cropPlant.state2;
            growTime = 0;
            growCheck = 0;
            stateCheck = 2;
        }
        else if (growTime == cropPlant.timeToGrow3 && watered == true && stateCheck == 2)
        {
            plantSprite.sprite = cropPlant.state3;
            growTime = 0;
            growCheck = 0;
            stateCheck = 3;
        }
        growCheck = growTime;
    }
    private void Harvest()
    {
        float spread = 0.7f;
        int dropCount = cropPlant.dropCount;
        while (dropCount > 0)
        {
            dropCount -= 1;

            Vector3 position = transform.position;
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2;

            ItemSpawnManager.instance.SpawnItem(position, cropPlant.product, 1);
        }

    }

    private void StoreData()
    {
        plantContainer.slots[myIndex].CropCopy(this);
    }

    public void LoadCrop()
    {
        id = 5;
        dirtSprite.sprite = null;
        plantSprite.sprite = null;
        stateCheck = 0;
        cropPlant = null;
        growCheck = 0;
        growTime = 0;
        watered = false;
        sowed = false;
        plantContainer.slots[myIndex].CropSet(this);
        OnAfterDeserialize();
        CheckCrop();
    }

    public void CheckCrop()
    {
        if (id != 5)
        {
            switch (stateCheck)
            {
                case 0:
                    plantSprite.sprite = cropPlant.state0;
                    break;
                case 1:
                    plantSprite.sprite = cropPlant.state1;
                    break;
                case 2:
                    plantSprite.sprite = cropPlant.state2;
                    break;
                case 3:
                    plantSprite.sprite = cropPlant.state3;
                    break;
            }
            dirtSprite.sprite = soil;
        }
    }

    public void OnAfterDeserialize()
    {
        if (cropPlant != null)
        {
            id = database.GetId[cropPlant];
        }
        else if (plantContainer.slots[myIndex].ID != 5)
        {
            cropPlant = database.GetPlant[id];
        }
    }

    public void OnBeforeSerialize()
    {
    }
}