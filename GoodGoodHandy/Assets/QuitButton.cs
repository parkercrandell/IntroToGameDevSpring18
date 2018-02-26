using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{

    private List<KeyScript> myKeys;
    //public GameObject mySceneScript;



    void Start()
    {
        myKeys = new List<KeyScript>();
        for (int i = 0; i < transform.childCount; i++)
        {
            myKeys.Add(transform.GetChild(i).GetComponent<KeyScript>());
        }
    }


    void Update()
    {
        if (WordTyped())
        {
            Application.Quit();
            foreach (KeyScript kS in myKeys)
            {
                kS.HideSprite();

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
}

