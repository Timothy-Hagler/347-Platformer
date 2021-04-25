using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoInVolcano : MonoBehaviour
{
    public int requiredStars;
    public GameObject trigger;
    public GameObject lava;

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.allAbilities && GameManager.totalStars >= requiredStars)
        {
            if (trigger != null)
            {
                trigger.SetActive(true);
            }
            if (lava != null)
            {
                lava.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene("FinalTest");
        }
    }
}
