using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{

    private HealthManager healthMan;
    // Start is called before the first frame update
    void Start()
    {
        healthMan = FindObjectOfType<HealthManager>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            if (healthMan.currentHealth < healthMan.maxHealth)
            {
                Debug.Log("Less than");
                healthMan.HealPlayer(1);
                Destroy(gameObject);
            }
            }
    }
}
