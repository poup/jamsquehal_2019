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


        public void SetWinnerScore(int score)
        {
            textMeshPro.text = $"{score}";
        }

        public void Update()
        {
            if (Input.GetButtonDown(Inputs.Submit))
            {
                button.onClick.Invoke();
            }
        }
    }
}