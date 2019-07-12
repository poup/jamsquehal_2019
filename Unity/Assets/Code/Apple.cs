using System.Collections;
using System.Collections.Generic;
using Code;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public Rigidbody rb;
    public SpriteRenderer sr;

    public PowerUpType powerUpType;
    
    void Update()
    {
        // debug
        if(Inputs.GetDebug() > 0.05)
        {
            rb.AddForce(new Vector3(Random.Range(-90f, 90f), Random.Range(-90f, 90f), 0));
        }
    }
    
    private void LateUpdate()
    {
        var rotation = transform.rotation;
        rotation.x = 0;
        rotation.y = 0;
        transform.rotation = rotation;
    }
}
