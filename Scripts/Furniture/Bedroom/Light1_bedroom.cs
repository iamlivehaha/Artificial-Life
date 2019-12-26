using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class Light1_bedroom : MonoBehaviour
{

    private FurnitureState light1;
    private GameObject light_on;
    private GameObject rim;

    void Start()
    {

    }

    void Update()
    {
        if (light1 == null)
        {
            light1 = GameFacade.instance.GetFurnitureData(FurnitureCode.Light1_bedroom);
            light_on = light1.furniturePrefab.transform.Find("Light1_On").gameObject;
            light_on.SetActive(false);
            rim = light1.furniturePrefab.transform.Find("Rim").gameObject;
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
                if (c.gameObject.tag== "Light1")
                {
                    ChangeStateButton();
                }
            }
        }
    }

    public void ChangeStateButton()
    {
        if (light1.workState)
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
            light1.workState = workstate;

    }
}
