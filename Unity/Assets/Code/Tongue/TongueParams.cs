using UnityEngine;

namespace Code
{
    [CreateAssetMenu]
    public class TongueParams : ScriptableObject
    {
        public float moveSpeed;
        public float outSpeed;
        public float sectionCount = 50;
        
        
        public float repulseForce = 0.01f;
        public Vector3 conectedAnchor = new Vector3(0, 0.2f, 0);


    }
}