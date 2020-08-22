using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollide2 : MonoBehaviour
{
    AudioSource aud;
    public GameObject explosion;
    //public GameObject playerExplosion;
    public int scoreValue;
    private Game_control3 gameController;

    void Start()
    {
        aud = GetComponent<AudioSource>();
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController3");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<Game_control3>();
        }
        if (gameController == null)
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


        if (explosion != null && other.tag != "Parachute2" && other.tag != "Attacker" && other.tag != "Bomb" && other.tag != "Destructor")
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.tag == "Player" || other.tag == "Tank" || other.tag == "Shield")
        {
            aud.Play(0);
            // Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            //gameController.GameOver();
            //gameController.AddScore(scoreValue);
            //Destroy(other.gameObject);
            Destroy(gameObject, aud.clip.length / 10);
        }

        else
        {
            if (other.tag == "Enemy")
            {
                aud.Play(0);
                gameController.AddScore(scoreValue);
                Destroy(other.gameObject, aud.clip.length / 10);
                Destroy(gameObject, aud.clip.length / 10);
            }

            if (other.tag == "Destructor")
            {
                aud.Play(0);
                gameController.AddScore(scoreValue);
                Instantiate(explosion, transform.position, transform.rotation);
                //Destroy(other.gameObject);
                Destroy(gameObject, aud.clip.length / 10);
            }

            else if (other.tag == "Zigzag")
            {
                aud.Play(0);
                gameController.AddScore(scoreValue);
                //Destroy(other.gameObject);
                Destroy(gameObject, aud.clip.length / 10);
            }

            else if (other.tag == "Weapon")
            {
                aud.Play(0);
                //gameController.AddScore(scoreValue);
                //Destroy(other.gameObject);
                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(gameObject, aud.clip.length / 10);
            }
        }
    }

}
