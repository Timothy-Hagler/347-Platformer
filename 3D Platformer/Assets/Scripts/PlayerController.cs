using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    //public Rigidbody rb;
    public float jumpForce;
    public CharacterController controller;
    

    public Vector3 moveDirection;
    public float gravityScale;
    public float gravity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;

    public Transform ceilingCheck;
    public float ceilingDistance = 0.4f;
    //public LayerMask groundMask;
    bool isOnCeiling;

    public float knockbackForce;
    public float knockbackTime;
    private float knockbackCounter;
    public int jumpCount;

    public SuperSpeed speed;
    public DoubleJump doubleJump;
    public WallClimb wallClimb;
    public BallRoll ballRoll;

    public Vector3 velocity;

    public AudioManager sounds;
    

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
        sounds = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {

        /*isOnCeiling = Physics.CheckSphere(ceilingCheck.position, ceilingDistance);
        if (isOnCeiling)
        {
            gravity = -100f;
        }*/

        if (knockbackCounter <= 0)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
                jumpCount = 0;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            moveDirection = (transform.forward * z) + (transform.right * x);
            

            controller.Move(moveDirection * moveSpeed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && (isGrounded || (jumpCount < 2 && doubleJump.doubleJumpActive)))
            {
                velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
                jumpCount++;
                int i = Random.Range(0, 2);
                if (i == 0 && jumpCount <= 1)
                    sounds.Play("Jumpa");
                else if (i == 1 && jumpCount <= 1)
                    sounds.Play("Jumpb");
                 if (jumpCount == 2)
                    sounds.Play("Jumpc");
            }

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
     
        }
        else
        {
            knockbackCounter -= Time.deltaTime;
        }
        moveDirection.y = moveDirection.y + (gravity * Time.deltaTime);

        controller.Move(moveDirection * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.G))
            SetAbility("speed");
        if (Input.GetKeyDown(KeyCode.H))
            SetAbility("double jump");
        if (Input.GetKeyDown(KeyCode.J))
            SetAbility("wall climb");
        if (Input.GetKeyDown(KeyCode.K))
            SetAbility("ball roll");

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
          //  ballRoll.resetMesh();
            ballRoll.ballRollActive = false;
        }
        if (ability == "double jump" && doubleJump.doubleJumpAvailabe)
        {
            doubleJump.doubleJumpActive = true;
            doubleJump.doubleJump();
            speed.speedActive = false;
           // ballRoll.resetMesh();
            ballRoll.ballRollActive = false;
        }
        if (ability == "wall climb")
        {
            wallClimb.SetWallClimbActive(true);
            speed.speedActive = false;
            doubleJump.doubleJumpActive = false;
           // ballRoll.resetMesh();
            ballRoll.ballRollActive = false;
        }
        if (ability == "ball roll")
        {
            ballRoll.ballRollActive = true;
           // ballRoll.changeMesh();
        }
        
    }
}
