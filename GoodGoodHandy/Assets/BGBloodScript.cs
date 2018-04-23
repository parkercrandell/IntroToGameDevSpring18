using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGBloodScript : MonoBehaviour {

    public float alpha = 1f;
    public float timer = 0;
    public bool timerStart = false;
    public float fallPos = 0.5f;
    public float normalTime = 0.5f;
    float originalYPos;

    SpriteRenderer spriteRend;
    Color bloodColor;

	void Start() {
        originalYPos = transform.position.y;
        bloodColor = new Color(255, 255, 255, alpha);

        spriteRend = GetComponent<SpriteRenderer> ();
		spriteRend.color = new Color (255,255,255,0);
	}

	void Update() {

		if (SceneScript._SceneScript.health == 4)
		{
			if(this.gameObject.name == ("blood4"))
			{
				spriteRend.color = bloodColor;
                timerStart = true;
			}
            
		}

		if (SceneScript._SceneScript.health == 3)
		{
			if(this.gameObject.name == ("blood3"))
			{
				spriteRend.color = bloodColor;
                timerStart = true;
            }
		}

		if (SceneScript._SceneScript.health == 2)
		{
			if(this.gameObject.name == ("blood2"))
			{
				spriteRend.color = bloodColor;
                timerStart = true;
            }
		}

		if (SceneScript._SceneScript.health == 1)
		{
			if(this.gameObject.name == ("blood1"))
			{
				spriteRend.color = bloodColor;
                timerStart = true;
            }
		}
        if (timerStart)
        {
            timer += Time.deltaTime / normalTime;
        }
        else if(timer < 1)
        {
            timerStart = false;
        }
        
        transform.position = new Vector3(transform.position.x, originalYPos - Mathf.Lerp(0, 0.5f, timer), transform.position.z);   
	}
}
