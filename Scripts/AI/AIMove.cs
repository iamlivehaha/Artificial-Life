using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove : MonoBehaviour
{

    public int WalkSpeed = 5;

    private bool Left;
    private bool MoveLock = true;
    private bool Transfer = false;
    private Vector3 LastDestination = new Vector3();
    private Animator aiAnimator;
    private GameObject Body;
    private Transform currenTransform = null;

    private Transform spot2bathroom;
    private Transform spot2livingroom;
    private Transform livingroom2spot;
    private Transform bathroom2spot;
    private Transform originSpot;
    private Transform endSpot;


    // Use this for initialization
    void Start()
    {
        aiAnimator = GameObject.FindGameObjectWithTag("AI").GetComponent<Animator>();
        Body = GameObject.Find("/AI(Clone)/people");
        spot2bathroom = GameObject.Find("/FurniturePos/spot2bathroom").transform;
        spot2livingroom = GameObject.Find("/FurniturePos/spot2livingroom").transform;
        livingroom2spot = GameObject.Find("/FurniturePos/livingroom2spot").transform;
        bathroom2spot = GameObject.Find("/FurniturePos/bathroom2spot").transform;
        Left = true;
    }

    private Vector3 Direction = new Vector3();
    private Vector3 Distance = new Vector3();
    private Vector3 TempScale = new Vector3();
    // Update is called once per frame

    void Update()
    {
        if (Transfer)
        {
            Transport(originSpot, endSpot);
        }
        if (!MoveLock && !Transfer)
        {
            MovePos();
        }

    }


    public void OnAiMoveBegin(Transform Destination)
    {
        aiAnimator.SetBool("IsMove", true);
        if (currenTransform != null && currenTransform.tag != Destination.tag)
        {
            Debug.Log(Destination.tag);
            if (currenTransform.tag == "Bedroom")
            {
                if (Destination.tag == "Livingroom")
                {
                    originSpot = spot2livingroom;
                    endSpot = livingroom2spot;

                }
                else if (Destination.tag == "Bathroom")
                {
                    originSpot = spot2bathroom;
                    endSpot = bathroom2spot;
                }
            }
            else if (currenTransform.tag == "Livingroom")
            {
                if (Destination.tag == "Bedroom")
                {
                    originSpot = livingroom2spot;
                    endSpot = spot2livingroom;
                }
            }
            else if (currenTransform.tag == "Bathroom")
            {
                if (Destination.tag == "Bedroom")
                {
                    originSpot = bathroom2spot;
                    endSpot = spot2bathroom;
                }else if (Destination.tag == "Livingroom")
                {
                    originSpot = bathroom2spot;
                    endSpot = livingroom2spot;
                }
            }
            Transfer = true;
        }
        currenTransform = Destination;//update
        LastDestination = Destination.position;
        MoveLock = false;

    }

    public void Transport(Transform origin, Transform end)
    {
        if (this.transform.position.x == origin.position.x && this.transform.position.y == origin.position.y && Transfer)
        {
            this.transform.position = end.position;
            Transfer = false;
        }
        else
        {
            Distance = new Vector3((origin.position - this.transform.position).x, (origin.position - this.transform.position).y, 0);
            Direction = Vector3.Normalize(Distance);

            if (Distance.x <= 0)
            {
                if (!Left)
                {
                    Left = true;
                    TempScale.x = -Body.transform.localScale.x;
                    TempScale.y = Body.transform.localScale.y;
                    TempScale.z = Body.transform.localScale.z;
                    Body.transform.localScale = TempScale;
                }
            }
            else if (Distance.x > 0)
            {
                if (Left)
                {
                    Left = false;
                    TempScale.x = -Body.transform.localScale.x;
                    TempScale.y = Body.transform.localScale.y;
                    TempScale.z = Body.transform.localScale.z;
                    Body.transform.localScale = TempScale;
                }
            }

            Direction = new Vector3(Direction.x, Direction.y, 0);
            if (Distance.magnitude < Direction.magnitude * WalkSpeed * Time.deltaTime)
            {
                this.transform.position = this.transform.position + Direction * Distance.magnitude;
            }
            else
            {
                this.transform.position = this.transform.position + Direction * WalkSpeed * Time.deltaTime;
            }
        }
    }
    public void MovePos()
    {
        if (this.transform.position.x == LastDestination.x && this.transform.position.y == LastDestination.y && Transfer == false)
        {
            aiAnimator.SetBool("IsMove", false);
            MoveLock = true;
        }
        else
        {
            Distance = new Vector3((LastDestination - this.transform.position).x, (LastDestination - this.transform.position).y, 0);
            Direction = Vector3.Normalize(Distance);

            if (Distance.x <= 0)
            {
                if (!Left)
                {
                    Left = true;
                    TempScale.x = -Body.transform.localScale.x;
                    TempScale.y = Body.transform.localScale.y;
                    TempScale.z = Body.transform.localScale.z;
                    Body.transform.localScale = TempScale;
                }
            }
            else if (Distance.x > 0)
            {
                if (Left)
                {
                    Left = false;
                    TempScale.x = -Body.transform.localScale.x;
                    TempScale.y = Body.transform.localScale.y;
                    TempScale.z = Body.transform.localScale.z;
                    Body.transform.localScale = TempScale;
                }
            }

            Direction = new Vector3(Direction.x, Direction.y, 0);
            if (Distance.magnitude < Direction.magnitude * WalkSpeed * Time.deltaTime)
            {
                this.transform.position = this.transform.position + Direction * Distance.magnitude;
            }
            else
            {
                this.transform.position = this.transform.position + Direction * WalkSpeed * Time.deltaTime;
            }
        }
    }
}
