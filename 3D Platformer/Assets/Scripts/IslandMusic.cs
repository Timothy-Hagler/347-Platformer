using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandMusic : MonoBehaviour
{
    public string sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play(sound);
            FindObjectOfType<AudioManager>().Stop("Lake");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        FindObjectOfType<AudioManager>().Stop(sound);
        FindObjectOfType<AudioManager>().Play("Lake");
    }
}
