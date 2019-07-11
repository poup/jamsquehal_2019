using UnityEngine;

namespace Code
{
    [CreateAssetMenu]
    public class TongueParams : ScriptableObject
    {
        public float width;
        public AnimationCurve curve;
        
        public float speed;
        
        
        [Header("springs")]
        public float minDistance = 1;
        public float maxDistance = 2;
        public float damper = 0.2f;
        public float spring = 50;
    }
}