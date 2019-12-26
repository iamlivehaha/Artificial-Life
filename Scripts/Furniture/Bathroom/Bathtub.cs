using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class Bathtub : MonoBehaviour {

    private FurnitureState bathtub;
    private GameObject rim;
    private Animator animator;
    private GameObject inusing;
    private AIData aiData;
    private SpriteRenderer aipic;
    void Start()
    {

    }

    void Update()
    {
        if (bathtub == null)
        {
            bathtub = GameFacade.instance.GetFurnitureData(FurnitureCode.Bathtub);
 
            rim = bathtub.furniturePrefab.transform.Find("Rim").gameObject;
            rim.SetActive(false);

            animator = bathtub.furniturePrefab.GetComponent<Animator>();
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
                if (c.name == "Bathtub")
                {
                    ChangeStateButtom();
                }
            }
        }
    }
    public void ChangeStateButtom()
    {
        if (bathtub.workState)
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

        animator.SetBool("using",workstate);
        bathtub.workState = workstate;

    }

    public void InShower()
    {
        inusing.SetActive(true);
        aipic.enabled = false;
    }

    public void OffShower()
    {
        inusing.SetActive(false);
        ChangeState(false);
        aipic.enabled = true;
    }
}
