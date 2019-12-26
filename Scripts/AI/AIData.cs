using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class AIData : MonoBehaviour
{

    public int Believablity = 50;
    public int Favorability = 20;
    public EventCode currentEventCode = EventCode.None;
    public int FavoriteTemperate;
    public GameObject AI;
    public SpriteRenderer aipic;

    void Start()
    {
        AI = this.gameObject;
        aipic = transform.Find("people").gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        GoldFinger();
    }

    public EventCode CurrentEventCode//正在进行的事件
    {
        set { currentEventCode = value; }
        get { return currentEventCode; }
    }

    public void ChangeAIData(int change1, int change2)//Believablity  Favorability
    {
        Believablity += change1;
        Favorability += change2;
    }

    public void GoldFinger()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log(Believablity + "   " + Favorability);
        }
    }
}
