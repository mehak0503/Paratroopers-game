using UnityEngine;
//using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Game_control4 : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public Vector3 spawnValues1;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;

    private int score;
    private int count;
    private int leftHazardScore;
    private Game_control3 gameControl;
    
    private int x;

    private int j;
    private int y;


    void Start()
    {
        score = 0;
        count = 0;
        j = 0;
        y = 0;
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController3");
        gameControl = gameControllerObject.GetComponent<Game_control3>();
        UpdateScore();
        StartCoroutine(SpawnWaves());

    }
    public void Update()
    {
        
        if (Game_control3.check == 1 && !Game_control3.paused && !Game_control3.gameOver)
        {
            
            StartCoroutine(SpawnWaves());
            Game_control3.check = 0;

        }
    }



    IEnumerator SpawnWaves()
    {
            yield return new WaitForSeconds(startWait);
            while (true && !Game_control3.paused)
            {
                x = Random.Range(0, 2);
                switch (x)
                {
                    case 0:
                        {
                            for (int i = 0; i < hazardCount+2; i++)
                            {
                                GameObject hazard = hazards[0];
                                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                                Quaternion spawnRotation = Quaternion.identity;
                                Instantiate(hazard, spawnPosition, spawnRotation);

                                yield return new WaitForSeconds(spawnWait+0.05f);
                            }
                            break;
                        }
                    case 1:
                        {
                            for (int i = 0; i < hazardCount; i++)
                            {
                                GameObject hazard = hazards[1];
                                Vector3 spawnPosition = new Vector3(Random.Range
                                    (-spawnValues1.x, spawnValues1.x), spawnValues1.y-0.5f, spawnValues1.z);
                                Quaternion spawnRotation = Quaternion.identity;
                                Instantiate(hazard, spawnPosition, spawnRotation);

                                yield return new WaitForSeconds(spawnWait);
                            }
                            break;
                        }


                }
                yield return new WaitForSeconds(waveWait);
                
                yield return new WaitForSeconds(waveWait);
                if (Game_control3.gameOver)
                    break;

            
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }


}