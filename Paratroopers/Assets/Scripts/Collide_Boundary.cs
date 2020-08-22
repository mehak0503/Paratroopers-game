using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide_Boundary : MonoBehaviour {

    
    private Game_control gameControl;
    public GameObject Paratroop;
    private Vector3 position1;
    private Vector3 position2;

    void Start()
    {
        
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        gameControl = gameControllerObject.GetComponent<Game_control>();        
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Parachute")
        {
            position1 = other.transform.position;
            position2.y = position1.y-0.4f;
            position2.z = position1.z;

            if (position1.x > 0)
            {
                position2.x = position1.x + 0.7f;

                gameControl.Count_left();
                Instantiate(Paratroop, position2, Quaternion.Euler(0,270,0));

            }
            else if (position1.x < 0)
            {
                position2.x = position1.x+2.3f;

                gameControl.Count_right();
                Instantiate(Paratroop, position2, Quaternion.Euler(0,50,0));

            }
           // Debug.Log(position1);
                       
            gameControl.AddScore(-5);
        }

        Destroy(other.gameObject);
    }
}
