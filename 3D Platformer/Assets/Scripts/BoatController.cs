using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (FloatScript))]
public class BoatController : MonoBehaviour
{
    public GameObject COM;
    public PlayerController player;
    [Space(15)]
    public float speed = 1f;
    public float steerSpeed = 1f;
    public float movementThreshold = 10f;
    public Rigidbody rb;
    public GameObject trigger;



    private Transform m_COM;
    private float verticalInput;
    private float movementFactor;
    private float horizontalInput;
    private float steerFactor;
    public  bool canSteer;


    /*private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody>();
    }*/

    private void Awake()
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
            player.transform.position = trigger.transform.position;
            player.transform.localPosition = new Vector3(0f, 2f, 0f);
            
            
            Movement();
            Steering();
        }
    }

    private void Balance()
    {
        if (!m_COM)
        {
            //  m_COM = 
           // GameObject COM = new GameObject("COM");
            COM.transform.position = trigger.transform.position;
            m_COM = COM.transform;
            m_COM.SetParent(transform);
            
        }

        m_COM.position = COM.transform.position;
        GetComponent<Rigidbody>().centerOfMass = m_COM.localPosition;
    }

    private void Movement()
    {
        verticalInput = Input.GetAxis("Vertical");
        movementFactor = Mathf.Lerp(movementFactor, verticalInput, Time.deltaTime / movementThreshold);
        transform.Translate(0f, movementFactor * speed * Time.deltaTime, 0f);
        // player.moveDirection = (new Vector3(0f, movementFactor * speed, 0f));
        player.controller.velocity.Set(0f, movementFactor * speed * Time.deltaTime, 0f);
       // player.transform.Translate(0f, movementFactor * speed * Time.deltaTime, 0f);





    }
   
    private void Steering()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        steerFactor = Mathf.Lerp(steerFactor, horizontalInput * verticalInput, Time.deltaTime / movementThreshold);
        //transform.Translate(steerFactor * steerSpeed, 0f, 0f);
        transform.Rotate(0f, 0f, steerFactor * steerSpeed);
        //player.transform.Translate(steerFactor * steerSpeed * Time.deltaTime, 0f, 0f);
        //player.controller.velocity.Set(0f, steerFactor * steerSpeed, 0f);
        player.transform.Rotate(0f, steerFactor * steerSpeed, 0f);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           // PlayerController.inputEnabled = false;

           player.transform.parent = trigger.transform;
           
          //  player.transform.position = trigger.transform.position;
         //   player.transform.localPosition = new Vector3(0f, 0f, 0f);

            canSteer = true;

            // player.transform.localPosition = trigger.transform.position;
            //  player.controller.velocity.Set(rb.velocity.x, rb.velocity.y, rb.velocity.z);
            // player.controller.transform.position = transform.position + new Vector3(2f, 3f, 0f);




            player.moveSpeed = speed * movementFactor;
           


            // player.transform.position = trigger.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canSteer = false;
            player.moveSpeed = player.t_moveSpeed;
           
            player.transform.parent = null;
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
           // player.moveSpeed = 0f;
           // player.controller.velocity.Set(rb.velocity.x, rb.velocity.y, rb.velocity.z);
           // player.controller.transform.position = transform.position + new Vector3(2f, 3f, 0f);
           //  player.transform.parent = trigger.transform;
           // player.transform.position = trigger.transform.position;
            //player.transform.localPosition = new Vector3(0f, 0f, 0f);
            canSteer = true;
        }
    }
}
