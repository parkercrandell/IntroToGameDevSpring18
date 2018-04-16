using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGBloodScript : MonoBehaviour {

	SpriteRenderer spriteRend;


	Color bloodColor = new Color(255,255,255,200);

	void Start() {
		spriteRend = GetComponent<SpriteRenderer> ();
		spriteRend.color = new Color (255,255,255,0);
	}

	void Update() {

		if (SceneScript._SceneScript.health == 4)
		{
			if(this.gameObject.name == ("blood4"))
			{
				spriteRend.color = bloodColor;
			}
		}

		if (SceneScript._SceneScript.health == 3)
		{
			if(this.gameObject.name == ("blood3"))
			{
				spriteRend.color = bloodColor;
			}
		}

		if (SceneScript._SceneScript.health == 2)
		{
			if(this.gameObject.name == ("blood2"))
			{
				spriteRend.color = bloodColor;
			}
		}

		if (SceneScript._SceneScript.health == 1)
		{
			if(this.gameObject.name == ("blood1"))
			{
				spriteRend.color = bloodColor;
			}
		}
	}
}
