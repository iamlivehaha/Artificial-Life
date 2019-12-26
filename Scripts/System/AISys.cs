using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class AISys : BaseSys
{
    public AISys(GameFacade facade) : base(facade) { }

    private GameObject AI;
    private AIMove move;
    private AIData aiData;
    private Message message;
    private EventTrigger eventTrigger;

    private Transform AISpawnPos;
    private GameObject AIPrefab;

    public AIData AiData
    {
        set { aiData = value; }
        get { return aiData; }
    }
    public override void OnInit()
    {
        AIPrefab = Resources.Load<GameObject>("Prefabs/AI");
        AISpawnPos = GameObject.Find("AISpawnPos").transform;
        AI = GameObject.Instantiate(AIPrefab, AISpawnPos.position, Quaternion.identity);
        AddAiScript();
    }

    public void AddAiScript()
    {
        move = AI.AddComponent<AIMove>();
        aiData = AI.AddComponent<AIData>();
        message = AI.AddComponent<Message>();
        eventTrigger = AI.AddComponent<EventTrigger>();
    }

    public void Move2Position(Transform destination)//移动到指定位置
    {
        move.OnAiMoveBegin(destination);
    }

    public void ShowDialogueBubble(string dialog)//显示对话气泡
    {
        message.OnReceivingMessage(dialog);
    }

    public void TriggerEvent(EventCode eventCode)//事件触发
    {
        eventTrigger.EventProcess(eventCode);
    }

    public void GameOver()
    {

    }
}
