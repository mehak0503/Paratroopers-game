using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyTank : MonoBehaviour
{

    public GameObject explosion;
    //public GameObject playerExplosion;
    public Scrollbar damageValue;
    public GameObject scroll;

    
    public Image damage;
    public Image damage1;
    public Text damageText;
    

    private Game_control3 gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController3");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<Game_control3>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        damage.sprite = null;
        damageText.text ="Tank damage";
        //damageValue= 0;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        if (other.tag == "Boundary")
        {
            return;
        }


        if (explosion != null && other.tag != "Helicopter" && other.tag != "Parachute" && other.tag != "Attacker")
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        

        if (other.tag == "Bomb" )
        {
                 
                damageValue.value += 0.2f;
                //damageText.text = "Tank Damage:" 
                Destroy(other.gameObject);
                
                if (damageValue.value >= 1)
                {
                GameObject g = GameObject.FindGameObjectWithTag("Player");
                GameObject g1 = GameObject.FindGameObjectWithTag("Shield");
                if (g1 != null)
                    Destroy(g1);
                Destroy(g);
                Destroy(gameObject);
                gameController.GameOver();
                }
                    
             
            
          }         


    }
}
