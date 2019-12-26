using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum Mood
{
    Happy, Sad, Like, DisLike,None
}

public class PCManager : MonoBehaviour
{
    private const string PREFIX_PREFAB = "Prefabs/";


    //private GameObject pcCanvas;
    public RectTransform playerContent;
    private GameObject AIlog;
    private GameObject Playerlog;
    private GameObject Happy;
    private GameObject Sad;
    private GameObject Like;
    private GameObject DisLike;

    void Start()
    {
        //pcCanvas = GameObject.Find("PcCanvas");

        //Debug.Log(playerContent);
        AIlog = Resources.Load<GameObject>("Prefabs/AILog");
        Playerlog = Resources.Load<GameObject>("Prefabs/PlayerLog");
        Happy = Resources.Load<GameObject>(PREFIX_PREFAB + "Feeling_Happy");
        Like = Resources.Load<GameObject>(PREFIX_PREFAB + "Feeling_Like");
        DisLike = Resources.Load<GameObject>(PREFIX_PREFAB + "Feeling_DisLike");
        Sad = Resources.Load<GameObject>(PREFIX_PREFAB + "Feeling_Sad");
    }

    public void AddAILog(string message,Mood mood)
    {
        GameObject ai = Instantiate(AIlog,playerContent);
        Text aiText = ai.transform.Find("AI_Log").gameObject.GetComponent<Text>();
        aiText.text = message;
        switch (mood)
        {
                case Mood.None:
                break;
                case Mood.Happy:
                ChangeMood(Happy,ai);
                break;
                case Mood.DisLike:
                ChangeMood(DisLike, ai);
                break;
                case Mood.Like:
                ChangeMood(Like, ai);
                break;
                case Mood.Sad:
                ChangeMood(Sad, ai);
                break;
        }
    }
    public void AddPlayerLog(string message)
    {
        GameObject player = Instantiate(Playerlog, playerContent);
        Text playerText = player.transform.Find("Player_Log").gameObject.GetComponent<Text>();
        playerText.text = message;
    }

    public void ChangeMood(GameObject mood,GameObject content )
    {
        Transform pos = content.transform.Find("AI_Head");
        Instantiate(mood, pos);
    }
}
