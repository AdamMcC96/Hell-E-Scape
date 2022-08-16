using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject enemyContainer, hudContainer, gameOverPanel;
    public Text enemyCounter, timeCounter, endTime, countdownText;
    public bool gamePlaying { get; private set; }
    public int countdownTime;

    private int totalEnemies, killedEnemies;
    private float startTime, elapsedTime;
    TimeSpan timePlaying;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        totalEnemies = enemyContainer.transform.childCount;
        killedEnemies = 0;
        enemyCounter.text = "Enemies: 0 / " + totalEnemies;

        gamePlaying = false;

        StartCoroutine(CountdownToStart());
    }
    private void BeginGame()
    {
        gamePlaying = true;
        startTime = Time.time;
    }
    private void Update()
    {
        if (gamePlaying)
        {
            elapsedTime = Time.time - startTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);

            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;
        }
    }
    public void KillEnemy()
    {
        killedEnemies++;
        string enemyCounterStr = "Enemies: " + killedEnemies + " / " + totalEnemies;
        enemyCounter.text = enemyCounterStr;
        if(killedEnemies >= totalEnemies)
        {
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            endTime.text = timePlayingStr;
            EndGame();
        }

    }
    private void EndGame()
    {
        gamePlaying = false;
        Invoke("ShowGameOverScreen", 1.25f);
        
    }
    private void ShowGameOverScreen()
    {
        gameOverPanel.SetActive(true);
        hudContainer.SetActive(false);
    }

    IEnumerator CountdownToStart()
    {
        while(countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        BeginGame();
        countdownText.text = "GO!";
        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false);
    }
}
