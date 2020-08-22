using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWeapon : MonoBehaviour
{

    public float speed;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.up * speed;        
    }

    

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Time.timeScale = 1.0f;
            speed = 10;
            GetComponent<Rigidbody>().velocity = transform.up * speed;
            
        }
       // yield return new WaitForSeconds(2);
    }
    
}
