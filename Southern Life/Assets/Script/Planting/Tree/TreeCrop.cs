using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCrop : MonoBehaviour, ISerializationCallbackReceiver
{
    public Sprite dirt;
    public Sprite ferDirt;
    public SpriteRenderer dirtSprite;

    public bool sowed = false;
    public bool fertilized = false;

    public SpriteRenderer plantSprite;

    private Transform playerPosition;

    DragAndSowSeed dragAndSowSeed;
    [SerializeField] PlantContainer treeContainer;

    public int dayCheck = 1;
    public int growTime;
    public int pickTime;
    public int pickCoolDown;
    public int pluckTime = 3;
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

    private void OnMouseDown()
    {
        if (Vector2.Distance(transform.position, playerPosition.position) <= 1.5)
        {
            if (ToolScript.currentTool == "Hoe")
            {
                dirtSprite.sprite = dirt;
            }

            if (dragAndSowSeed.seedSlot.plant != null && sowed == false && dragAndSowSeed.seedSlot.plant.tree == true)
            {
                if (dirtSprite.sprite == dirt || dirtSprite.sprite == ferDirt)
                {
                    cropPlant = dragAndSowSeed.seedSlot.plant;
                    pickTime = cropPlant.pickTime;
                    pickCoolDown = cropPlant.pickCoolDown;
                    plantSprite.sprite = cropPlant.state0;
                    sowed = true;
                    dragAndSowSeed.seedSlot.count -= 1;
                    OnAfterDeserialize();
                }
            }
            if (ToolScript.currentTool == "FertilizerBag" && dirtSprite.sprite == dirt)
            {
                dirtSprite.sprite = ferDirt;
                fertilized = true;
            }

            if (sowed == true)
            {
                if (stateCheck == 1 && ToolScript.currentTool == "None" && pluckTime > 0)
                {
                    Pluck();
                }
                else if (plantSprite.sprite == cropPlant.state3 && ToolScript.currentTool == "Scythe")
                {
                    if (pickTime > 0 && pickCoolDown < 1)
                    {
                        Harvest();
                        pickTime -= 1;
                        pickCoolDown = cropPlant.pickCoolDown;
                    }
                }
            }
        }
    }

    public void NextDay()
    {
        if (fertilized == true && cropPlant != null)
        {
            Growth();
        }
        if (plantSprite.sprite == null)
        {
            GroundReset();
        }
    }
    public void GroundReset()
    {
        treeContainer.slots[myIndex].TreeClear(this);
        id = 5;
        dirtSprite.sprite = null;
        plantSprite.sprite = null;
        stateCheck = 0;
        cropPlant = null;
        growTime = 0;
        fertilized = false;
        sowed = false;
        OnAfterDeserialize();
    }

    private void Growth()
    {
        growTime += 1;
        if (growTime == cropPlant.timeToGrow1 && stateCheck == 0)
        {
            plantSprite.sprite = cropPlant.state1;
            growTime = 0;
            stateCheck = 1;
        }
        else if(growTime == cropPlant.timeToGrow2 && stateCheck == 2 && pluckTime > 0)
        {
            plantSprite.sprite = cropPlant.state1;
            growTime = 0;
            stateCheck = 1;
        }
        else if (growTime == cropPlant.timeToGrow3 && stateCheck == 2 && pluckTime == 0)
        {
            plantSprite.sprite = cropPlant.state3;
            growTime = 0;
            stateCheck = 3;
            pickCoolDown = 0;
        }
        if (stateCheck == 3)
        {
            pickCoolDown -= 1;
        }
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

    private void Pluck()
    {
        pluckTime -= 1;
        plantSprite.sprite = cropPlant.state2;
        stateCheck = 2;
        growTime = 0;
    }

    private void StoreData()
    {
        treeContainer.slots[myIndex].TreeCopy(this);
    }

    public void LoadCrop()
    {
        id = 5;
        dirtSprite.sprite = null;
        plantSprite.sprite = null;
        stateCheck = 0;
        cropPlant = null;
        growTime = 0;
        fertilized = false;
        sowed = false;
        treeContainer.slots[myIndex].TreeSet(this);
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
            if (fertilized == true)
                dirtSprite.sprite = ferDirt;
            else
                dirtSprite.sprite = dirt;
        }
    }

    public void OnAfterDeserialize()
    {
        if (cropPlant != null)
        {
            id = database.GetId[cropPlant];
        }
        else if (treeContainer.slots[myIndex].ID != 5)
        {
            cropPlant = database.GetPlant[id];
        }
    }

    public void OnBeforeSerialize()
    {
    }
}
