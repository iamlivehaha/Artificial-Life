using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamereaMove : MonoBehaviour
{

    public float ScrollSpeed = 10000;
    public Vector3 LivingRoom;
    public Vector3 BedRoom;
    public Vector3 BathRoom;
    private ArrayList Rooms = new ArrayList();
    private bool MoveLock;
    private int position;
    // Use this for initialization
    void Start()
    {
        Rooms.Add(LivingRoom);
        Rooms.Add(BedRoom);
        Rooms.Add(BathRoom);
        MoveLock = false;
        position = 1;
    }

    // Update is called once per frame
    void Update()
    {

        //DetectMove();

    }
    void DetectMove()//检测是否需要移动，需要则移动
    {
        if (Input.mousePosition.x <= 0)
        {
            MoveWithBoundary(-1);
        }
        if (Input.mousePosition.x >= Screen.width)
        {
            MoveWithBoundary(1);
        }
    }

    public void MoveLeft()
    {
        MoveWithBoundary(-1);
    }

    public void MoveRight()
    {
        MoveWithBoundary(1);
    }

    void MoveWithBoundary(int Direction)//检测是否超出游戏边界，没有则移动视角
    {
        if (MoveLock || position+Direction<0 || position+Direction>2)
        {
            return;
        }
        else
        {
            MoveLock = true;
            position = position + Direction;
            StartCoroutine(Move(position));
        }
    }

    IEnumerator Move(int nposition)
    {
        Vector3 Distance,Destination,Direction;
        Destination = (Vector3)Rooms[nposition];
        while (true)
        {
            if (this.transform.position.x == Destination.x && this.transform.position.y == Destination.y)
            {
                MoveLock = false;
                break;
            }
            else
            {
                Distance = new Vector3((Destination - this.transform.position).x, (Destination - this.transform.position).y, 0);
                Direction = Vector3.Normalize(Distance);
                Direction = new Vector3(Direction.x, Direction.y, 0);
                if (Distance.magnitude < Direction.magnitude * ScrollSpeed * Time.deltaTime)
                {
                    this.transform.position = this.transform.position + Direction * Distance.magnitude;
                }
                else
                {
                    this.transform.position = this.transform.position + Direction * ScrollSpeed * Time.deltaTime;
                }
            }
            yield return null;
        }
    }
}
