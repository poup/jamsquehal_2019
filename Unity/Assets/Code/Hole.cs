using System.Collections.Generic;
using Code;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public int playerId;
    public Color textColor;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Apple"))
        {
            var apple = other.gameObject.GetComponent<Apple>();
            if (apple != null)
            {
                var powerUpType = apple.powerUpType;
                var score = PowerUpUtils.GetScoreFor(powerUpType);
                UI.instance.gamePage.AddScore(playerId, score);

                PowerUpManager.instance.Activate(powerUpType, playerId);
                
                UI.instance.PlayFlyingText(other.transform.position, score.ToString("+#;-#;0"), textColor);
            }

            Destroy(other.gameObject);
        }
    }
}
