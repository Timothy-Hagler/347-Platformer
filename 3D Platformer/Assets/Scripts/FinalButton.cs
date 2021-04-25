using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalButton : MonoBehaviour
{

    public GameObject path;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            path.SetActive(true);
            
        }

    }
}
