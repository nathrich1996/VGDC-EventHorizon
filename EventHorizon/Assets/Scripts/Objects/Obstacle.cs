using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Rigidbody rb;
    bool dead = false;
    Shields shieldsUI;
    public BoxCollider bc;
    MusicControl mControl;
   
    private float obsSpeed = 25.0f; 
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider>();
        shieldsUI = GameObject.FindGameObjectWithTag("Shield UI").GetComponent<Shields>();
        mControl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MusicControl>();
        // shields.GetComponent<Shields>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!dead)
        {
            transform.Translate(0, 0, -obsSpeed * Time.deltaTime);

            CheckOffScreen();
        }

    }
    void CheckOffScreen()
    {
        if (transform.position.z < -200.0f)
        {
            Destroy(GetComponent<Rigidbody>());
            dead = true;
        }
    }
    private void OnTriggerEnter (Collider collide)
    {
        shieldsUI.currentShields--;
        mControl.ShieldBreak();
        Destroy(gameObject);
        dead = true;
    }
    public void SetSpeed(float speed)
    {
        obsSpeed = speed;
    }
    
}
