using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour {
    
	public static SceneScript _SceneScript;

	public int health = 5;
    public Text healthText;
    public GameObject ScreenText;

	
	void Start () {
		_SceneScript = this;
        healthText.text = "" + health;
	}
	
	// Update is called once per frame
	void Update () {
        if (health < 1)
        {
            healthText.text = "YOU LOSE";
            SceneManager.LoadScene("LossMenu");
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
