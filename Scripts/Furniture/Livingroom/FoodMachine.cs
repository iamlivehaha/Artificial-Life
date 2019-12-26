using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;

public class FoodMachine : MonoBehaviour {

    private FurnitureState foodmachineState;
    private GameObject rim;
    private Animator animator;
    private AIData aiData;
    private SpriteRenderer aipic;
    private GameObject inusing;
    void Start()
    {

    }

    void Update()
    {
        if (foodmachineState == null)
        {
            foodmachineState = GameFacade.instance.GetFurnitureData(FurnitureCode.FoodMachine);

            rim = foodmachineState.furniturePrefab.transform.Find("Rim").gameObject;
            rim.SetActive(false);

            animator = foodmachineState.furniturePrefab.GetComponent<Animator>();
        }
        if (Input.GetMouseButtonDown(0))
        {
            CheckClickDown();
        }
        if (aiData == null)
        {
            inusing = this.transform.Find("people_using").gameObject;
            inusing.SetActive(false);
            aiData = GameFacade.instance.GetAIData();
            aipic = aiData.aipic;
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
                if (c.name == "foodmachine")
                {
                    ChangeStateButtom();
                }
            }
        }
    }
    public void ChangeStateButtom()
    {
        if (foodmachineState.workState)
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

        animator.SetBool("cooking", workstate);
        foodmachineState.workState = workstate;
    }

    public void EatFood()
    {
        inusing.SetActive(true);
        animator.SetBool("eating",true);
        aipic.enabled = false;
    }

    public void EatUp()
    {
        inusing.SetActive(false);
        animator.SetBool("eating", false);
        ChangeState(false);
        aipic.enabled = true;
    }
}
