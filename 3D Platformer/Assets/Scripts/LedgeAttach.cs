using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeAttach : MonoBehaviour
{
    public GameObject ledge;
    public GameObject player;
    public BoatController boat;


    private void Start()
    {
        boat = GetComponentInParent<BoatController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           // player.transform.parent = transform;
            
           // boat.canSteer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           // player.transform.parent = null;
          //  boat.canSteer = false;
        }
    }
}
