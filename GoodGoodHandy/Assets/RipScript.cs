using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RipScript : MonoBehaviour
{

    Sprite bSprite;
    public SpriteRenderer mySpriteRenderer;
    public Sprite nA;
    public KeyScript kS;
    public Rigidbody2D myRigid;
    private float missedKeyHOffset;
    private float missedKeyROffset;

    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        bSprite = mySpriteRenderer.sprite;
        mySpriteRenderer.sprite = nA;
        kS = transform.GetComponentInParent<KeyScript>();
        missedKeyHOffset = (Random.value * 10f) - 5f;
        missedKeyROffset = (Random.value * 10f) - 5f;
}

    // Update is called once per frame
    void Update()
    {
        if (kS.keyHeld)
        {
            mySpriteRenderer.sprite = bSprite;
        }
        else
        {
            mySpriteRenderer.sprite = nA;
        }

        if (kS.wordDone)
        {
            myRigid.simulated = true;
            myRigid.AddForce(new Vector2((Random.value * 10f) - 5f, (Random.value * 20f) - 10f));
            myRigid.AddTorque((Random.value * 20f) - 10f);
            nA = bSprite;
            if (kS.wordMissed)
            {
                myRigid.AddTorque(missedKeyROffset);
                myRigid.AddForce(new Vector2(missedKeyHOffset, (Random.value * 20f) - 5f));
                mySpriteRenderer.color = Color.black;
            }
        }
    }
}

    
