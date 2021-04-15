using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePush : MonoBehaviour
{
    public float pushAmount;
    public float pushRadius;
    private PlayerController player;


    private void Start()
    {
        player = GetComponent<PlayerController>();
    }

    private void DoPush()
    {
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, pushRadius);

        foreach(Collider pushObject in colliders)
        {
            if(pushObject.CompareTag("Snowball"))
            {
                
                Rigidbody pushedBody = pushObject.GetComponent<Rigidbody>();
                Debug.Log(pushedBody);
               // pushedBody.AddExplosionForce(pushAmount, Vector3.forward, pushRadius);
                pushedBody.AddForceAtPosition(player.transform.forward, player.transform.position, ForceMode.Impulse);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Snowball"))
        {
            DoPush();
        }
    }
}
