using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RevealWorld : MonoBehaviour
{

    public GameObject[] worlds;
    public GameManager gm;
    public int requiredStars;


    private void OnTriggerEnter(Collider other)
    {
        /*if (other.tag == "Player")
        {
            if (gm.currentStars >= requiredStars)
            {
                foreach (GameObject w in worlds)
                    w.SetActive(true);
                // Destroy(gameObject);
                //  gm.removeStar(requiredStars);
            }
        }*/
    }

    public void Reveal()
    {
        foreach (GameObject w in worlds)
            w.SetActive(true);
    }
}
