using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollide : MonoBehaviour {
    AudioSource aud;
    public GameObject explosion;
    
    public int scoreValue;
    private Game_control GameController;

    void Start()
    {
        aud = GetComponent<AudioSource>();
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            GameController = gameControllerObject.GetComponent<Game_control>();
        }
        if (GameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        
        if (other.tag == "Boundary")
        {
            return;
        }


        if (explosion != null && other.tag!= "Helicopter" && other.tag!="Parachute" && other.tag!="Helicopter1" && other.tag!="Player")
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (other.tag == "Bomb1" && gameObject.tag=="Tank")
        {
            
            Destroy(other.gameObject);
            GameObject g = GameObject.FindGameObjectWithTag("Player");
            Destroy(g);
            Destroy(gameObject);
            GameController.GameOver();
        }

        if ((other.tag == "Player" && gameObject.tag!="Tank" ) || other.tag == "Tank")
        {
            aud.Play(0);
           // Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            //gameController.GameOver();
            //gameController.AddScore(scoreValue);
            //Destroy(other.gameObject);
            Destroy(gameObject,aud.clip.length/10);
        }
        

        else
        {
            if (other.tag == "Enemy" && gameObject.tag!="Tank")
            {
                aud.Play(0);
                GameController.AddScore(scoreValue);
                Destroy(other.gameObject,aud.clip.length/10);
                Destroy(gameObject,aud.clip.length/10);
            }
        }


    }
}
