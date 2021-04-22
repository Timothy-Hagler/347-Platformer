using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollCredits : MonoBehaviour
{
    public GameObject canvas;
    public AudioManager music;

    private void Start()
    {
        music = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canvas.SetActive(true);
           // music.Stop("Credits1");
           // music.Play("credits");
        }
    }
}
