using Code;
using UnityEngine;

public class TongueEnd : MonoBehaviour
{
    [SerializeField] private int m_playerId;
    [SerializeField] private TongueParams m_params;
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private HingeJoint m_joint;
    
    
    public void SetPlayerId(int playerId)
    {
        m_playerId = playerId;
    }
    
    private void FixedUpdate()
    {
        var playerId = m_playerId;
        var dt = Time.deltaTime;
        
        var param = m_params;
        var speed = param.moveSpeed;
        

        Vector3 direction = Inputs.GetAxis(playerId);
        var force = speed * direction;

//        if (direction.sqrMagnitude > 0.001f)
//        {
//            var angle = Mathf.Atan2(direction.y, direction.x);
//            Quaternion rotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
//            transform.rotation = rotation;
//        }

        rigidBody.AddForce(force, ForceMode.Impulse);
    }
    
    private void OnCollisionEnter(Collision other)
    {
//        if (other.contactCount > 0)
//        {
//            var contact = other.GetContact(0);
//            m_rigidBody.AddForceAtPosition(contact.point, contact.normal * m_tongueParams.repulseForce);
//        }
    }

    public void ConnectedTo(Rigidbody previousRb)
    {
        m_joint.connectedBody = previousRb;
    }
}
