using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcSys : BaseSys {

    public PcSys(GameFacade facade) : base(facade) { }

    private GameObject PcCanvas;

    public override void OnInit()
    {
        PcCanvas =GameObject.Find("/PcCanvas");
        PcCanvas.SetActive(false);
        AddScripts();
    }

    private void AddScripts()
    {
        PcCanvas.AddComponent<PCManager>();
        PcCanvas.AddComponent<Dialog>();
    }
}
