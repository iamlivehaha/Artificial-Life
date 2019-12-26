using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSys {

    protected GameFacade facade;
    public BaseSys(GameFacade facade)
    {
        this.facade = facade;
    }
    public virtual void OnInit() { }
    public virtual void Update() { }
    public virtual void OnDestroy() { }
}
