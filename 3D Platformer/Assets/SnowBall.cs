using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{

    public Vector3 initialSpawn;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        initialSpawn = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnowDeath"))
        {
            gameObject.SetActive(false);
            gameObject.transform.position = initialSpawn;
            gameObject.SetActive(true);
            rb.velocity = new Vector3(0f, 0f, 0f);
            rb.angularVelocity = new Vector3(0f, 0f, 0f);
        }
    }
}
