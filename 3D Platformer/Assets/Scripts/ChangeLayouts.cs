using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayouts : MonoBehaviour
{
    public GameObject layoutOne;
    public GameObject layoutTwo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            layoutOne.SetActive(false);
            layoutTwo.SetActive(true);
        }
    }
}
