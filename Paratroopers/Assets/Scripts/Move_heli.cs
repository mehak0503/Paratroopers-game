using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_heli : MonoBehaviour {

    public float speed;
	void Start ()
    {
        if(gameObject.tag=="Helicopter1")
            GetComponent<Rigidbody>().velocity = new Vector3(-1,0,0) * speed;
        else
            GetComponent<Rigidbody>().velocity = transform.right * speed;
        

    }
	
	}
