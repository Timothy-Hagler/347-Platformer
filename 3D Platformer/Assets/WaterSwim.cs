using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSwim : MonoBehaviour
{
    public PlayerController player;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player.isSwimming = true;
            player.moveSpeed = 2f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.isSwimming = false;
            player.moveSpeed = player.t_moveSpeed;
        }
    }
}
