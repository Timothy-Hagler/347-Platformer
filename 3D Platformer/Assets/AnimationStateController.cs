using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{

     Animator animator;
     int isWalkingHash;
     int isWalkingLeftHash;
     int isWalkingRightHash;
     int isWalkingBackwardsHash;
     int isRunningHash;
     int isJumpingHash;
     int isGlidingHash;
     public PlayerController player;
     // Start is called before the first frame update
     void Start()
     {
         animator = GetComponent<Animator>();
         isWalkingHash = Animator.StringToHash("isWalking");
         isRunningHash = Animator.StringToHash("isRunning");
         isJumpingHash = Animator.StringToHash("isJumping");
         isWalkingLeftHash = Animator.StringToHash("isWalkingLeft");
         isWalkingRightHash = Animator.StringToHash("isWalkingRight");
         isWalkingBackwardsHash = Animator.StringToHash("isWalkingBackwards");
         isGlidingHash = Animator.StringToHash("isGliding");
    }

     // Update is called once per frame
     void Update()
     {
         bool isWalking = animator.GetBool(isWalkingHash);
         bool isRunning = animator.GetBool(isRunningHash);
         bool isJumping = animator.GetBool(isJumpingHash);
         bool isGliding = animator.GetBool(isGlidingHash);
         bool isWalkingLeft = animator.GetBool(isWalkingLeftHash);
         bool isWalkingRight = animator.GetBool(isWalkingRightHash);
         bool isWalkingBackwards = animator.GetBool(isWalkingBackwardsHash);
         bool forwardPressed = Input.GetKey("w");
         bool leftPressed = Input.GetKey("a");
         bool rightPressed = Input.GetKey("d");
         bool backPressed = Input.GetKey("s");
         bool jumpPressed = Input.GetKey("space");
         if (forwardPressed && !isWalking)
         {
             animator.SetBool(isWalkingHash, true);

         }
         if(!forwardPressed && isWalking)
         {
             animator.SetBool(isWalkingHash, false);
         }

         //Left strafe
         if (leftPressed && !isWalkingLeft)
         {
            animator.SetBool(isWalkingLeftHash, true);
         }

        if (!leftPressed && isWalkingLeft)
        {
            animator.SetBool(isWalkingLeftHash, false);
        }

        //Right Strafe
        if (rightPressed && !isWalkingRight)
        {
            animator.SetBool(isWalkingRightHash, true);
        }

        if (!rightPressed && isWalkingRight)
        {
            animator.SetBool(isWalkingRightHash, false);
        }
        //Walk backwards
        if (backPressed && !isWalkingBackwards)
        {
            animator.SetBool(isWalkingBackwardsHash, true);
        }

        if (!backPressed && isWalkingBackwards)
        {
            animator.SetBool(isWalkingBackwardsHash, false);
        }
        if (!isRunning && (player.speed.speedActive && forwardPressed))
         {
             animator.SetBool(isRunningHash, true);
         }
         if (isRunning && (!player.speed.speedActive || !forwardPressed))
         {
             animator.SetBool(isRunningHash, false);
         }

         if(jumpPressed && !isJumping && player.isGrounded)
         {
             animator.SetBool(isJumpingHash, true);
         }

         if ((player.isGrounded && isJumping))
         {
             animator.SetBool(isJumpingHash, false);
         }

        if ((player.isGliding))
        {
            animator.SetBool(isGlidingHash, true);
        }
        if ((!player.isGliding))
        {
            animator.SetBool(isGlidingHash, false);
        }
    }

    /*Animator animator;
    float velocity = 0.0f;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        bool forwardPressed = Input.GetKey("w");
        bool jumpPressed = Input.GetKey("space");

        
    }*/
}
