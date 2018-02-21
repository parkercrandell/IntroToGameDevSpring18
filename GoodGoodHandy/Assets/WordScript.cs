using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordScript : MonoBehaviour {

    private List<KeyScript> myKeys;
    public bool typed = false;
    public bool missed = false;
    public GameObject mySceneScript;
    public float fallSpeed = 0.3f;
    
    
	
	void Start () {
        myKeys = new List<KeyScript>();
        for (int i = 0; i < transform.childCount; i++)
        {
            myKeys.Add(transform.GetChild(i).GetComponent<KeyScript>());
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }


    void Update()
    {
        transform.position += new Vector3(0, -fallSpeed, 0);
        if (WordTyped())
        {
            foreach (KeyScript kS in myKeys)
            {
                kS.HideSprite();
                typed = true;

            }
        }else if(WordMissed())
        {
            missed = true;
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

    bool WordMissed ()
    {
        if ((transform.position.y < -8) && !typed)
        {
            if (!missed)
            {
                mySceneScript.GetComponent<SceneScript>().ReduceHealth();
            }
            return true;
        }
        return false;
    }
}
