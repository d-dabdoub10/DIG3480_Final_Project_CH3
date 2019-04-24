﻿using System.Collections; using System.Collections.Generic;
using UnityEngine; using UnityEngine.UI;  public class GameController : MonoBehaviour {     public GameObject[] asteroids;     public Vector3 spawnValues;     public int asteroidCount;     public float startWait;     public float spawnWait;     public float waveWait;     public Text scoreText;     public Text restartText;     public Text gameOverText;     public Text winText;     public bool winCondition = false;     public bool hardMode;      private int score;     private bool gameOver;     private bool restart;     private float speed;      //Audio     private AudioSource audioSource;     public AudioClip winSound;     public AudioClip loseSound;      void Start()     {         hardMode = false;         score = 0;         UpdateScore();          gameOver = false;         gameOverText.text = "";          restart = false;         restartText.text = "";          StartCoroutine(SpawnWaves());          audioSource = GetComponent<AudioSource>();     }      void Update()     {         if (restart)         {             if (Input.GetKeyDown(KeyCode.N))             {                 Application.LoadLevel(Application.loadedLevel);             }         }      }      IEnumerator SpawnWaves()     {
        yield return new WaitForSeconds(startWait);          while (true)         {             for (int i = 0; i < asteroidCount; i++)             {                 GameObject asteroid = asteroids[Random.Range(0, asteroids.Length)];                  Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);                 Quaternion spawnRotation = Quaternion.identity;                                  Instantiate(asteroid, spawnPosition, spawnRotation);                  if (hardMode == true)                  {                     speed = asteroid.GetComponent<Mover>().speed;                 }                  yield return new WaitForSeconds(spawnWait);             }              yield return new WaitForSeconds(waveWait);              if (gameOver)             {                 restart = true;                 restartText.text = "Press 'N' to Restart";                 break;             }         }     }      void UpdateScore()     {
             scoreText.text = "Score: " + score;             if (score >= 100)             {                 winText.text = "You win!";                 gameOver = true;                 restart = true;                 audioSource.PlayOneShot(winSound, 1);                 winCondition = true;             }
            scoreText.text = "Score: " + score.ToString();     }     public void AddScore(int newScoreValue)     {         score += 5;         UpdateScore();     }      public void GameOver()     {         gameOver = true;         gameOverText.text = "GAME OVER & Created by Daniel Dabdoub!";         audioSource.PlayOneShot(loseSound, 1);     } } 