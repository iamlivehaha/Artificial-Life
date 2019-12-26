using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using UnityEngine.UI;

public class WaterHeater : MonoBehaviour {

    private FurnitureState waterheater;
    private GameObject rim;
    private GameObject canvas;
    private Text temeratureText;
    private Button upButton;
    private Button downButton;
    private int temp = 38;
    void Start()
    {

    }

    void Update()
    {
        if (waterheater == null)
        {
            waterheater = GameFacade.instance.GetFurnitureData(FurnitureCode.WaterHeater);
            canvas = waterheater.furniturePrefab.transform.Find("TemperCanvas").gameObject;
            temeratureText = canvas.transform.Find("Temperature").gameObject.GetComponent<Text>();
            upButton = canvas.transform.Find("UpButton").gameObject.GetComponent<Button>();
            downButton = canvas.transform.Find("DownButton").gameObject.GetComponent<Button>();
            upButton.onClick.AddListener(UpTemp);
            downButton.onClick.AddListener(DownTemp);
            rim = waterheater.furniturePrefab.transform.Find("Rim").gameObject;
            rim.SetActive(false);
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

    public void UpTemp()
    {
        temp = int.Parse(temeratureText.text);
        temp++;
        temeratureText.text = temp.ToString();
    }

    public void DownTemp()
    {
        temp = int.Parse(temeratureText.text);
        temp--;
        temeratureText.text = temp.ToString();
    }
}
