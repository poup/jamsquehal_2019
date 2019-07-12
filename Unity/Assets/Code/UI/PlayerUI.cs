using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_score;


    public void SetScore(int score)
    {
        m_score.text = $"{score}";
    }
}
