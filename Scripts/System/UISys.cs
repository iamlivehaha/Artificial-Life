using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISys : BaseSys {

	public UISys(GameFacade facade):base(facade){}

    public void ShowMessage(string msg)
    {
        if (msg == null)
        {
            Debug.Log("无法显示提示信息，MsgPanel为空"); return;
        }
    }
}
