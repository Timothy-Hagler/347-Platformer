using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{

    public bool doubleJumpAvailabe;
    public bool doubleJumpActive;

    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //  if (doubleJumpAvailabe)
        //    doubleJump();
    }

    public void SetDoubleJumpAvailable(bool value)
    {
        doubleJumpAvailabe = value;
    }

    public void doubleJump()
    {
        if (doubleJumpActive)
        {
            player.jumpForce = 35;
        }
        else
            player.jumpForce = 25;
    }
}
