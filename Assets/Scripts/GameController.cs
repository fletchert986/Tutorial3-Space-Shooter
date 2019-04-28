using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public GameObject boss;
    public GameObject bolt;
    public Vector3 spawnValues;
    public Vector3 spawnBoss;
    public Vector3 spawnBolt;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    private bool gameOver;
    private bool restart;
    private int score;

    public AudioSource game;
    /*public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;*/
    public AudioSource win;
    public AudioSource lose;

    private void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 10;
        UpdateScore();
        StartCoroutine (SpawnWaves());
        AudioSource[] audioSources = GetComponents<AudioSource>();
        //source = audioSources[0];
        /*clip1 = audioSources[0].clip;
        clip2 = audioSources[1].clip;
        clip3 = audioSources[2].clip;*/
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true) {
                while (score > 0 && score < 100)
                {
                    GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                    if (gameOver == true) break;
                }

            if (gameOver == true) break;
            yield return new WaitForSeconds(waveWait);
            if (score <= 0)
            {
                Vector3 spawnPosition = new Vector3(spawnBoss.x, spawnBoss.y, spawnBoss.z);
                Instantiate(boss, spawnBoss);
            }

                /*while (score >= 100 && score < 200)
                {
                    GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                    if (gameOver == true) break;
                }

                if (gameOver == true) break;
                yield return new WaitForSeconds(waveWait);*/

            while (score <= 0)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(bolt, spawnBolt);
                yield return new WaitForSeconds(spawnWait);
                if (gameOver == true) break;
            }
            

                if (gameOver)
                {
                    restartText.text = "Press 'F' for Restart";
                    restart = true;
                    break;
                }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
        if (score >= 200)
        {
            Win();
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Ships Left: " + score;
    }

    public void GameOver()
    {
        game.Stop();
        lose.Play();
        gameOverText.text = "Game Over";
        gameOver = true;
    }

    public void Win()
    {
        game.Stop();
        win.Play();
        gameOverText.text = "You Win!\n Game Created by Thomas Fletcher";
        gameOver = true;
    }
}
