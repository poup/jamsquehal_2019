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


    private bool m_running;
    private bool m_autoMoveOut;
    private Vector3 m_targetPosition;

    private TongueSection[] m_sections;
    
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

        m_sections = new TongueSection[param.sectionCount];
        m_startRigidBody = m_tongueStart.GetComponent<Rigidbody>();
        var previousRB = m_startRigidBody; 
        
        for (int i = 0; i < param.sectionCount; ++i)
        {
            var section = Instantiate(m_sectionPrefab, m_sectionDummy);
            m_sections[i] = section;
            section.index = i;
            section.SetParam(m_params);
            section.ConnectedTo(previousRB);
            previousRB = section.rigidBody;
        }
        
        m_tongueStart.position = m_minPoint.position;
        m_tongueEnd.SetPlayerId(m_playerId);
        m_tongueEnd.ConnectedTo(previousRB);
    }

    private enum AutoMove
    {
        GoIn, GoOut, None
    }
    
    private AutoMove m_autoMove = AutoMove.None;
    private Rigidbody m_startRigidBody;


    private float m_lastIn;

    private void FixedUpdate()
    {
        if (!m_running)
        {
            return;
        }

        if (m_autoMove == AutoMove.None)
        {
            m_autoMove = AutoMove.GoOut;
            m_targetPosition = m_maxPoint.position;
        }
        
        if (Inputs.GetFire1(m_playerId))
        {
            if (m_autoMove == AutoMove.None || Time.fixedTime-m_lastIn  > m_params.coolDownIn)
            {
                m_lastIn = Time.fixedTime;
                m_autoMove = AutoMove.GoIn;
                m_targetPosition = m_minPoint.position;
            }
        }

        Vector3 currentPos = m_startRigidBody.position;
        var delta = m_targetPosition - currentPos;

        if (delta.sqrMagnitude < 0.001f || m_autoMove == AutoMove.None)
        {
            m_autoMove = AutoMove.None;
            m_startRigidBody.MovePosition(m_targetPosition);
        }
        else
        {
            var speed = m_autoMove == AutoMove.GoIn ? m_params.inSpeed : m_params.outSpeed;
            currentPos += speed * Time.fixedDeltaTime * delta;
            m_startRigidBody.MovePosition(currentPos);
            m_tongueEnd.Move(delta);
            //m_tongueStart.position = currentPos;
        }
    }

}