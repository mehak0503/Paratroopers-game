using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move_menuObj : MonoBehaviour
{

    private int x;
    public GameObject[] Objects;
    private Game_control3 gameControl;
    //public Text score1;
   
    void Start()
    {
       
        //GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController3");
        //gameControl = gameControllerObject.GetComponent<Game_control3>();
        //score1 = gameControl.scoreText;
        //score1.text = "HIGH SCORE: "+ Game_control3.score;
        StartCoroutine(SpawnObj());

    }

    IEnumerator SpawnObj()
    {
        while (true)
        {            
            GameObject obj = Objects[0];
            Vector3 spawnPosition = new Vector3(-8, 5, 0);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(obj, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(1);
            
        }
    }
}
