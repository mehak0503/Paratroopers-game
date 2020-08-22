using UnityEngine;
//using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Game_control2 : MonoBehaviour
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
    private Game_control gameControl;
    private int x;
    

    void Start()
    {        
        score = 0;
        //count = 0;
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        gameControl = gameControllerObject.GetComponent<Game_control>();
        UpdateScore();
        StartCoroutine(SpawnWaves());       

    }

    

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
           
            for (int i = 0; i < hazardCount; i++)
            {
                 GameObject hazard = hazards[0];
                 Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x,spawnValues.x), spawnValues.y-1, spawnValues.z);
                 Quaternion spawnRotation = Quaternion.identity;
                 Instantiate(hazard, spawnPosition, spawnRotation);
                 yield return new WaitForSeconds(spawnWait);
            }    
            
            yield return new WaitForSeconds(waveWait);
           

            if (Game_control.gameOver)

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