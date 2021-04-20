using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoInVolcano : MonoBehaviour
{
    public int requiredStars;

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.allAbilities && GameManager.totalStars >= requiredStars)
        {
            gameObject.SetActive(true);
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
