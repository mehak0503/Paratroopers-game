using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;


public class Game_control : MonoBehaviour
{
    public GameObject[] hazards;
    public GameObject gameoverimage;
    public GameObject leveloverimage;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    private float nextBomb = 0;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text pauseText;

    public static bool gameOver;
    private bool restart;
    private bool check;
    private int score;
    private float x ;
    private int y;
    private int count_left;
    private int count_right;
    private int pause;
    private bool isPause;

    void Start()
    {
        gameOver = false;
        restart = false;
        check= false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        count_left = 0;
        count_right = 0;
        pause = 0;
        isPause = false;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameOver = true;
            SceneManager.LoadScene(0);

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

        if (count_left >= 4 || count_right >= 4)
        {
            if(!check)
                GameOver();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
            
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Resume();
           
        }

        if (score > 200)
        {
            gameOver = true;
            leveloverimage.SetActive(true);
            gameOverText.text = "Proceeding to next level!";
            restartText.text = "Press E to exit";
            check= true;
            Invoke("Level2", 5);         
            
        }

    }

    void Level2()
    {
        SceneManager.LoadScene(2);
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity;
        Vector3 spawnPosition1 = new Vector3(-spawnValues.x, spawnValues.y - 1.2f, spawnValues.z);
        while (true && !gameOver)
        {

            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[0];
                
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            for (int i = 0; i < hazardCount; i++)
            {
                 GameObject hazard = hazards[1];
                 
                 Quaternion spawnRotation1 = Quaternion.Euler(0,180,0);
                 Instantiate(hazard, spawnPosition1, spawnRotation1);
                 yield return new WaitForSeconds(spawnWait+0.1f);
            }

            if (Time.time > nextBomb+8)
            {
                Instantiate(hazards[2], new Vector3(Random.Range(-5,5),3,0), spawnRotation);
                nextBomb = Time.time;

            }

            yield return new WaitForSeconds(waveWait);

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
       
        UpdateScore();
    }

    void UpdateScore()
    {
        if(!gameOver)
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        //gameOverText.text = "Game Over!";
        gameoverimage.SetActive(true);
        gameOver = true;
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
        pauseText.text = "Game Paused.\nPress P to resume.";
        Time.timeScale = 0.0f;
        
        isPause = true;
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        pauseText.text = "";
        isPause = false;
    }
}