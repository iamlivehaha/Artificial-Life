using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;


public class Dialog : MonoBehaviour {

    private PCManager pcManager;
    private FurnitureState pcState;
    private float delttime = 1.5f;
    // Use this for initialization
    private struct DialogEvent
    {
        public string log;
        public Mood mood;
    }
    private ArrayList EventSequence = new ArrayList();

    void InitEvents()
    {
        EventSequence.Add(MakeStruct("Good morning, AI, prepare breakfast for me", Mood.None));
        EventSequence.Add(MakeStruct(" Copy that, but why you are in such a hurry, Mr.smith?", Mood.None));
        EventSequence.Add(MakeStruct("My friend... no, my colleague Julia seemed tired and sick yesterday", Mood.None));
        EventSequence.Add(MakeStruct(" I think may be she can have a rest if I finish some work for her", Mood.None));

        EventSequence.Add(MakeStruct("So I need to go to the company earlier", Mood.None));
        EventSequence.Add(MakeStruct("Up - You are so kind, my master ! I will prepare a meal for you as fast as I can", Mood.None));
        EventSequence.Add(MakeStruct("Down - I don't get it why you do this, but I will do what you told me", Mood.None));
        EventSequence.Add(MakeStruct("What's wrong? It's quite rare for you to come back at this time~", Mood.None));
        EventSequence.Add(MakeStruct(" Please leave me alone", Mood.None));
        EventSequence.Add(MakeStruct(" I want to have a bath and have a meal. Get it ready", Mood.None));
    }
    DialogEvent MakeStruct(string log, Mood mood)
    {
        DialogEvent temp;
        temp.log = log;
        temp.mood = mood;
        return temp;
    }

    void Start () {
        pcManager = GameObject.Find("/PcCanvas").GetComponent<PCManager>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (pcState == null)
	    {
	        pcState = GameFacade.instance.GetFurnitureData(FurnitureCode.PC);
	    }
	    if (pcState.workState)
	    {
	        
	    }	
	}

    public void ShowDialog()
    {
        
    }
}
