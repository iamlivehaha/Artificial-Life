using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;

public class Bed : MonoBehaviour
{
    private FurnitureState bedState;
    private GameObject insleep;
    private AIData aiData;
    private SpriteRenderer aipic;
    void Start()
    {

    }

    void Update()
    {
        if (bedState == null)
        {
            bedState = GameFacade.instance.GetFurnitureData(FurnitureCode.Bed);
            insleep = bedState.furniturePrefab.transform.Find("insleep").gameObject;

        }
        if (aiData == null)
        {
            aiData = GameFacade.instance.GetAIData();
            aipic = aiData.AI.transform.Find("people").gameObject.GetComponent<SpriteRenderer>();
        }

    }

    public void Sleep()
    {
        insleep.SetActive(true);
        aipic.enabled=false;
    }

    public void WakeUp()
    {
        insleep.SetActive(false);
        aipic.enabled=true;
    }
}
