using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class FloatScript : MonoBehaviour
{

    public float waterLevel = 0f;
    public float waterTreshold = 2f;
    public float waterDensity = 0.125f;
    public float downForce = 4f;

    private float forceFactor;
    private Vector3 floatForce;

    // Update is called once per frame
    void FixedUpdate()
    {
        forceFactor = 1.0f - ((transform.position.y - waterLevel) / waterTreshold);

        if (forceFactor > 0f)
        {
            floatForce = -Physics.gravity * GetComponent<Rigidbody>().mass * (forceFactor - GetComponent<Rigidbody>().velocity.y * waterDensity);
            floatForce += new Vector3(0f, -downForce * GetComponent<Rigidbody>().mass, 0f);
            GetComponent<Rigidbody>().AddForceAtPosition(floatForce, transform.position);
        }
    }
}
