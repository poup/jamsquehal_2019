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
    public VictoryPage victoryPage;

    public static UI instance;

    private void Awake()
    {
        instance = this;
        
//        startPage.gameObject.SetActive(true);
//        gamePage.gameObject.SetActive(false);
//        victoryPage.gameObject.SetActive(false);
//        
//        startPage.playButton.onClick.AddListener(() =>
//        {
//            gamePage.gameObject.SetActive(true);
//            gamePage.StartTimer(durationSeconds);
//            
//            startPage.gameObject.SetActive(false);
//            
//            
//            // TODO charger la scene du board
//            
//        });
//

// TODO : remove ME
        startPage.gameObject.SetActive(false);
        gamePage.gameObject.SetActive(true);
        victoryPage.gameObject.SetActive(false);
            gamePage.StartTimer(durationSeconds);

        gamePage.EndOfTimer = OnEndOfTimer;
    }

    private void OnEndOfTimer()
    {
        var winner = gamePage.GetWinner();
        if (winner != null)
        {
            victoryPage.SetWinner(winner.scoreValue, winner.m_score.color, null);
        }
        
        victoryPage.gameObject.SetActive(true);
        gamePage.gameObject.SetActive(false);
        gamePage.Reset();
        
        // TODO décharger la scene du board
    }
}
