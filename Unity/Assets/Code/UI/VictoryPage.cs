using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    public class VictoryPage : MonoBehaviour
    {
        public Button button;
        public SpriteRenderer spriteRenderer;
        public TextMeshProUGUI textMeshPro;


        public void SetWinner(int score, Color textColor, string anim)
        {
            textMeshPro.text = $"{score}";
            textMeshPro.color = textColor;
        }
    }
}