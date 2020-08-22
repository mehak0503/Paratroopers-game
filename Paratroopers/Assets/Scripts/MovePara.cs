using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePara : MonoBehaviour
{

    public float speed;

    void Start()
    {
        if(transform.position.x < -1)
        GetComponent<Rigidbody>().velocity =  transform.right * speed;
        else if (transform.position.x > 2)
            GetComponent<Rigidbody>().velocity = new Vector3(-1,0,0) * (speed);
    }
     void Update()
    {
        if (transform.position.x > -1 && transform.position.x < 2)
            GetComponent<Rigidbody>().velocity = transform.right * 0;

    }


}