using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimb : MonoBehaviour
{

    public bool wallClimbAvailabe;
    public bool wallClimbActive;
    public PlayerController player;
    private bool canStartTimer;
    private bool canWallClimb;
    public float timer;
    private float t_timer;
    // Start is called before the first frame update
    void Start()
    {
        canWallClimb = true;
        t_timer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (canStartTimer)
            timer -= Time.deltaTime * 2.5f;
        if (timer <= 0)
            canWallClimb = false;
    }

    public void SetWallClimbAvailable(bool value)
    {
        wallClimbAvailabe = value;
    }

    public void SetWallClimbActive(bool value)
    {
        wallClimbActive = value;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        if (wallClimbActive)
        {
            if (!player.isGrounded && hit.normal.y < 0.1f && canWallClimb)
            {
                // if (Input.GetKeyDown(KeyCode.A))
                {
                    canStartTimer = true;
                    Debug.DrawRay(hit.point, hit.normal, Color.red, 1.25f);
                    player.velocity.y = player.jumpForce;
                    //  player.controller.Move(hit.normal * player.moveSpeed);
                    player.moveDirection = -hit.normal * player.moveSpeed;
                }
            }
            else if (!player.isGrounded)
            {
                player.moveDirection.y = (hit.normal.y * player.moveSpeed) * 3f;
            }
            else if (player.isGrounded)
            {
                canWallClimb = true;
                canStartTimer = false;
                timer = t_timer;
            }
        }
    }
}
