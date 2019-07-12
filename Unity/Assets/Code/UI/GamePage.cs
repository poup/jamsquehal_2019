using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Code.UI
{
    public class GamePage : MonoBehaviour
    {
        
        public PlayerUI player1;
        public PlayerUI player2;
        public PlayerUI player3;
        public PlayerUI player4;
    
        public TextMeshProUGUI m_timer;
        
        
        
        public Action EndOfTimer;

        
        public void StartTimer(float duration)
        {
            StartCoroutine(Timer(duration));
        }

        private IEnumerator Timer(float duration)
        {

            duration += 0.5f;
            while (duration > 0)
            {
                m_timer.text = new TimeSpan(0, 0, (int)duration).ToString(@"mm\:ss");
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

        public PlayerUI GetWinner()
        {
            PlayerUI winner = null;
            int score = -1;

            if (player1.scoreValue > score)
            {
                score = player1.scoreValue;
                winner = player1;
            }
            if (player2.scoreValue > score)
            {
                score = player2.scoreValue;
                winner = player2;
            }
            if (player3.scoreValue > score)
            {
                score = player3.scoreValue;
                winner = player3;
            }
            if (player4.scoreValue > score)
            {
                score = player4.scoreValue;
                winner = player4;
            }

            return winner;
        }

        public void Reset()
        {
            m_timer.text = "00:00";
            player1.Reset();
            player2.Reset();
            player3.Reset();
            player4.Reset();
        }
    }
}