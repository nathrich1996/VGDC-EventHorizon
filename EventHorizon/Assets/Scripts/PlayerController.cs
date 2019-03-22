using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     Rigidbody rb;
    public float laneChangeSpeed = 5.0f; //enough to move from one lane to the next 50000
    public const float LANE_DIST = 3500.0f;
    // Start is called before the first frame p
    private int lane = 3; //5 lanes total, 3 is in the middle lane, range = 1-5
    private bool movingRight = false;
    private bool movingLeft = false;

    public float[] lanePositions;
    


    void Start()
    {
        Debug.Log("Game Started!");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Finding Input
        if (Input.GetKeyDown("a")) //move left
        {

            movingRight = false;
            movingLeft = true;
            MoveLane(false);
            //rb.AddForce(Time.deltaTime *-laneChangeSpeed ,0,0);
            Debug.Log("A press");
        }
        if (Input.GetKeyDown("d")) //move right
        {

            movingRight = true;
            movingLeft = false;
            MoveLane(true);
            //rb.AddForce(Time.deltaTime * laneChangeSpeed, 0, 0);
            Debug.Log("D press");
        }
        //if (!Input.anyKeyDown)    
        //{
        //    movingRight = false;
        //    movingLeft = false;
        //}
        Vector3 position = Vector3.zero;
        switch (lane)
        {
            case 1: //Leftmost end of the map
                position -= Vector3.right * LANE_DIST;
                Debug.Log("In Lane 1");
                break;
            case 2:
                if (movingRight)
                    position += Vector3.right * LANE_DIST;
                else if (movingLeft)
                    position -= Vector3.right * LANE_DIST;
                Debug.Log("In Lane 2");
                break;
            case 3:
                if (movingRight)
                    position += Vector3.right * LANE_DIST;
                else if (movingLeft)
                    position -= Vector3.right * LANE_DIST;
                Debug.Log("In Lane 3");
                break;
            case 4:
                if (movingRight)
                    position += Vector3.right * LANE_DIST;
                else if (movingLeft)
                    position -= Vector3.right * LANE_DIST;
                Debug.Log("In Lane 4");
                break;
            case 5:
                position += Vector3.right * LANE_DIST;
                Debug.Log("In Lane 5");
                break;
            
        }
        Vector3 moveVector = Vector3.zero;
        moveVector.x = (position - transform.position).normalized.x * laneChangeSpeed;
        //moveVector.y = 0.6f;
        //moveVector.z = -42.3f;
        //rb.MovePosition(moveVector * Time.deltaTime);
        //if (movingLeft || movingRight)
        //    rb.position += moveVector;
        rb.AddForce(moveVector);
    }
    void MoveLane(bool right)
    {
        lane += (right) ? 1 : -1;
        lane = Mathf.Clamp(lane, 0, 6);
    }
}
