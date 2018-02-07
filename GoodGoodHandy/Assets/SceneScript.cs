using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneScript : MonoBehaviour {
    public int health = 3;
    public Text healthText;
    public GameObject ScreenText;

	// Use this for initialization
	void Start () {
        healthText.text = "" + health;
	}
	
	// Update is called once per frame
	void Update () {
        if (health < 0)
        {
            healthText.text = " YOU SUCK. YOURE GOING TO DIE POOR AND A FAILURE.";
        }
        else
        {
            healthText.text = "" + health;
        }
	}

    public void ReduceHealth()
    {
        health -= 1;
    }
}
