using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class TimeCounter : MonoBehaviour {

    private int TimeTransformRate = 120;//120表示正常世界的一秒等于游戏世界的2分钟
    private int SavedTime = 0;
    private int LastTime = 0;
    private int delttime = 0;
    private bool IfStop;

    private struct TimeAndEvent
    {
        public string time;
        public EventCode eventcode;
    }
    private ArrayList EventSequence = new ArrayList();

    void InitEvents()
    {
        EventSequence.Add(MakeStruct("7:0:0", EventCode.WakeUp));
        EventSequence.Add(MakeStruct("7:4:0", EventCode.UsePC));
        EventSequence.Add(MakeStruct("7:16:0", EventCode.EatFood));
        EventSequence.Add(MakeStruct("7:36:0", EventCode.GoOut));

        EventSequence.Add(MakeStruct("23:0:0", EventCode.ComeBack));
        EventSequence.Add(MakeStruct("23:4:0", EventCode.UsePC));
        EventSequence.Add(MakeStruct("23:12:0", EventCode.Shower));
        EventSequence.Add(MakeStruct("23:28:0", EventCode.EatFood));
        EventSequence.Add(MakeStruct("23:42:0", EventCode.UsePC));
        EventSequence.Add(MakeStruct("0:4:0", EventCode.Sleep));
    }

    TimeAndEvent MakeStruct(string time, EventCode eventcode)
    {
        TimeAndEvent temp;
        temp.time = time;
        temp.eventcode = eventcode;
        return temp;
    }

	// Use this for initialization
	void Start () {
        //如果有存档功能和时间跳过，那么这里的SavedTime会被赋值
        InitEvents();//此函数负责初始化AI事件表
        IfStop = false;
        SavedTime = 208;//这里表示时间从 6:50开始
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void FixedUpdate()
    {
        if (!IfStop)
        {
            int TempTime = SavedTime +delttime++ ;
            if (LastTime != TempTime)
            {
                ScheduleCheck();
                LastTime = TempTime;
            }
        }

    }

    string RealTimeToGameTime()
    {
        string TimeString;
        int temp = LastTime * TimeTransformRate;
        TimeString = (temp/(60*60))%24 + ":" + (temp/60)% 60 + ":" + temp % 60;
        return TimeString;
    }

    void ScheduleCheck()
    {
        Debug.Log(RealTimeToGameTime());
        if (IfStop)
            return;
        TimeAndEvent temp = new TimeAndEvent();
        temp = (TimeAndEvent)EventSequence[0];
        if (RealTimeToGameTime() == temp.time)
        {
            //Debug.Log(RealTimeToGameTime()+"：check");
            GameFacade.instance.TimeCheckEvent(temp.eventcode);
            EventSequence.RemoveAt(0);
            EventSequence.Add(temp);
        }
        if(RealTimeToGameTime() == "7:46:0")
        {
            SavedTime = SavedTime + (82800 - 27960 - 600)/120;//时间跳到晚上22:50
        }
    }

    public void GamePause()
    {
        IfStop = true;
        Debug.Log("GamePause");
    }
    public void GameConsume()
    {
        IfStop = false;
        Debug.Log("GameContinue");
    }
}
