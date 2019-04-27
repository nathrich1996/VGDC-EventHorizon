using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    public Spawner spawner;
	//public float ScrollY = 0.5f;
   // public GameObject SpawnObject;
    float speed;

    // Update is called once per frame
    void Update()
    {
        speed = spawner.GetSpeed()*(-.002f);
        //speed = -.05f;
        float OffsetY = (Time.time * speed);
        GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(0, OffsetY);
        
    }
}
