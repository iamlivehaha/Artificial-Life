using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class GameFacade : MonoBehaviour
{
    private static GameFacade _instance; //唯一单例

    public static GameFacade instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("GameFacade").GetComponent<GameFacade>();
            }
            return _instance;
        }
    }

    private AudioSys audioSys;
    private CameraSys cameraSys;
    private AISys aiSys;
    private FurnitureSys furnitureSys;
    private PcSys pcSys;
    private TimeSys timeSys;
    private UISys uiSys;

    private bool isEnterPlaying = false;
    // Use this for initialization
    //private void Awake()
    //{
    //    if (_instance!=null)
    //    {
    //        Destroy(this.gameObject);return;
    //    }
    //    _instance = this;
    //}
    void Start()
    {
        InitManager();

    }

    // Update is called once per frame
    void Update()
    {
        UpdataManager();
        if (isEnterPlaying)
        {
            //EnterPlaying();开始游戏
            isEnterPlaying = false;
        }
    }

    private void OnDestroy()
    {
        DestroyManager();
    }

    private void InitManager()
    {
        audioSys=new AudioSys(this);
        cameraSys=new CameraSys(this);
        aiSys=new AISys(this);
        furnitureSys=new FurnitureSys(this);
        pcSys=new PcSys(this);
        timeSys=new TimeSys(this);
        uiSys=new UISys(this);
        audioSys.OnInit();
        cameraSys.OnInit();
        aiSys.OnInit();
        furnitureSys.OnInit();
        pcSys.OnInit();
        timeSys.OnInit();
        uiSys.OnInit();
    }

    private void DestroyManager()
    {
        audioSys.OnDestroy();
        cameraSys.OnDestroy();
        aiSys.OnDestroy();
        furnitureSys.OnDestroy();
        pcSys.OnDestroy();
        timeSys.OnDestroy();
        uiSys.OnDestroy();
    }

    private void UpdataManager()
    {
        audioSys.Update();
        cameraSys.Update();
        aiSys.Update();
        furnitureSys.Update();
        pcSys.Update();
        timeSys.Update();
        uiSys.Update();
    }

    public void TimeCheckEvent(EventCode eventCode)//时间系统触发人物行为
    {
        aiSys.TriggerEvent(eventCode);
    }

    public FurnitureState GetFurnitureData(FurnitureCode furnitureCode)//检查家具数据
    {
        return furnitureSys.GetFurnitureState(furnitureCode);
    }

    public AIData GetAIData()//获取AIData
    {
        return aiSys.AiData;
    }

    public void MoveToPosition(Transform destination)//移动AI
    {
        aiSys.Move2Position(destination);
    }

    public void ShowMessage(string message)//显示人物对话气泡
    {
        aiSys.ShowDialogueBubble(message);
    }
    public void StopGame()
    {
        timeSys.StopGame();
    }

    public void StartGame()
    {
        timeSys.StartGame();
    }
}