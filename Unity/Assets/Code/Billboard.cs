using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera m_camera;
    
    // Start is called before the first frame update
    void Start()
    {
        m_camera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var rotation = transform.rotation;
        rotation.x = 0;
        rotation.y = 0;
        transform.rotation = rotation;
    }
}
