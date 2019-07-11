using UnityEngine;

public class Billboard : MonoBehaviour
{
   
    private void LateUpdate()
    {
        var rotation = transform.rotation;
        rotation.x = 0;
        rotation.y = 0;
        transform.rotation = rotation;
    }
}
