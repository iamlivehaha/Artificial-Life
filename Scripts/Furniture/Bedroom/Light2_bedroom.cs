using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class Light2_bedroom : MonoBehaviour {

    private FurnitureState light2;
    private GameObject light_on;
    private GameObject rim;
    void Start()
    {

    }

    void Update()
    {
        if (light2 == null)
        {
            light2 = GameFacade.instance.GetFurnitureData(FurnitureCode.Light2_bedroom);
            light_on = light2.furniturePrefab.transform.Find("Light2_On").gameObject;
            light_on.SetActive(false);
            rim = light2.furniturePrefab.transform.Find("Rim").gameObject;
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
                if (c.name == "Light2_bedroom")
                {
                    ChangeStateButtom();
                }
            }
        }
    }
    public void ChangeStateButtom()
    {
        if (light2.workState)
        {
            ChangeState(false);
        }
        else
        {
            ChangeState(true);
        }
    }
    public void ChangeState(bool workstate)
    {

        light_on.SetActive(workstate);
        light2.workState = workstate;

    }
}
