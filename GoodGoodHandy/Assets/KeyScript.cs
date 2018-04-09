using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour {

    public float timer = 0;
    public bool isFast;
    public float fastMaxTimer = 0.4f;
    public Sprite baseSprite;
    public KeyCode SetKey;
    public bool keyHeld = false;
    public SpriteRenderer mySpriteRenderer;
    public AudioSource myAudio;
    public float maxTimer = 1.5f;
    public Sprite nA;
    public bool wordDone = false;
    public bool wordMissed = false;
    public AudioClip initTear;
    public AudioClip followTear;
    public float enteranceYPos = 11;
    public float missYPos = -8;

    void Start () {
        wordDone = false;
        transform.position = new Vector3(transform.position.x, transform.position.y + (Random.value * 0.50f), transform.position.z);
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAudio = GetComponent<AudioSource>();
        baseSprite = mySpriteRenderer.sprite;
    }

    void Update()
    {
        //IF FAST CHANGE THE LENGTH REQUIRED TO HOLD LETTER
        if (isFast)
        {
            maxTimer = fastMaxTimer;
        }

        //INITIAl PRESS ANIMATION & SOUND
        if (Input.GetKeyDown(SetKey) && transform.position.y < enteranceYPos && transform.position.y > missYPos)
        {
            if (!wordDone)
            {
                myAudio.PlayOneShot(initTear, 1f);
            }

            transform.position = new Vector3(transform.position.x, transform.position.y + (0.5f), transform.position.z);
        }
        if (Input.GetKeyUp(SetKey) && transform.position.y < enteranceYPos)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - (0.5f), transform.position.z);
        }

        //CHECKING IF KEY IS HELD
        if (Input.GetKey(SetKey) && transform.position.y < enteranceYPos)
        {

            timer = timer + Time.deltaTime;
            if (!wordDone)
            {
                //KEYS SHAKE AS LONG AS THE ENTIRE WORD IS NOT DONE
                transform.position = new Vector3(transform.position.x, transform.position.y + ((Random.value * 0.2f) - 0.1f), transform.position.z);
            }

            if (timer > maxTimer)
            {
                if (!keyHeld)
                {
                    //ONLY PLAYS SOUND ONCE AFTER TIMER ENDS
                    myAudio.PlayOneShot(followTear, 1f);
                }
                //REGISTERS KEY AS HELD AND HIDES SPRITE TO SHOW TEAR
                keyHeld = true;
                mySpriteRenderer.sprite = nA;               
            }           
        }
        else
        {
            //IF BUTTON IS LET GO OR KEY FALLS IT RESETS TIMER
            timer = 0;
            //PUTS SPRITE BACK AND RESETS BOOL
            mySpriteRenderer.sprite = baseSprite;
            keyHeld = false;
        }
    }

    public bool GetKeyHeld()
    {
        //GETTER FOR WORLD
        return keyHeld;
    }
     
    public void HideSprite()
    {
        //GETTING CALLED FROM WORD
        baseSprite = nA;
        wordDone = true;
    }
    
    public void MissSprite()
    {
        //GETTING CALLED FROM WORD
        wordMissed = true;
    }
    public void setFast(bool x)
    {
        isFast = x;
    }

    public void setYEnteranceYFailure(bool x)
    {
        isFast = x;
    }
}
