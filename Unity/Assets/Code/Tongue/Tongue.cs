using System;
using System.Collections;
using System.Collections.Generic;
using Code;
using UnityEngine;

public class Tongue : MonoBehaviour
{
    
    [SerializeField] private int m_playerId;
    
    [SerializeField] private TongueSection m_sectionPrefab;
    [SerializeField] private TongueParams m_params;
    
    [Space(10)]
    [SerializeField] private Transform m_sectionDummy;
    [SerializeField] private TongueEnd m_tongueEnd;
    [SerializeField] private Transform m_tongueStart;
    
    [Space(10)]
    [SerializeField] private Transform m_minPoint;
    [SerializeField] private Transform m_maxPoint;

    public int m_visibleCount;

    private bool m_running;
    private bool m_autoMoveOut;
    private Vector3 m_targetPosition;
    
    public void StartRunning()
    {
        m_running = true;
        m_autoMoveOut = true;
    } 
    
    public void StopRunning()
    {
        m_running = false;
        m_autoMoveOut = false;
    }

    private void OnEnable()
    {
        StartRunning();
    }

    private void Awake()
    {
        var param = m_params;

        var previousRB = m_tongueStart.GetComponent<Rigidbody>();
        
        for (int i = 0; i < param.sectionCount; ++i)
        {
            var section = Instantiate(m_sectionPrefab, m_sectionDummy);
            section.index = i;
            section.SetParam(m_params);
            section.ConnectedTo(previousRB);
            previousRB = section.rigidBody;
        }

        m_tongueStart.position = m_minPoint.position;
        m_tongueEnd.SetPlayerId(m_playerId);
        m_tongueEnd.ConnectedTo(previousRB);
    }

    private bool m_canIn;
    private float m_startIn;
    
    private void FixedUpdate()
    {
        if (!m_running)
        {
            return;
        }
        
        
        if (m_autoMoveOut)
        {
            m_targetPosition = m_maxPoint.position;
        }

        
        if (Inputs.GetFire1(m_playerId))
        {
            var currentTime = Time.fixedTime;
            m_targetPosition = m_minPoint.position;
        }

        Vector3 currentPos = m_tongueStart.position;
        var delta = m_targetPosition - currentPos;

        var startRigidBody = m_tongueStart.GetComponent<Rigidbody>();
        
        if (delta.sqrMagnitude < 0.001f)
        {
            startRigidBody.MovePosition(m_targetPosition);
        }
        else
        {
            currentPos += m_params.outSpeed * Time.fixedTime * delta;
            startRigidBody.MovePosition(currentPos);
            //m_tongueStart.position = currentPos;
        }
    }
}
