using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class CropSlot
{
    public int ID = 5;
    public int stateCheck = 0;
    public bool sowed = false;
    public bool watered = false;
    public bool fertilized = false;
    public int dayCheck = 1;
    public int growCheck = 0;
    public int growTime = 0;
    public int pickTime = 0;
    public int pickCoolDown = 0;
    public int pluckTime = 3;

    public void CropCopy(Crop crop)
    {
        ID = crop.id;
        stateCheck = crop.stateCheck;
        sowed = crop.sowed;
        watered = crop.watered;
        dayCheck = crop.dayCheck;
        growCheck = crop.growCheck;
        growTime = crop.growTime;
        pickTime = crop.pickTime;
        pickCoolDown = crop.pickCoolDown;
    }
    
    public void TreeCopy(TreeCrop treeCrop)
    {
        ID = treeCrop.id;
        stateCheck = treeCrop.stateCheck;
        sowed = treeCrop.sowed;
        fertilized = treeCrop.fertilized;
        dayCheck = treeCrop.dayCheck;
        growTime = treeCrop.growTime;
        pickTime = treeCrop.pickTime;
        pickCoolDown = treeCrop.pickCoolDown;
        pluckTime = treeCrop.pluckTime;
    }

    public void CropSet(Crop crop)
    {
        crop.id = ID;
        crop.stateCheck = stateCheck;
        crop.sowed = sowed;
        crop.watered = watered;
        crop.dayCheck = dayCheck;
        crop.growCheck = growCheck;
        crop.growTime = growTime;
        crop.pickTime = pickTime;
        crop.pickCoolDown = pickCoolDown;
    }

    public void TreeSet(TreeCrop treeCrop)
    {
        treeCrop.id = ID;
        treeCrop.stateCheck = stateCheck;
        treeCrop.sowed = sowed;
        treeCrop.fertilized = fertilized;
        treeCrop.dayCheck = dayCheck;
        treeCrop.growTime = growTime;
        treeCrop.pickTime = pickTime;
        treeCrop.pickCoolDown = pickCoolDown;
        treeCrop.pluckTime = pluckTime;
    }

    public void CropClear(Crop crop)
    {
        ID = 5;
        stateCheck = 0;
        sowed = false;
        watered = false;
        dayCheck = 1;
        growCheck = 0;
        growTime = 0;
        pickTime = 0;
        pickCoolDown = 0;
    }
    public void TreeClear(TreeCrop treeCrop)
    {
        ID = 5;
        stateCheck = 0;
        sowed = false;
        fertilized = false;
        dayCheck = 1;
        growTime = 0;
        pickTime = 0;
        pickCoolDown = 0;
        pluckTime = 3;
    }

    public void AllCropClear()
    {
        ID = 5;
        stateCheck = 0;
        growTime = 0;
        growCheck = 0;
        watered = false;
        fertilized = false;
        sowed = false;
        dayCheck = 1;
        growCheck = 0;
        growTime = 0;
        pickTime = 0;
        pickCoolDown = 0;
        pluckTime = 3;
    }
}

[CreateAssetMenu(menuName = "Data/Plant Container")]
public class PlantContainer : ScriptableObject
{
    public PlantDatabase database;
    public List<CropSlot> slots;
}
