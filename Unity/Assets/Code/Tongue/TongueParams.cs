using UnityEngine;

namespace Code
{
    [CreateAssetMenu]
    public class TongueParams : ScriptableObject
    {
        public float width;
        public float moveSpeed;
        public float outSpeed;
        public float sectionLength = 0.05f;
        public float sectionCount = 50;
    }
}