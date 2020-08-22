using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

   

    public float speed = 0.5f;
 
	
	void Update () {
        if(Game_control3.gameOver || Game_control.gameOver)
        {
            speed =  0.1f;                      
        }
        
        Vector2 offset = new Vector2(Time.time * speed, 0);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
		
	}
}
