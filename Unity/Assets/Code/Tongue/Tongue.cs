using Code;
using UnityEngine;

public class Tongue : MonoBehaviour
{
    [Header("parameters")]
    [SerializeField] private int m_playerId;
    [SerializeField] private TongueParams m_tongueParams;
    [SerializeField] private Bone m_bonePrefab;
    
    [SerializeField] private int m_partCount;
    
    private Transform m_end;
    private Bone[] m_bones;
    


    private void SetPlayer(int playerId)
    {
        m_playerId = playerId;
    }


    private void Awake()
    {
        m_bones = new Bone[m_partCount];
        
        Transform parent = transform; 
        for (int i = 0; i < m_partCount; ++i)
        {
            var bone = Instantiate(m_bonePrefab);
            bone.name = "bone_" + i;
            Transform boneTransform = bone.transform;

            bone.index = i;
            bone.partCount = m_partCount;
            bone.tongueParams = m_tongueParams;
            
            boneTransform.SetParent(parent);
            boneTransform.localPosition = new Vector3(0, 0, 1); 
            boneTransform.localRotation = Quaternion.identity; 
            boneTransform.localScale = Vector3.one; 
            
            m_bones[i] = bone;

            parent = boneTransform;
        }

        
        m_end = m_bones[m_partCount - 1].transform;
    }

    private void FixedUpdate()
    {
        var playerId = m_playerId;
        var dt = Time.deltaTime;
        
        var param = m_tongueParams;
        var speed = param.speed;
        
        var position = m_end.position;
        

        Vector3 direction = Inputs.GetAxis(playerId);
        position += speed * dt * direction;

        if (direction.sqrMagnitude > 0.001f)
        {
            var angle = Mathf.Atan2(direction.y, direction.x);
            Quaternion rotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
            m_end.rotation = rotation;
        }

        m_end.position = position;
    }
}
