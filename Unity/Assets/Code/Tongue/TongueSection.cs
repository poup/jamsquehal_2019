using Code;
using UnityEngine;

public class TongueSection : MonoBehaviour
{
    [SerializeField] protected TongueParams m_params;
    [SerializeField] private BoxCollider m_collider;
    [SerializeField] private HingeJoint m_joint;

    public int index;

    public Rigidbody rigidBody;

    public void SetParam(TongueParams param)
    {
        m_params = param;
        RefreshParams();
    }

    private void RefreshParams()
    {
        var param = m_params;
    }

    private void Update()
    {
        RefreshParams();
    }

    private void OnCollisionEnter(Collision other)
    {
//        if (other.contactCount > 0)
//        {
//            var contact = other.GetContact(0);
//            rigidBody.AddForceAtPosition(contact.point, contact.normal * m_params.repulseForce);
//        }
    }

    public void ConnectedTo(Rigidbody previousRb)
    {
        m_joint.connectedBody = previousRb;
        m_joint.connectedAnchor = m_params.conectedAnchor;
    }
}