using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class PC : MonoBehaviour
{
    private FurnitureState pc = null;
    public GameObject PcCanvas;
    private GameObject inusing;
    private GameObject rim;
    private AIData aiData;
    private SpriteRenderer aipic;
    void Start()
    {

    }

    void Update()
    {
        if (pc == null)
        {
            pc = GameFacade.instance.GetFurnitureData(FurnitureCode.PC);
            rim = pc.furniturePrefab.transform.Find("Rim").gameObject;
            rim.SetActive(false);
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
                if (c.gameObject.name == "PC")
                {
                    ChangeState();
                }
            }
        }
    }
    public void ChangeState()
    {
        if (pc.workState)//turn off
        {
            PcCanvas.SetActive(false);
            pc.workState = false;
            GameFacade.instance.StartGame();
        }
        else
        {
            PcCanvas.SetActive(true);
            pc.workState = true;
            GameFacade.instance.StopGame();
        }

    }

    public void UsePc()
    {
        inusing.SetActive(true);
        aipic.enabled = false;
    }

    public void ClosePc()
    {
        inusing.SetActive(false);
        aipic.enabled = true;
    }
}
