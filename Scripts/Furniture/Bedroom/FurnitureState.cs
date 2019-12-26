using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;

public class FurnitureState  {

    private const string PREFIX_PREFAB = "Prefabs/";

    public FurnitureCode furnitureCode { get; private set; }
    public GameObject furniturePrefab { get;  set; }
    public string furnitureName { get; set; }
    public Transform interactPos { get;  set; }
    public bool workState { get;  set; }

    public FurnitureState(FurnitureCode furnitureCode, GameObject furniture,string name,bool workstate,Transform interactPos)
    {
        this.furnitureCode = furnitureCode;
        this.furniturePrefab = furniture;
        this.furnitureName = name;
        this.workState = workstate;
        this.interactPos = interactPos;
    }
}
