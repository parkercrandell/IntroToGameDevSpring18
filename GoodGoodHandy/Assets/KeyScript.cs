﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour {

    public float timer = 0;
    public KeyCode SetKey;
    public bool keyHeld = false;
    public SpriteRenderer mySpriteRenderer;
    public float maxTimer = 1.5f;

	// Use this for initializatewion
	void Start () {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(SetKey))
        {
            Debug.Log(keyHeld);
            timer = timer + Time.deltaTime;
            if (timer > maxTimer)
            {
                keyHeld = true;
            }
        }
        else
        {
            timer = 0;
            keyHeld = false;
        }

        if (keyHeld)
        {
            mySpriteRenderer.color = Color.green;
        }


    }
}
