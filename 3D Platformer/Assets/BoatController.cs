using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (FloatScript))]
public class BoatController : MonoBehaviour
{
    public Vector3 COM;
    public PlayerController player;
    [Space(15)]
    public float speed = 1f;
    public float steerSpeed = 1f;
    public float movementThreshold = 10f;
    public Rigidbody rb;



    private Transform m_COM;
    private float verticalInput;
    private float movementFactor;
    private float horizontalInput;
    private float steerFactor;
    private bool canSteer;


    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        Balance();
        if (canSteer)
        {
            Movement();
            Steering();
        }
    }

    private void Balance()
    {
        if (!m_COM)
        {
            m_COM = new GameObject("COM").transform;
            m_COM.SetParent(transform);
            
        }

        m_COM.position = COM;
        GetComponent<Rigidbody>().centerOfMass = m_COM.position;
    }

    private void Movement()
    {
        verticalInput = Input.GetAxis("Vertical");
        movementFactor = Mathf.Lerp(movementFactor, verticalInput, Time.deltaTime / movementThreshold);
        transform.Translate(0f, movementFactor * speed, 0f);
        
    }

    private void Steering()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        steerFactor = Mathf.Lerp(steerFactor, -horizontalInput * verticalInput, Time.deltaTime / movementThreshold);
        transform.Translate(steerFactor * steerSpeed, 0f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canSteer = true;
            player.controller.velocity.Set(rb.velocity.x, rb.velocity.y, rb.velocity.z);
            player.controller.transform.position = transform.position + new Vector3(2f, 3f, 0f);

            // player.moveSpeed = 0f;
            // player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canSteer = false;
            player.moveSpeed = player.t_moveSpeed;

           // player.transform.parent = null;
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //canSteer = true;
            player.moveSpeed = 0f;
            player.controller.velocity.Set(rb.velocity.x, rb.velocity.y, rb.velocity.z);
            player.controller.transform.position = transform.position + new Vector3(2f, 3f, 0f);
             player.transform.parent = transform;
        }
    }
}
