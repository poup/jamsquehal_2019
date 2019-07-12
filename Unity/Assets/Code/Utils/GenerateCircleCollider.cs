using UnityEngine;

public class GenerateCircleCollider : MonoBehaviour
{
    public int radius = 4;
    public int count = 36;
    public Vector3 colliderCenter = Vector3.zero;
    public Vector3 colliderSize = Vector3.one;


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius-colliderSize.x*0.5f);
    }

    [ContextMenu("Create cooliders")]
    private void Create()
    {
        var angleDeg = 360 / (float)count;
        var angleRad = angleDeg*Mathf.Deg2Rad;
        
        for (int i = 0; i < count; ++i)
        {
            var x = radius * Mathf.Cos(angleRad * i);
            var y = radius * Mathf.Sin(angleRad * i);
            
            var c = new GameObject("collider_" +i);
            c.transform.SetParent(transform);
            c.transform.localPosition = new Vector3(x, y, 0);
            c.transform.localRotation = Quaternion.AngleAxis(i*angleDeg, new Vector3(0, 0, 1));
            
            var collider = c.AddComponent<BoxCollider>();
            collider.center = colliderCenter;
            collider.size = colliderSize;
        }
    }
}
