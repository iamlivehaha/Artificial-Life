using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class EventTrigger : MonoBehaviour
{
    private Transform destination;
    private SpriteRenderer aipic;
    void Start()
    {
        destination = null;
        aipic = this.transform.Find("people").gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {

    }

    public void EventProcess(EventCode eventCode)//分类处理事件的触发
    {
        Debug.Log(eventCode);
        switch (eventCode)
        {
            case EventCode.None:
                //play anime_idle

                break;
            case EventCode.Sleep:
                StartCoroutine(Go2Sleep());
                break;
            case EventCode.WakeUp:
                StartCoroutine(WakeUp());
                break;
            case EventCode.UsePC:
                StartCoroutine(OpenPC());
                break;
            case EventCode.WC:
                StartCoroutine(OpenPC());
                break;
            case EventCode.ComeBack:
                StartCoroutine(ComeBack());
                break;
            case EventCode.GoOut:
                StartCoroutine(GoOut());
                break;
            case EventCode.Drink:
                StartCoroutine(OpenPC());
                break;
            case EventCode.EatFood:
                StartCoroutine(EatFood());
                break;
            case EventCode.Shower:
                StartCoroutine(Shower());
                break;
        }
        //        GameFacade.instance.ChangeAIData(2,10);// 改变AI的Believablity, Favorability   range[0,100]
        //        GameFacade.instance.GetFurnitureData(FurnitureCode.PC);//获取家具数据
    }

    IEnumerator OperationModule()//一个用来代表模板的函数，无意义切不会被调用
    {
        yield return new WaitForSeconds(3);
    }

    IEnumerator OpenPC()
    {
        FurnitureState pcState = GameFacade.instance.GetFurnitureData(FurnitureCode.PC);
        destination = pcState.interactPos;

        //1.move to worktable 
        GameFacade.instance.MoveToPosition(destination);
        while (true)
        {
            if (this.transform.position.x != destination.position.x || this.transform.position.y != destination.position.y)
            {
                yield return null;
            }
            else
                break;
        }
        pcState.furniturePrefab.GetComponent<PC>().UsePc();
        if (pcState.workState != true)
        {
            //GameFacade.instance.ShowMessage("Open it!");
            //GameFacade.instance.StopGame();
            /*
            while (true)//wait until work
            {
                if (pcState.workState == false)
                {
                    yield return null;
                }
                else
                {
                    break;
                }
            }
            */
        }
        else// 增加好感度（2,2）
        {
            GameFacade.instance.GetAIData().ChangeAIData(2, 2);
        }

        yield return new WaitForSeconds(4);
        pcState.furniturePrefab.GetComponent<PC>().ClosePc();
    }

    IEnumerator Go2Sleep()
    {
        FurnitureState bedState = GameFacade.instance.GetFurnitureData(FurnitureCode.Bed);
        destination = bedState.interactPos;
        //1.move to bed 
        GameFacade.instance.MoveToPosition(destination);
        while (true)
        {
            if (this.transform.position.x != destination.position.x || this.transform.position.y != destination.position.y)
            {
                yield return null;
            }
            else
                break;
        }

        bedState.furniturePrefab.GetComponent<Bed>().Sleep();//触发睡觉图片切换
        //2.check wether the light is on                                                     
        FurnitureState lightState = GameFacade.instance.GetFurnitureData(FurnitureCode.Light1_bedroom);
        destination = lightState.interactPos;
        GameFacade.instance.MoveToPosition(destination);
        while (true)
        {
            if (this.transform.position.x != destination.position.x || this.transform.position.y != destination.position.y)
            {
                yield return null;
            }
            else
                break;
        }
        if (lightState.workState)
        {
            //change Light
            GameFacade.instance.ShowMessage("ah，the light is annoying!");
        }
        else// 增加好感度（2,2）
        {
            GameFacade.instance.GetAIData().ChangeAIData(2, 2);
        }
    }

    IEnumerator WakeUp()
    {
        FurnitureState fs1 = GameFacade.instance.GetFurnitureData(FurnitureCode.Bed);
        destination = fs1.interactPos;
        GameFacade.instance.MoveToPosition(destination);
        while (true)
        {
            if (this.transform.position.x != destination.position.x || this.transform.position.y != destination.position.y)
            {
                yield return null;
            }
            else
                break;
        }
        fs1.furniturePrefab.GetComponent<Bed>().WakeUp();
        yield return null;
    }

    IEnumerator EatFood()
    {
        FurnitureState foodmaineState = GameFacade.instance.GetFurnitureData(FurnitureCode.FoodMachine);
        destination = foodmaineState.interactPos;
        GameFacade.instance.MoveToPosition(destination);
        while (true)
        {
            if (this.transform.position.x != destination.position.x || this.transform.position.y != destination.position.y)
            {
                yield return null;
            }
            else
                break;
        }
        if (foodmaineState.workState != true)
        {
            GameFacade.instance.ShowMessage("Where is my food?!");
            GameFacade.instance.StopGame();
            while (true)//wait until work
            {
                if (foodmaineState.workState != true)
                {
                    yield return null;
                }
                else
                {
                    yield return new WaitForSeconds(3);//buff
                    break;
                }
            }
        }

        foodmaineState.furniturePrefab.GetComponent<FoodMachine>().EatFood();
        yield return new WaitForSeconds(4);//having food
        foodmaineState.furniturePrefab.GetComponent<FoodMachine>().EatUp();
        GameFacade.instance.StartGame();
    }

    IEnumerator Shower()
    {
        FurnitureState bathtubState = GameFacade.instance.GetFurnitureData(FurnitureCode.Bathtub);
        destination = bathtubState.interactPos;
        GameFacade.instance.MoveToPosition(destination);
        while (true)
        {
            if (this.transform.position.x != destination.position.x || this.transform.position.y != destination.position.y)
            {
                yield return null;
            }
            else
                break;
        }
        bathtubState.furniturePrefab.GetComponent<Bathtub>().InShower();
        //check the curtaina and water temperture
        FurnitureState waterheaterState = GameFacade.instance.GetFurnitureData(FurnitureCode.WaterHeater);
        destination = waterheaterState.interactPos;
        GameFacade.instance.MoveToPosition(destination);
        while (true)
        {
            if (this.transform.position.x != destination.position.x || this.transform.position.y != destination.position.y)
            {
                yield return null;
            }
            else
                break;
        }
        if (bathtubState.workState != true)
        {
            GameFacade.instance.ShowMessage("Colse it!");
            GameFacade.instance.StopGame();
            while (true)//wait until work
            {
                if (bathtubState.workState != true)
                {
                    yield return null;
                }
                else
                {
                    break;
                }
            }
            yield return new WaitForSeconds(3);//buff
        }

        destination = bathtubState.interactPos;
        GameFacade.instance.MoveToPosition(bathtubState.interactPos);
        while (true)
        {
            if (this.transform.position.x != destination.position.x || this.transform.position.y != destination.position.y)
            {
                yield return null;
            }
            else
                break;
        }
        yield return new WaitForSeconds(4);//buff
        bathtubState.furniturePrefab.GetComponent<Bathtub>().OffShower();
        GameFacade.instance.StartGame();
    }

    IEnumerator GoOut()
    {
        destination = GameObject.Find("/FurniturePos/doorPos").transform;
        GameFacade.instance.MoveToPosition(destination);
        while (true)
        {
            if (this.transform.position.x != destination.position.x || this.transform.position.y != destination.position.y)
            {
                yield return null;
            }
            else
                break;
        }
        aipic.enabled = false;
    }

    IEnumerator ComeBack()
    {
        destination = GameObject.Find("/FurniturePos/doorPos").transform;
        GameFacade.instance.MoveToPosition(destination);
        while (true)
        {
            if (this.transform.position.x != destination.position.x || this.transform.position.y != destination.position.y)
            {
                yield return null;
            }
            else
                break;
        }
        aipic.enabled = true;
    }
}
