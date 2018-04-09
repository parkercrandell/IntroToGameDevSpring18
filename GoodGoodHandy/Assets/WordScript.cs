using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordScript : MonoBehaviour {

    private List<KeyScript> myKeys;
    public bool isFast;
    public bool typed = false;
    public bool missed = false;
    public GameObject mySceneScript;
    public float defaultSpeed = 2.5f;
    public float fallSpeed;
    public float fastFallSpeed;
    public float enteranceYPos = 11;
    public float missYPos = -8;
    
    public SpriteRenderer mySprite;
    
    
	
	void Start () {
        mySprite = GetComponent<SpriteRenderer>();
        myKeys = new List<KeyScript>();
        for (int i = 0; i < transform.childCount; i++)
        {
            myKeys.Add(transform.GetChild(i).GetComponent<KeyScript>());
        }
        SetKeysToFast(isFast);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }


    void Update()
    {
        if (isFast && (transform.position.y < enteranceYPos))
        {
            defaultSpeed = fastFallSpeed;
        }else if(transform.position.y < enteranceYPos)
        {
            defaultSpeed = fallSpeed;
        }

        transform.position += new Vector3(0, (-defaultSpeed * Time.deltaTime), 0);
        if (WordTyped())
        {
            foreach (KeyScript kS in myKeys)
            {
                kS.HideSprite();
                typed = true;

            }
        }else if(IsWordMissed())
        {
            missed = true;
            foreach (KeyScript kS in myKeys)
            {
                kS.HideSprite();
                kS.MissSprite();
            }
        }

        
    }

    bool WordTyped()
    {
            foreach (KeyScript kS in myKeys)
            {
                if (!(kS.GetKeyHeld()))
                {
                    return false;
                }
            }
            return true;
    }

    //C
    bool IsWordMissed ()
    {
        if ((transform.position.y < missYPos) && !typed)
        {
            if (!missed)
            {
                mySceneScript.GetComponent<SceneScript>().ReduceHealth();
            }
            return true;
        }
        return false;
    }

    void SetKeysToFast(bool x)
    {
        foreach (KeyScript kS in myKeys)
        {
            kS.setFast(x);
        }
    }
}
