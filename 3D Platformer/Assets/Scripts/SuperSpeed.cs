using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSpeed : MonoBehaviour
{

    public PlayerController controller;
    private bool speedOn = false;
    public bool speedAvailable;
    public bool speedActive;
    public int speedMultiple;
    // Start is called before the first frame update
    void Start()
    {

       // controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (speedAvailable)
        {
            if (Input.GetKeyDown(KeyCode.L) && speedActive)
            {
                if (speedOn == false)
                {
                    controller.moveSpeed = controller.moveSpeed * speedMultiple;
                    speedOn = true;
                }
                else
                {
                    controller.moveSpeed = controller.moveSpeed / speedMultiple;
                    speedOn = false;
                }

            }
        }
    }

    public void SetSpeedAvailable(bool value)
    {
        speedAvailable = value;
    }
}
