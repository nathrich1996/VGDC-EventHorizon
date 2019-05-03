using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     Rigidbody rb;

    public Animator anim;

    public float laneChangeSpeed = 0f; //enough to move from one lane to the next 50000
    //public const float LANE_DIST = 3500.0f;
    // Start is called before the first frame p
    private int lane = 3; //5 lanes total, 3 is in the middle lane, range = 1-5
    private bool movingRight = false;
    private bool movingLeft = false;

    private Vector3 position;
    float[] lanePositions = { -20f, -10f, 0f, 10f, 20f };
    /*Lane Positions
   || 1   2   3   4   5 ||
    1 = (-20.14, 0.6, -170) 
    2 = (-10.07, 0.6, -170) 
    3 = (0, 0.6, -170) 
    4 = (9.91, 0.6, -170) 
    5 = (20.07, 0.6, -170)
     */
    void Start()
    {
        Debug.Log("Game Started!");
        rb = GetComponent<Rigidbody>();
        position = Vector2.zero;
        anim.GetComponent<Animator>();
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
            Debug.Log("A press");
        }
        if (Input.GetKeyDown("d")) //move right
        {

            movingRight = true;
            movingLeft = false;
            MoveLane(true); //move right
           
            Debug.Log("D press");
        }
       
        if (movingRight)
        {
            if (transform.position.x < lanePositions[lane - 1]) //move right
            {
               // anim.SetTrigger("MoveRight");
                rb.MovePosition(new Vector2(transform.position.x + (laneChangeSpeed * Time.deltaTime), transform.position.y));
            }
            if (transform.position.x > lanePositions[lane - 1]) //don't go too far
            {
                rb.MovePosition(new Vector2(lanePositions[lane - 1], transform.position.y));
              //  anim.ResetTrigger("MoveRight");
            }

        }
        else if (movingLeft)
        {
            if (transform.position.x > lanePositions[lane - 1]) //move left
            {
               // anim.SetTrigger("MoveLeft");
                rb.MovePosition(new Vector2(transform.position.x - (laneChangeSpeed * Time.deltaTime), transform.position.y));
            }
            if (transform.position.x < lanePositions[lane - 1]) //don't go too far
            {
                rb.MovePosition(new Vector2(lanePositions[lane - 1], transform.position.y));
               // anim.ResetTrigger("MoveLeft");
            }
        }
        //anim.ResetTrigger("MoveRight");
       // anim.ResetTrigger("MoveLeft");

    }

    void MoveLane(bool right)
    {
        lane += (right) ? 1 : -1; //move right if true, left if false

        if (lane == 6)
            --lane;
        if (lane == 0)
            ++lane;
    }

 
}
