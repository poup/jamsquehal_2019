using System;
using System.Collections;
using System.Collections.Generic;
using Code.UI;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public float durationSeconds = 60;
    
    public StartPage startPage;
    public GamePage gamePage;
    public VictoryPage victoryPage1;
    public VictoryPage victoryPage2;
    public VictoryPage victoryPage3;
    public VictoryPage victoryPage4;

    public static UI instance;

    private void Awake()
    {
        instance = this;
        
        startPage.gameObject.SetActive(true);
//        gamePage.gameObject.SetActive(false);
//        victoryPage1.gameObject.SetActive(false);
//        victoryPage2.gameObject.SetActive(false);
//        victoryPage3.gameObject.SetActive(false);
//        victoryPage4.gameObject.SetActive(false);
//        
        startPage.playButton.onClick.AddListener(() =>
        {
            gamePage.gameObject.SetActive(true);
            gamePage.StartTimer(durationSeconds);
            
            startPage.gameObject.SetActive(false);
            
            
            // TODO charger la scene du board
            
        });
//

        gamePage.EndOfTimer = OnEndOfTimer;
        
        victoryPage1.button.onClick.AddListener(Replay);
        victoryPage2.button.onClick.AddListener(Replay);
        victoryPage3.button.onClick.AddListener(Replay);
        victoryPage4.button.onClick.AddListener(Replay);

        
// TODO : remove ME
        startPage.gameObject.SetActive(false);
        gamePage.gameObject.SetActive(true);
        
        victoryPage1.gameObject.SetActive(false);
        victoryPage2.gameObject.SetActive(false);
        victoryPage3.gameObject.SetActive(false);
        victoryPage4.gameObject.SetActive(false);
        
        gamePage.StartTimer(durationSeconds);
// end TODO
        
    }

    private void Replay()
    {
        gamePage.gameObject.SetActive(false);
        gamePage.Reset();
        
        victoryPage1.gameObject.SetActive(false);
        victoryPage2.gameObject.SetActive(false);
        victoryPage3.gameObject.SetActive(false);
        victoryPage4.gameObject.SetActive(false);
        
        gamePage.StartTimer(durationSeconds);
        
        // TODO décharger la scene du board
        
        // TODO charger la scene du board
    }

    private void OnEndOfTimer()
    {
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
}
