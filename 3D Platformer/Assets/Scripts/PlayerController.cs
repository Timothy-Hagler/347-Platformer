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
    public int jumpCount;

    public SuperSpeed speed;
    public DoubleJump doubleJump;
    public WallClimb wallClimb;
    public BallRoll ballRoll;

    // Start is called before the first frame update
    void Start()
    {
        // rb = GetComponent<Rigidbody>();
        // Find controller and ability scripts on player
        controller = GetComponent<CharacterController>();
        speed = FindObjectOfType<SuperSpeed>();
        doubleJump = FindObjectOfType<DoubleJump>();
        wallClimb = FindObjectOfType<WallClimb>();
        ballRoll = FindObjectOfType<BallRoll>();
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

            if (controller.isGrounded)// || jumpCount < 2)
            {
                moveDirection.y = 0f;
                if (Input.GetButtonDown("Jump"))// && jumpCount < 2)
                {
                    moveDirection.y = jumpForce;
                    jumpCount++;
                }
            }

           /* if (controller.isGrounded && jumpCount >= 2)
            {
                jumpCount = 0;
            }*/
        }
        else
        {
            knockbackCounter -= Time.deltaTime;
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);// * Time.deltaTime);// ;

        controller.Move(moveDirection * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.G))
            SetAbility("speed");
        if (Input.GetKeyDown(KeyCode.H))
            SetAbility("double jump");

    }

    
    public void KnockBack(Vector3 direction)
    {
        knockbackCounter = knockbackTime;

        

        moveDirection = direction * knockbackForce;
        moveDirection.y = knockbackForce;
    }

    // Adds the ability to the player when a star gate is completed
    public void AddAbility(string ability)
    {
        if (ability == "speed")
        {
            speed.SetSpeedAvailable(true);
            speed.speedActive = true;
            doubleJump.doubleJumpActive = false;
        }
        if (ability == "double jump")
        {
            doubleJump.SetDoubleJumpAvailable(true);
            doubleJump.doubleJumpActive = true;
            doubleJump.doubleJump();
            speed.speedActive = false;
        }
        if (ability == "wall climb")
            wallClimb.SetWallClimbAvailable(true);
        if (ability == "ball roll")
            ballRoll.SetBallRollAvailable(true);

    }

    public void SetAbility(string ability)
    {
        if (ability == "speed" && speed.speedAvailable)
        {
            speed.speedActive = true;
            doubleJump.doubleJumpActive = false;
            doubleJump.doubleJump();
        }
        if (ability == "double jump" && doubleJump.doubleJumpAvailabe)
        {
            doubleJump.doubleJumpActive = true;
            doubleJump.doubleJump();
            speed.speedActive = false;
        }
        if (ability == "wall climb")
            wallClimb.SetWallClimbAvailable(true);
        if (ability == "ball roll")
            ballRoll.SetBallRollAvailable(true);
    }
}
