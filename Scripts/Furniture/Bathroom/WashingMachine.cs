using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class WashingMachine : MonoBehaviour {

    private FurnitureState washingMachine;
    private GameObject work_on;
    private GameObject openning;
    private GameObject rim;
    void Start()
    {

    }

    void Update()
    {
        if (washingMachine == null)
        {
            washingMachine = GameFacade.instance.GetFurnitureData(FurnitureCode.WashingMachine);
            work_on = washingMachine.furniturePrefab.transform.Find("washingmachine_working").gameObject;
            work_on.SetActive(false);
            openning = washingMachine.furniturePrefab.transform.Find("washingmachine_openning").gameObject;
            openning.SetActive(false);
            rim = washingMachine.furniturePrefab.transform.Find("Rim").gameObject;
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
                if (c.name == "WashingMachine")
                {
                    ChangeStateButtom();
                }
            }
        }
    }
    public void ChangeStateButtom()
    {
        if (washingMachine.workState)
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

        work_on.SetActive(workstate);
        washingMachine.workState = workstate;

    }

    public void OpenMachine()
    {
        openning.SetActive(true);
    }

    public void CloseMachine()
    {
        openning.SetActive(false);
    }
}
