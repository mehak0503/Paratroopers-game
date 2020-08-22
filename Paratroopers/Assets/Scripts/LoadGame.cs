using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour {

    // Use this for initialization
    public Text loadText;
    public GameObject mainmenu;
    public GameObject globe;
    public GameObject loadB;
    public GameObject quitB;
    //public GameObject startscreen;

    public void Start()
    {
        Invoke("Buttons", 2);
    }
    public void Load()
    {
        //loadText.text = "Loading..";
        int x;
        x = Random.Range(1, 2);
        Invoke("f",x);            

    }

    public void Buttons()
    {
        loadB.SetActive(true);
        quitB.SetActive(true);
        
    }
    public void f()
     {

        mainmenu.SetActive(true);
        globe.SetActive(true);
        //highscore.SetActive(true);

     }

}
