using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour {

    public float timer = 0;
    public Sprite baseSprite;
    public KeyCode SetKey;
    public bool keyHeld = false;
    public SpriteRenderer mySpriteRenderer;
    public float maxTimer = 1.5f;
    public Sprite nA;
    public Color initialColor;
    public bool keyDone;
  
	void Start () {
        keyDone = false;
        transform.position = new Vector3(transform.position.x, transform.position.y + (Random.value * 0.50f), transform.position.z);
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        baseSprite = mySpriteRenderer.sprite;
        initialColor = new Color(207f, 255f, 207f, 1f);
        //WHYDONTTHESECOLORVARIABLESWORK
    }

    void Update()
    {
        if (Input.GetKeyDown(SetKey))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + (0.5f), transform.position.z);
        }
        if (Input.GetKeyUp(SetKey))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - (0.5f), transform.position.z);
        }

        if (Input.GetKey(SetKey) && transform.position.y < 11)
        {

            timer = timer + Time.deltaTime;
            if (!keyDone)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + ((Random.value * 0.2f) - 0.1f), transform.position.z);
            }

            if (timer > maxTimer)
            {
                keyHeld = true;
                mySpriteRenderer.sprite = nA;
              
            }
            else
            {
                mySpriteRenderer.sprite = baseSprite;
            }
        }
        else
        {
            timer = 0;
            
            mySpriteRenderer.sprite = baseSprite;
            keyHeld = false;
        }
    }

    public bool GetKeyHeld() {
        return keyHeld;
    }
     
    public void HideSprite()
    {
        baseSprite = nA;
        keyDone = true;
    }
}
