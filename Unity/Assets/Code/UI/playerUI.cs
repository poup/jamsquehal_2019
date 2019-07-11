using TMPro;
using UnityEngine;

public class playerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_score;


    public void SetScore(int score)
    {
        m_score.text = $"{score}";
    }
}
