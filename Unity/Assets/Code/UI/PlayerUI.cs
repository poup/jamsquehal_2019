using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI m_score;
    public int scoreValue;


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
