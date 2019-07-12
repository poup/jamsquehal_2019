using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public Rigidbody rb;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        print("lololol");
    }

    // Update is called once per frame
    void Update()
    {
        if(Inputs.GetFire1(1))
        {
            rb.AddForce(new Vector3(Random.Range(-90f, 90f), Random.Range(-90f, 90f), 0));
        }
    }

    private void LateUpdate()
    {
        var rotationBefore = sr.transform.rotation.eulerAngles.z;
        sr.transform.LookAt(Camera.main.transform.position);
        var rotationAfter = transform.rotation.eulerAngles.z;
        sr.transform.Rotate(new Vector3(0, 0, 1), rotationAfter);
        if (Mathf.Abs(rotationBefore - rotationAfter) > 0.01)
        {
            print("rotation before : " + rotationBefore);
            print("rotation after : " + rotationAfter);
        }
    }
}
