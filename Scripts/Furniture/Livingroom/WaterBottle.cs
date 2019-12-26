using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;

public class WaterBottle : MonoBehaviour {

    private FurnitureState waterbottleState;
    private GameObject idle;
    private GameObject working;
    private GameObject rim;
    void Start()
    {

    }

    void Update()
    {
        if (waterbottleState == null)
        {
            waterbottleState = GameFacade.instance.GetFurnitureData(FurnitureCode.WaterBottle);
            idle = waterbottleState.furniturePrefab.transform.Find("waterheater_idle").gameObject;
            idle.SetActive(false);
            working = waterbottleState.furniturePrefab.transform.Find("waterheater_on").gameObject;
            working.SetActive(false);
            rim = waterbottleState.furniturePrefab.transform.Find("Rim").gameObject;
            rim.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            CheckClickDown();
        }
    }
    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        rim.SetActive(true);
    }
    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        rim.SetActive(false);
    }
    public void CheckClickDown()
    {
        Collider2D[] col = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (col.Length > 0)
        {
            foreach (Collider2D c in col)
            {
                if (c.name == "waterbottle")
                {
                    ChangeStateButtom();
                }
            }
        }
    }
    public void ChangeStateButtom()
    {
        if (waterbottleState.workState)
        {
            working.SetActive(false);
            idle.SetActive(true);
            waterbottleState.workState = false;
        }
        else
        {
            working.SetActive(true);
            idle.SetActive(false);
            waterbottleState.workState = true;
        }
    }
}
