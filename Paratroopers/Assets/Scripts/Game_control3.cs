using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;


public class Game_control3 : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public GameObject[] weapons;
    public float nextFire;
    public GameObject canvas;
    public GameObject gameoverimage;
    
    public static bool paused;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text shieldText,weaponText,weaponSelText;
    public Text pauseText;

    public static bool gameOver;
    public bool shield_active;
    private bool restart;
    public static int score;
    public static int check=0;
    public GameObject shield;
    private int prev_score;
    private int prev_score1;
    private int prev_score2;
    private int count_left;
    private int count_right;
    private int pause;
    private bool isPause;
    public Transform zigzagSpawn;
    public static int index;
    public static int i=0;
    public static string level = "Level";
   
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;
    public GameObject explosion;
    void Start()
    {
        gameOver = false;
        restart = false;
        paused = false;
        restartText.text = "";
        gameOverText.text = "";
        shieldText.text = "";
        score = 0;
        prev_score = 0;
        prev_score1 = 0;
        prev_score2 = 0;
        shield_active = false;
        pause = 0;
        isPause = false;
        /*flag = false;
        flag1 = false;
        flag2 = false;*/
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    void Update()

    {
        if (!paused )
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameOver();
                SceneManager.LoadScene(0);  
            }


            if (count_left >= 4 || count_right >= 4)
            {
                GameOver();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();                
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                Resume();
                
            }

            if (restart)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    gameOver = false;
                    gameoverimage.SetActive(false);

                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }

            if (score > prev_score + 100 && shield != null)
            {
                Instantiate(shield, new Vector3(0.4f, -3.2f, 0.3f), transform.rotation);
                shield_active = true;
                prev_score = score;
                shieldText.text = "Shield activated";
            }

            if (shield == null)
            {
                shield_active = false;
            }


            //  if (score > 200 + prev_score1)
            if (score > 100)
            {
             

                weaponText.text = "Press W to enter Weapon Store";

                if (Input.GetKeyDown(KeyCode.W))
                {
                    if (!gameOver)
                    {
                        paused = true;
                        canvas.SetActive(false);

                        SceneManager.LoadScene(3, LoadSceneMode.Additive);
                        prev_score1 = score;
                        check = 1;
                    }
                }


            }
            else
                weaponText.text = "";

            if(check==1 && !paused)
            {
                canvas.SetActive(true);
                StartCoroutine(SpawnWaves());
                check = 0;
                
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha3) && flag3 )
            {
                Vector3 position = new Vector3(6, 5, 0);
                Instantiate(weapons[2], position, Quaternion.Euler(180,0,0));
                //prev_score1 = score;
                flag3 = false;
                weaponSelText.text = weaponSelText.text.Replace("Press 3 to load Destructive X\n", "");

            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && flag2)
            {
                Vector3 position = new Vector3(0, 2, 0);
                Instantiate(weapons[1], position, Quaternion.Euler(0, 0, 0));
                Instantiate(explosion, transform.position, transform.rotation);
                //prev_score2 = score;
                flag2 = false;
                weaponSelText.text = weaponSelText.text.Replace("Press 2 to load Blaster\n", "");
            }


            
            if (Input.GetKeyDown(KeyCode.Alpha1) && Time.time > nextFire && flag1)
            {
                nextFire = Time.time + 1;
                Instantiate(weapons[0], zigzagSpawn.position, Quaternion.Euler(0, 0, 0));
                Instantiate(weapons[0], new Vector3(-2, 2.5f, 0), Quaternion.Euler(20, 0, 0));
                Instantiate(weapons[0], new Vector3(-4, 3.3f, 0), Quaternion.Euler(40, 0, 0));
                Instantiate(weapons[0], new Vector3(2, 2.5f, 0), Quaternion.Euler(340, 0, 0));
                Instantiate(weapons[0], new Vector3(4, 3.3f, 0), Quaternion.Euler(320, 0, 0));
                Instantiate(weapons[0], new Vector3(6, 4.2f, 0), Quaternion.Euler(300, 0, 0));
                Instantiate(weapons[0], new Vector3(-6, 4.2f, 0), Quaternion.Euler(60, 0, 0));
                //prev_score1 = score;
                flag1 = false;
                weaponSelText.text = weaponSelText.text.Replace("Press 1 to load Bomber\n","");
            }

            if (weaponstore.flag3)
            {
                weaponSelText.text = weaponSelText.text+"Press 3 to load Destructive X\n";
                weaponstore.flag3 = false;
                flag3 = true;
            }

            if (weaponstore.flag1)
            {
                weaponSelText.text = weaponSelText.text+"Press 1 to load Bomber\n";
                weaponstore.flag1 = false;
                flag1 = true;
            }

            if (weaponstore.flag2)
            {
                weaponSelText.text = weaponSelText.text+"Press 2 to load Blaster\n";
                weaponstore.flag2 = false;
                flag2 = true;
            }

            if (weapons[0] == null)
            {
                weaponstore.flag1 = false;
            }

            if (weapons[1] == null)
            {
                weaponstore.flag2 = false;
            }

            if (weapons[2] == null)
            {
                weaponstore.flag3 = false;
            }

            

        }
    }
    


    IEnumerator SpawnWaves()
    {
         yield return new WaitForSeconds(startWait);
            while (true && !paused)
            {
                
                for (int i = 0; i < hazardCount; i++)
                {
                    GameObject hazard = hazards[0];
                    Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }

                yield return new WaitForSeconds(waveWait);
                shieldText.text = "";
                weaponText.text = "";

                //yield return new WaitForSeconds(waveWait);

                if (gameOver)
                {
                    restartText.text = "Press 'R' for Restart";
                    restart = true;
                    break;
                }
                
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        if (score < 0)
        {
            scoreText.text = "Negative score";
            UpdateScore();
            GameOver();
        }
        else if (score > 2000)
        {
            gameOverText.text = "You Won!";
            UpdateScore();
            gameOver = true;
        }
        else
            UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        //gameOverText.text = "Game Over!";
        gameoverimage.SetActive(true);
        gameOver = true;
    }

    public bool CheckShield()
    {
        if (shield_active)
            return true;
        else
            return false;
    }

    public void Count_left()
    {
        count_left++;
    }

    public void Count_right()
    {
        count_right++;
    }

    public void Pause()
    {

        Time.timeScale = 0.0f;
        pauseText.text = "Game Paused.\nPress P to resume.";
        isPause = true;
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        pauseText.text = "";
        isPause = false;
    }
}


    