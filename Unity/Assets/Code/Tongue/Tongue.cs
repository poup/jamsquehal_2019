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


    private bool m_move;
    private Vector3 m_targetPosition;
    
    public void StartMove()
    {
        m_move = true;
        
    }

    private void Awake()
    {
        var param = m_params;

        for (int i = 0; i < param.sectionCount; ++i)
        {
            var section = Instantiate(m_sectionPrefab, m_sectionDummy);
            section.SetParam(m_params);
            
        }

        m_tongueStart.position = m_minPoint.position;
        m_tongueEnd.SetPlayerId(m_playerId);
    }

    private void FixedUpdate()
    {
        if (m_move)
        {
            m_targetPosition = m_maxPoint.position;
        }


        Vector3 startPosition = m_tongueStart.position;
        var delta = m_targetPosition - startPosition;
        startPosition += m_params.outSpeed * Time.fixedTime * delta;
        m_tongueStart.position = startPosition;
        
        if (Inputs.GetFire1(m_playerId))
        {
            
        }
    }
}
