using System;
using UnityEngine;

namespace Code
{
    public class Bone : MonoBehaviour
    {
        [SerializeField] private MeshFilter m_meshFilter;
        [SerializeField] private MeshCollider m_collider;
        [SerializeField] private Rigidbody m_rigidBody;
        [SerializeField] public SpringJoint m_spring;


        public TongueParams tongueParams;

        private Mesh m_mesh;
        private MeshRenderer m_meshRenderer;
        private Vector3[] m_vertices;


        [HideInInspector] public int index;
        [HideInInspector] public int partCount;


        private void Awake()
        {
            m_spring.autoConfigureConnectedAnchor = false;
            m_spring.anchor = Vector3.zero;
            m_spring.enableCollision = true;

            m_vertices = new Vector3[4];

            m_mesh = new Mesh();
            m_mesh.vertices = m_vertices;
            m_mesh.triangles = CreateTriangles();
            m_mesh.uv = CreateUVs(index);

            m_meshFilter.mesh = m_mesh;
            m_collider.sharedMesh = m_mesh;
        }

        private void Start()
        {
            m_spring.connectedBody = transform.parent.GetComponent<Rigidbody>();
        }

        // debug
        private void Update()
        {
            m_spring.minDistance = tongueParams.minDistance;
            m_spring.maxDistance = tongueParams.maxDistance;
            m_spring.spring = tongueParams.spring;
            m_spring.damper = tongueParams.damper;

            if (index == 0)
            {
                m_spring.tolerance = 1.0f;
                m_spring.connectedMassScale = 10.0f;
                m_rigidBody.constraints = RigidbodyConstraints.FreezePosition;
            }
        }

        private void FixedUpdate()
        {
            m_mesh.vertices = UpdateVertices();
            m_collider.sharedMesh = m_mesh;
        }


        private Vector3[] UpdateVertices()
        {
            var curve = tongueParams.curve;
            var halfWidth = tongueParams.width * 0.5f;

            var vertices = m_vertices;

            var p = index;
            var bounds = transform;

            var w0 = curve.Evaluate(p / (float) partCount) * halfWidth;
            var w1 = curve.Evaluate((p + 1) / (float) partCount) * halfWidth;


            var pos = Vector3.zero; //bounds.position;

            var right = bounds.right;

            Vector3 v0 = pos - right * w0;
            Vector3 v1 = pos + right * w0;


            Vector3 v2;
            Vector3 v3;
            if (transform.childCount > 0)
            {
                Transform next = transform.GetChild(0);

                var posNext = next.position - bounds.position;

                v2 = posNext - right * w1;
                v3 = posNext + right * w1;

                var nextRight = next.right;
                var nextV2 = posNext - nextRight * w1;
                var nextV3 = posNext + nextRight * w1;

                v2 = (v2 + nextV2) * 0.5f;
                v3 = (v3 + nextV3) * 0.5f;
            }
            else
            {
                var posNext = pos + transform.forward;
                v2 = posNext - right * w1;
                v3 = posNext + right * w1;
            }


            var v = 0;
            
            vertices[v] = v0;
            vertices[v + 1] = v1;
            vertices[v + 2] = v2;
            vertices[v + 3] = v3;

            return vertices;
        }


        private int[] CreateTriangles()
        {
            var tris = new int[6];

            var k = 0;
            for (int i = 0;i < tris.Length;i += 6)
            {
                tris[i] = k;
                tris[i + 1] = k + 2;
                tris[i + 2] = k + 1;

                tris[i + 3] = k + 2;
                tris[i + 4] = k + 3;
                tris[i + 5] = k + 1;

                k += 4;
            }

            return tris;
        }


        private Vector2[] CreateUVs(int partCount)
        {
            float r = 1.0f / partCount;
            var k = index;

            var uv = new Vector2[4];
            for (int i = 0; i < uv.Length; i += 2)
            {
                var y = k * r;

                uv[i] = new Vector2(0, y);
                uv[i + 1] = new Vector2(1, y);

                k++;
            }

            return uv;
        }
    }
}