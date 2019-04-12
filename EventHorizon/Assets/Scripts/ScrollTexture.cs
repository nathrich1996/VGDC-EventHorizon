using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
	public float ScrollY = 0.5f;

    // Update is called once per frame
    void Update()
    {
        float OffsetY = Time.time * ScrollY;
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (0, OffsetY);
    }
}
