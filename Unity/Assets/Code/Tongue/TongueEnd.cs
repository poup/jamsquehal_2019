using Code;
using UnityEngine;

public class TongueEnd : MonoBehaviour
{
    [SerializeField] private TongueParams m_tongueParams;
    [SerializeField] private int m_playerId;
    
    
    public void SetPlayerId(int playerId)
    {
        m_playerId = playerId;
    }
    
    private void FixedUpdate()
    {
        var playerId = m_playerId;
        var dt = Time.deltaTime;
        
        var param = m_tongueParams;
        var speed = param.moveSpeed;
        
        var pos = transform.position;
        

        Vector3 direction = Inputs.GetAxis(playerId);
        pos += speed * dt * direction;

//        if (direction.sqrMagnitude > 0.001f)
//        {
//            var angle = Mathf.Atan2(direction.y, direction.x);
//            Quaternion rotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
//            transform.rotation = rotation;
//        }

        transform.position = pos;
    }
}
