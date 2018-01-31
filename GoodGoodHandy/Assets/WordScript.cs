using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordScript : MonoBehaviour {

    private List<KeyScript> myKeys;
	
	void Start () {
        myKeys = new List<KeyScript>();
        for (int i = 0; i < transform.childCount; i++)
        {
            myKeys.Add(transform.GetChild(i).GetComponent<KeyScript>());
        }

        transform.position = new Vector3(transform.position.x, 6.5f, transform.position.z);
    }
	
	
	void Update () {
        if(WordTyped())
        {
            foreach(KeyScript kS in myKeys)
            {
                kS.HideSprite();
            }
        }
		
	}

    bool WordTyped () {
        foreach(KeyScript kS in myKeys)
        {
            if (!(kS.GetKeyHeld())){
                return false;
            }
        }
        return true;
    }
}
