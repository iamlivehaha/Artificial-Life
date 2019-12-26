using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour {

    private GameObject Popup;
    private GameObject Bubble;
    Text OutputText;
	// Use this for initialization
	void Start () {
		Popup = GameObject.Find("/AI(Clone)/MessageCanvas/Popup气泡");
        Popup.SetActive(false);
        OutputText = Popup.GetComponent<Text>();
        Bubble = GameObject.Find("/AI(Clone)/MessageCanvas/Popup气泡/Dialog-square");
        //StartCoroutine(OnReceivingMessageReal("this is a test"));
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void OnReceivingMessage(string message)
    {
        StartCoroutine(OnReceivingMessageReal(message));
    }

    IEnumerator OnReceivingMessageReal(string message)
    {
        float SleepTime = 3f;
        Vector3 Scale = new Vector3((float)message.Length / (float)8.0, 1, 1);
        if(message != "")
        {
            Popup.SetActive(true);
            Bubble.transform.localScale = Scale;
            OutputText.text = message;
            yield return new WaitForSeconds(SleepTime);
            Popup.SetActive(false);
        }
    }
}
