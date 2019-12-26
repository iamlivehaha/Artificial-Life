using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;

public class FurnitureSys : BaseSys {

    public FurnitureSys(GameFacade facade): base(facade){}
    private Dictionary<FurnitureCode, FurnitureState> furnitureStatesDict = new Dictionary<FurnitureCode, FurnitureState>();
    private FurnitureState furnitureState;
    private Transform furniturePos;
     
    public override void OnInit()
    {
        furniturePos = GameObject.Find("FurniturePos").transform;
        InitFurnitureStatesDict();
    }
    private void InitFurnitureStatesDict()
    {
        furnitureStatesDict.Add(FurnitureCode.PC, new FurnitureState(FurnitureCode.PC, null,"PC",false, furniturePos.Find("PCPos")));
        furnitureStatesDict.Add(FurnitureCode.Bed, new FurnitureState(FurnitureCode.Bed, null, "bed", false, furniturePos.Find("bedPos")));
        furnitureStatesDict.Add(FurnitureCode.Light1_bedroom, new FurnitureState(FurnitureCode.Light1_bedroom, null, "Light1_bedroom", false, furniturePos.Find("Light1_bedroomPos")));
        furnitureStatesDict.Add(FurnitureCode.Light2_bedroom, new FurnitureState(FurnitureCode.Light2_bedroom, null, "Light2_bedroom", false, furniturePos.Find("Light2_bedroomPos")));
        furnitureStatesDict.Add(FurnitureCode.WashingMachine, new FurnitureState(FurnitureCode.WashingMachine, null, "WashingMachine", false, furniturePos.Find("WashingMachinePos")));
        furnitureStatesDict.Add(FurnitureCode.WaterHeater, new FurnitureState(FurnitureCode.WaterHeater, null, "WaterHeater", false, furniturePos.Find("WaterHeaterPos")));
        furnitureStatesDict.Add(FurnitureCode.Bathtub, new FurnitureState(FurnitureCode.Bathtub, null, "Bathtub", false, furniturePos.Find("BathtubPos")));
        furnitureStatesDict.Add(FurnitureCode.CloseStool, new FurnitureState(FurnitureCode.CloseStool, null, "CloseStool", false, furniturePos.Find("CloseStoolPos")));
        furnitureStatesDict.Add(FurnitureCode.Cleaner, new FurnitureState(FurnitureCode.Cleaner, null, "cleaner", false, furniturePos.Find("cleanerPos")));
        furnitureStatesDict.Add(FurnitureCode.WaterBottle, new FurnitureState(FurnitureCode.WaterBottle, null, "waterbottle", false, furniturePos.Find("waterbottlePos")));
        furnitureStatesDict.Add(FurnitureCode.TV, new FurnitureState(FurnitureCode.TV, null, "TV", false, furniturePos.Find("TVPos")));
        furnitureStatesDict.Add(FurnitureCode.Fridge, new FurnitureState(FurnitureCode.Fridge, null, "fridge", false, furniturePos.Find("fridgePos")));
        furnitureStatesDict.Add(FurnitureCode.FoodMachine, new FurnitureState(FurnitureCode.FoodMachine, null, "foodmachine", false, furniturePos.Find("foodmachinePos")));
        

        foreach (FurnitureState fs in furnitureStatesDict.Values)//找到物体
        {
            fs.furniturePrefab = GameObject.Find(fs.furnitureName);

        }
    }

    public FurnitureState GetFurnitureState(FurnitureCode furnitureCode)
    {
        FurnitureState fs = null;
        furnitureStatesDict.TryGetValue(furnitureCode,out fs);
        return fs;
    }

}
