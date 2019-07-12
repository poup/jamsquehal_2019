using TMPro;
using UnityEngine;

public class FlyingText : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI m_tmp;
   [SerializeField] private Animation m_animation;



   private bool m_running;
   public void Play(string text, Color color)
   {
      m_running = true;
      
      m_tmp.text = text;
      m_tmp.color = color;
      m_animation.Play();
   }

   public void LateUpdate()
   {
      if (m_running && !m_animation.isPlaying)
      {
         Destroy(gameObject);
      }
   }
}
