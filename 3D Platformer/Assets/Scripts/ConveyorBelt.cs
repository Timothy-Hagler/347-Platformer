using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public PlayerController player;
    private float speed;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       // GameObject tempPlayer = collision.gameObject;

        if (other.tag == "Player")
        {
            speed = player.moveSpeed;
            player.moveSpeed = player.moveSpeed - 25;
        }
    }

    private void OnTriggerExit(Collider other)
    {
      //  GameObject tempPlayer = collision.gameObject;

        if (other.tag == "Player")
        {
            player.moveSpeed = speed;
           
        }
    }
}
