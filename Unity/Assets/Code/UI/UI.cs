using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public PlayerUI player1;
    public PlayerUI player2;
    public PlayerUI player3;
    public PlayerUI player4;
    
    
    public TextMeshProUGUI m_timer;

    public static UI instance;

    public Action EndOfTimer;

    private void Awake()
    {
        instance = this;
    }

    public void StartTimer(float duration)
    {
        StartCoroutine(Timer(duration));
    }

    private IEnumerator Timer(float duration)
    {

        while (duration > 0)
        {
            m_timer.text = new TimeSpan(0, 0, (int)duration).ToString("mm:ss");
            yield return new WaitForSeconds(1.0f);
            duration -= 1.0f;
        }

        EndOfTimer?.Invoke();
    }

    public void SetScore(int playerId, int score)
    {
        var ui = GetPlayer(playerId);
        if(ui != null)
            ui.SetScore(score);
    }

    private PlayerUI GetPlayer(int playerId)
    {
        switch (playerId)
        {
            case 1: return player1;
            case 2: return player2;
            case 3: return player3;
            case 4: return player4;
        }

        return null;
    }
}
