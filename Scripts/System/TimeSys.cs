using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSys : BaseSys {

    public TimeSys(GameFacade facade) : base(facade) { }

    private TimeCounter timeCounter;
    private GameObject gamefacade;

    public override void OnInit()
    {
        gamefacade = facade.gameObject;
        AddScripts();
    }

    private void AddScripts()
    {
        timeCounter = gamefacade.AddComponent<TimeCounter>();
    }

    public void StopGame()
    {
        timeCounter.GamePause();
    }
    public void StartGame()
    {
        timeCounter.GameConsume();
    }
}
