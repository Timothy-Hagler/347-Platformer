using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableDialogue : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        gameObject.SetActive(false);
    }
}
