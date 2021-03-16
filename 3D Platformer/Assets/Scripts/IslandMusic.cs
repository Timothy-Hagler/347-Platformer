using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandMusic : MonoBehaviour
{
    public string sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            FindObjectOfType<AudioManager>().Play(sound);
    }

    private void OnTriggerExit(Collider other)
    {
        FindObjectOfType<AudioManager>().Stop(sound);
    }
}
