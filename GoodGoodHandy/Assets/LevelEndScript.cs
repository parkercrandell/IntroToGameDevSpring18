using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndScript : MonoBehaviour {

    public float fastFallSpeed;
    public float fallSpeed;
    public float enteranceYPos = 11;
    public float missYPos = -8;
    public string sceneName;

    void Start () {
       
    }
	

	void Update () {
        transform.position += new Vector3(0, (-fallSpeed * Time.deltaTime), 0);
        if(transform.position.y < enteranceYPos)
        {
            fallSpeed = fastFallSpeed;

            if (transform.position.y < missYPos)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
        
    }
}
