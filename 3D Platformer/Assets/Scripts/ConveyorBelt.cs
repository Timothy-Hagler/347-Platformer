using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public PlayerController player;
    public float speed;
    Rigidbody rb;
    private Collider col;
    // Start is called before the first frame update

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (col != null)
        {
           // Debug.Log("Not null");
           // Vector3 pos = player.transform.position;
           // player.moveDirection = pos + Vector3.back * speed * Time.fixedDeltaTime;

            if (player.speed.speedActive)
            {
                player.moveSpeed = 5;
            }
            if (!player.speed.speedActive)
            {
                player.moveSpeed = 0.25f;
            }
        }
    }

    private void FixedUpdate()
    {
        Vector3 pos = rb.position;
        rb.position += Vector3.back * speed * Time.fixedDeltaTime;
        rb.MovePosition(pos);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            col = player.GetComponent<Collider>();
            Debug.Log("Player");
            // Vector3 pos = player.transform.position;
            // player.transform.position += Vector3.back * speed * Time.fixedDeltaTime;
            // player.transform.position += 
            
           // player.moveDirection = pos + Vector3.back * speed * Time.fixedDeltaTime;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            col = null;
            player.moveSpeed = player.t_moveSpeed;
        }
    }



}
