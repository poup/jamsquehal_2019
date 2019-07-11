using UnityEngine;

namespace Code
{
    [CreateAssetMenu]
    public class TongueParams : ScriptableObject
    {
        public float moveSpeed = 10;
        public float outSpeed = 0.01f;
        public float inSpeed = 0.01f;
        public float sectionCount = 60;
        public float minCount = 50;
        
        
        public float repulseForce = 0.01f;
        public Vector3 conectedAnchor = new Vector3(0, 0.2f, 0);


    }
}