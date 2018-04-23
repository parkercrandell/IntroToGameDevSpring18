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
    public float timer = 1;
    public float normalizeTime = 0.5f;
    public float jiggleFactor = 0.7f;
    Vector3 originalPos;

	void Start () {
		_SceneScript = this;
        healthText.text = "" + health;
        originalPos = transform.position;
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
            if (timer < 1)
            {
                transform.localPosition = originalPos + Random.insideUnitSphere * jiggleFactor;
                timer += Time.deltaTime / normalizeTime;
            }
            else
            {
                transform.position = originalPos;
            }
        }
	}

    public void ReduceHealth()
    {
        health -= 1;
        timer = 0;
    }
}
