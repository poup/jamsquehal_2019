using System;
using System.Collections;
using System.Collections.Generic;
using Code;
using Code.UI;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public float durationSeconds = 60;
    public float startRegularSpawnAfterNSeconds = 5f;
    public float regularInterval = 2f;
    public int regularCount = 2;

    public StartPage startPage;
    public GamePage gamePage;
    public VictoryPage victoryPage1;
    public VictoryPage victoryPage2;
    public VictoryPage victoryPage3;
    public VictoryPage victoryPage4;
    public Canvas canvas;

    public FlyingText flyingTextPrefab;

    public static UI instance;

    public Board board;

    private void Awake()
    {
        instance = this;

        startPage.gameObject.SetActive(true);
        gamePage.gameObject.SetActive(false);
        victoryPage1.gameObject.SetActive(false);
        victoryPage2.gameObject.SetActive(false);
        victoryPage3.gameObject.SetActive(false);
        victoryPage4.gameObject.SetActive(false);

        startPage.playButton.onClick.AddListener(() =>
        {
            StartGame();
            startPage.gameObject.SetActive(false);
        });


        gamePage.EndOfTimer = OnEndOfTimer;

        victoryPage1.button.onClick.AddListener(Replay);
        victoryPage2.button.onClick.AddListener(Replay);
        victoryPage3.button.onClick.AddListener(Replay);
        victoryPage4.button.onClick.AddListener(Replay);

//        
//// TODO : remove ME
//        startPage.gameObject.SetActive(false);
//        
//        victoryPage1.gameObject.SetActive(false);
//        victoryPage2.gameObject.SetActive(false);
//        victoryPage3.gameObject.SetActive(false);
//        victoryPage4.gameObject.SetActive(false);
//        
//        StartGame();
//// end TODO
    }

    private void Replay()
    {
        gamePage.Reset();

        victoryPage1.gameObject.SetActive(false);
        victoryPage2.gameObject.SetActive(false);
        victoryPage3.gameObject.SetActive(false);
        victoryPage4.gameObject.SetActive(false);

        StartGame();
    }

    private void StartGame()
    {
        gamePage.gameObject.SetActive(true);

        board.Clear();

        StartCoroutine(StartGameCoroutine());
    }

    private IEnumerator StartGameCoroutine()
    {
        yield return new WaitForSecondsRealtime(board.timeBeforePomme);
        board.appleSpawner.StartSpawn(board.StartPommeCount);
        yield return new WaitForSecondsRealtime(0.5f);
        gamePage.StartTimer(durationSeconds);
        yield return new WaitForSecondsRealtime(startRegularSpawnAfterNSeconds);
        board.appleSpawner.StartRegularSpawn(regularCount, regularInterval, durationSeconds - startRegularSpawnAfterNSeconds);
    }

    private void OnEndOfTimer()
    {
        Sound.GameStop();

        var winner = gamePage.GetWinner();
        if (winner != null)
        {
            var victoryPage = GetVictoryPage(winner.playerId);
            victoryPage.SetWinnerScore(winner.scoreValue);
            victoryPage.gameObject.SetActive(true);
        }
        else
        {
            startPage.gameObject.SetActive(true);
        }
    }

    private VictoryPage GetVictoryPage(int playerId)
    {
        switch (playerId)
        {
            case 1: return victoryPage1;
            case 2: return victoryPage2;
            case 3: return victoryPage3;
            case 4: return victoryPage4;
        }

        return null;
    }

    public void PlayFlyingText(Vector3 worldPos, string text, Color color)
    {
        var f = Instantiate(flyingTextPrefab, transform);
        
        var viewportPoint = Camera.main.WorldToViewportPoint(worldPos);  

        var rectTransform = (RectTransform)f.transform;
        rectTransform.anchorMin = viewportPoint;  
        rectTransform.anchorMax = viewportPoint; 
        
        f.Play(text, color);
    }
}