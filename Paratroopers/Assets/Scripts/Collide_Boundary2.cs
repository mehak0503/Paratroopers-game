using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide_Boundary2 : MonoBehaviour
{

    
    private Game_control3 gameControl;
    private Vector3 position1;
    private Vector3 position2;
    private Quaternion rotation;
    public GameObject Paratroop;
    public GameObject zigzag;


    void Start()
    {
        
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController3");
        gameControl = gameControllerObject.GetComponent<Game_control3>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zigzag")
        {
            position1 = other.transform.position;
            rotation = other.transform.rotation;
            //Destroy(other.gameObject);

            Instantiate(zigzag, position1, Quaternion.Euler(0,180,0));
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Parachute2")
            {
            position1 = other.transform.position;
            position2.y = position1.y-0.4f;
            position2.z = position1.z;

            if (position1.x > 0)
            {
                position2.x = position1.x + 0.7f;

                gameControl.Count_left();
                Instantiate(Paratroop, position2, Quaternion.Euler(0, 270, 0));

            }
            else if (position1.x < 0)
            {
                position2.x = position1.x + 2.3f;

                gameControl.Count_right();
                Instantiate(Paratroop, position2, Quaternion.Euler(0, 50, 0));

            }
            
                gameControl.AddScore(-5);
            }


            Destroy(other.gameObject);
        
    }
}
