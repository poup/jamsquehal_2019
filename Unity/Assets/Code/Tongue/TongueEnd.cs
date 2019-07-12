using System.Collections.Generic;
using Code;
using UnityEngine;

public class TongueEnd : MonoBehaviour
{
    
    public interface ITongueEndModifier : IPowerUp
    {
        Vector3 ModifyInput(Vector3 input);
        void Begin(TongueEnd tongueEnd);
        void End(TongueEnd tongueEnd);
        bool terminated { get; set; }
    }

    public class NoMove : ITongueEndModifier
    {
        public bool terminated { get; set; }
        public float startTime { get; set; }

        public Vector3 ModifyInput(Vector3 input)
        {
            return Vector3.zero;
        }

        public void Begin(TongueEnd tongueEnd)
        {
        }

        public void End(TongueEnd tongueEnd)
        {
        }
    } 
    
    public class InvertMove : ITongueEndModifier
    {
        public bool terminated { get; set; }
        public float startTime { get; set; }
        
        public Vector3 ModifyInput(Vector3 input)
        {
            return -input;
        }

        public void Begin(TongueEnd tongueEnd)
        {
        }

        public void End(TongueEnd tongueEnd)
        {
        }
    }
    
    public class SpeedUp : ITongueEndModifier
    {
        private readonly float speedUp ;
        private readonly float dragModifier;

        public SpeedUp(float speedUp, float dragModifier)
        {
            this.speedUp = speedUp;
            this.dragModifier = dragModifier;
        }

        public bool terminated { get; set; }
        public float startTime { get; set; }
        
        public Vector3 ModifyInput(Vector3 input)
        {
            return input * speedUp;
        }

        public void Begin(TongueEnd tongueEnd)
        {
            if(dragModifier != 0.0f)
                tongueEnd.rigidBody.drag *= dragModifier;
        }

        public void End(TongueEnd tongueEnd)
        {
            if(dragModifier != 0.0f)
                tongueEnd.rigidBody.drag /= dragModifier;
        }
    }
    
    [SerializeField] private int m_playerId;
    [SerializeField] private TongueParams m_params;
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private HingeJoint m_joint;

    
    private readonly List<ITongueEndModifier> m_modifiers = new List<ITongueEndModifier>();
    public int playerId => m_playerId;

    public void AddModifier(ITongueEndModifier modifier)
    {
        modifier.Begin(this);
        m_modifiers.Add(modifier);
    }


    public void SetPlayerId(int playerId)
    {
        m_playerId = playerId;
    }

    private void FixedUpdate()
    {
        var playerId = m_playerId;

        var param = m_params;
        var speed = param.moveSpeed;


        Vector3 direction = Inputs.GetAxis(playerId);
        var force = speed * direction;

        for (int i = m_modifiers.Count - 1; i >= 0; --i)
        {
            if (m_modifiers[i].terminated)
            {
                m_modifiers.RemoveAt(i);
            }
        }
        
        foreach (var modifier in m_modifiers)
        {
            force = modifier.ModifyInput(force);
        }

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

    public void Move(Vector3 delta)
    {
        rigidBody.AddForce(delta, ForceMode.Impulse);
        ;
    }
}