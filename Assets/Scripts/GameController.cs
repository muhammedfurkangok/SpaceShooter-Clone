using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public int spawnCount;
    public float spawnWait;
    public float startSpawn;
    public float waveWait;

    public Text scoreText;
    public Text gameOverText;
    public Text restartText;
    public Text quitText;
    public int score;

    private bool gameOver;
    private bool restart;


    void Update()
    {
        if(restart == true)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
                
            }
            if(Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
                Debug.Log("Oyun Kapandı!");
            }
        }

    }

    IEnumerator SpawnValues()
    {
        yield return new WaitForSeconds(startSpawn);
        while (true)
        {
            
            for (int i = 0; i < spawnCount; i++)//i += 1
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-3, 3), 0, 10);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(hazard, spawnPosition, spawnRotation);

                //Coroutine
                //1.IEnumerator döndürmek zorundadır.
                //2.En az 1 adet yield ifadesi bulunmak zorundadır.
                //3.Coroutinler çağrılırken mutlaka StartCoroutine metoduyla çağrılmalıdır.

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if(gameOver == true)
            {
                restartText.text = "Press 'R' for Restart";
                quitText.text = "Press 'Q' for Quit";
                restart = true;
                break;
            }

        }

    }

    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }

    void Start()
    {
        gameOverText.text = "";
        restartText.text = "";
        quitText.text = "";
        gameOver = false;
        restart = false;
        StartCoroutine(SpawnValues());
        
    }

    
}
