using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class weaponstore : MonoBehaviour {
    public Text new_score;
    public Text cart;
    private int cost = 0;
    private string cart_text;
    public static bool flag1 = false;
    public static bool flag2 = false;
    public static bool flag3 = false;
    public Button b1, b2, b3;
    // Use this for initialization

    void Start () {

        new_score.text = "Score : " + Game_control3.score;
        cart.text = "Selected : ";
        //Game_control3.score = 700;
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Game_control3.paused = false;
            SceneManager.UnloadSceneAsync(3);
        }
    }

    public void update_score()
    {
        Game_control3.score = Game_control3.score - cost;
        new_score.text = "Score : " + Game_control3.score;
        cost = 0;
    }

    public void update_score_d()
    {
        Game_control3.score = Game_control3.score + cost;
        new_score.text = "Score : " + Game_control3.score;
        cost = 0;
    }

    public void update_cart()
    {
        cart.text = cart.text+ " " + cart_text;
        cart_text = "";
    }

    public void but1()
    {
        if (!Game_control3.gameOver)
        {
            cost = 100;

            if (flag1 == false && Game_control3.score > 100)
            {
                flag1 = true;
                b1.GetComponentInChildren<Text>().text = "Deselect";
                cart_text = "Bomber";
                update_score();
                update_cart();

            }
            else if (b1.GetComponentInChildren<Text>().text == "Deselect")
            {
                string s = cart.text;
                s = s.Replace("Bomber", "");
                cart.text = s;
                flag1 = false;
                b1.GetComponentInChildren<Text>().text = "Select";
                update_score_d();
            }
        }

    }


    public void but2()
    {
        if (!Game_control3.gameOver)
        {
            cost = 300;
            if (flag2 == false && Game_control3.score > 300)
            {
                flag2 = true;
                b2.GetComponentInChildren<Text>().text = "Deselect";
                cart_text = "Blaster";
                update_score();
                update_cart();
            }
            else if (b2.GetComponentInChildren<Text>().text == "Deselect")
            {
                string s = cart.text;
                s = s.Replace("Blaster", "");
                cart.text = s;
                flag2 = false;
                b2.GetComponentInChildren<Text>().text = "Select";
                update_score_d();
            }
        }


    }

    public void but3()
    {
        if (!Game_control3.gameOver)
        {
            cost = 200;
            if (flag3 == false && Game_control3.score > 200)
            {
                flag3 = true;
                b3.GetComponentInChildren<Text>().text = "Deselect";
                cart_text = "Destructive X";
                update_score();
                update_cart();
            }
            else if (b3.GetComponentInChildren<Text>().text == "Deselect")
            {
                string s = cart.text;
                s = s.Replace("Destructive X", "");
                cart.text = s;
                flag3 = false;
                b3.GetComponentInChildren<Text>().text = "Select";
                update_score_d();
            }
        }

    }

}
