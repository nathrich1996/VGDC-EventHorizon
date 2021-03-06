﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelGem : MonoBehaviour
{
    
    private float gemSpeed = 25.0f;
    bool dead = false;
    public BoxCollider bc;

    Fuel fuelUI;
    
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider>();
        fuelUI = GameObject.FindGameObjectWithTag("Fuel UI").GetComponent<Fuel>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            transform.Translate(0, 0, -gemSpeed * Time.deltaTime);
            CheckOffScreen();
        }

    }
    void CheckOffScreen()
    {
        if (transform.position.z < -200.0f)
        {
            Destroy(gameObject);
            dead = true;
        }
    }
    private void OnTriggerEnter(Collider collide)
    {
        //if (collision.rigidbody)
        //{
        Debug.Log("Gem hit player");
        fuelUI.IncrementFuel();
        Destroy(gameObject);
        dead = true;

        //}
    }
    public void SetSpeed(float speed)
    {
        gemSpeed = speed;
    }
}
