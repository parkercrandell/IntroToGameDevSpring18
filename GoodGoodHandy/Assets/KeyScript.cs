using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour {

    public float timer = 0;
    public KeyCode SetKey;
    public bool keyHeld = false;
    public SpriteRenderer mySpriteRenderer;
    public float maxTimer = 1.5f;
    public Sprite nA;
  
	void Start () {
        transform.position = new Vector3(transform.position.x, transform.position.y + (Random.value * 0.50f), transform.position.z);
        mySpriteRenderer = GetComponent<SpriteRenderer>();
	}

    void Update()
    {
        if (Input.GetKey(SetKey) && transform.position.y < 5)
        {
            Debug.Log(keyHeld);
            timer = timer + Time.deltaTime;
            mySpriteRenderer.color = Color.Lerp(Color.white, Color.green, timer);
            if (timer > maxTimer)
            {
                keyHeld = true;
            }
        }
        else
        {
            timer = 0;
            mySpriteRenderer.color = Color.white;
            keyHeld = false;
        }

        if (keyHeld)
        {
            mySpriteRenderer.color = Color.green;
        }


    }

    public bool GetKeyHeld() {
        return keyHeld;
    }
     
    public void HideSprite()
    {
        mySpriteRenderer.sprite = nA;
    }
}
