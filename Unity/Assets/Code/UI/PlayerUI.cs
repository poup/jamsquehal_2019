using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public int playerId;
    public TextMeshProUGUI m_score;
    public int scoreValue;


    public void AddScore(int score)
    {
        SetScore(scoreValue + score);
    } 
    
    public void SetScore(int score)
    {
        scoreValue = score;
        m_score.text = $"{score}";
    }

    public void Reset()
    {
        SetScore(0);
    }
}
