using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    //public Rigidbody rb;
    public float jumpForce;
    public CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale;

    public float knockbackForce;
    public float knockbackTime;
    private float knockbackCounter;

    // Start is called before the first frame update
    void Start()
    {
        // rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (knockbackCounter <= 0)
        {
            float yStore = moveDirection.y;
            moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
            moveDirection = moveDirection.normalized * moveSpeed;
            moveDirection.y = yStore;

            if (controller.isGrounded)
            {
                moveDirection.y = 0f;
                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jumpForce;
                }
            }
        }
        else
        {
            knockbackCounter -= Time.deltaTime;
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);// * Time.deltaTime);// ;

        controller.Move(moveDirection * Time.deltaTime);
    }

    public void KnockBack(Vector3 direction)
    {
        knockbackCounter = knockbackTime;

        

        moveDirection = direction * knockbackForce;
        moveDirection.y = knockbackForce;
    }
}
