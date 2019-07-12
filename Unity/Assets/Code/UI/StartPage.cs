using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    public class StartPage : MonoBehaviour
    {
        public Button playButton;


        void Update()
        {
            if (Input.GetButtonDown(Inputs.Submit))
            {
                playButton.onClick.Invoke();
            }
        }
    }
}