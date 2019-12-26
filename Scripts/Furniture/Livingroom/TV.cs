using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;

public class TV : MonoBehaviour {


    private FurnitureState tvState;
    private GameObject opening;
    private GameObject rim;
    void Start()
    {

    }

    void Update()
    {
        if (tvState == null)
        {
            tvState = GameFacade.instance.GetFurnitureData(FurnitureCode.TV);
            opening = tvState.furniturePrefab.transform.Find("openning").gameObject;
            opening.SetActive(false);
            rim = tvState.furniturePrefab.transform.Find("Rim").gameObject;
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
                if (c.name == "TV")
                {
                    ChangeStateButtom();
                }
            }
        }
    }
    public void ChangeStateButtom()
    {
        if (tvState.workState)
        {
            opening.SetActive(false);
            tvState.workState = false;
        }
        else
        {
            opening.SetActive(true);
            tvState.workState = true;
        }
    }
}
