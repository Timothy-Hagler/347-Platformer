using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public PlayerController player;
    public float speed;
    Rigidbody rb;
    // Start is called before the first frame update

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        Vector3 pos = rb.position;
        rb.position += Vector3.back * speed * Time.fixedDeltaTime;
        rb.MovePosition(pos);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Vector3 pos = player.transform.position;
            player.transform.position += Vector3.back * speed * Time.fixedDeltaTime;
           // player.transform.position += 
        }
    }



}
