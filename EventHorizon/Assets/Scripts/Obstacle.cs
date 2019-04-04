using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Rigidbody rb;
    private float obsSpeed = 250.0f; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(0,0,-obsSpeed * Time.deltaTime);
    }
    void CheckOffScreen()
    {
        if (transform.position.z < -90.0f)
        {
            Destroy(GetComponent<Rigidbody>());
        }
    }
}
