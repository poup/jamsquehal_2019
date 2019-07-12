using Code;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public int playerId;
    
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
            }

            Destroy(other.gameObject);
        }
    }
}
