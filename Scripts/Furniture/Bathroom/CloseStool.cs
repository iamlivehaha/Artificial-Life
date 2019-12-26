using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class CloseStool : MonoBehaviour {

    private FurnitureState closestool;
    private GameObject rim;
    private Animator animator;
    void Start()
    {

    }

    void Update()
    {
        if (closestool == null)
        {
            closestool = GameFacade.instance.GetFurnitureData(FurnitureCode.CloseStool);

            rim = closestool.furniturePrefab.transform.Find("Rim").gameObject;
            rim.SetActive(false);

            animator = closestool.furniturePrefab.GetComponent<Animator>();
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
                if (c.name == "CloseStool")
                {
                    ChangeStateButtom();
                }
            }
        }
    }
    public void ChangeStateButtom()
    {
        if (closestool.workState)
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

        animator.SetBool("openning", workstate);
        closestool.workState = workstate;

    }
}
