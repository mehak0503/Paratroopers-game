using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menuButton : MonoBehaviour {

    public void Play()
    {
        SceneManager.LoadScene("main_para");
    }
    public void Quit()
    {
        //SceneManager.LoadScene("main_para");
        
        Application.Quit();
    }
}
