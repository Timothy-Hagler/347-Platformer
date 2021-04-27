using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{

    private HealthManager healthMan;
    public Renderer rend;

    public Material needHealth;
    public Material noNeedHealth;
    public AudioManager pickUpSound;
   

    // Start is called before the first frame update
    void Start()
    {
        healthMan = FindObjectOfType<HealthManager>();
        pickUpSound = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if (healthMan.currentHealth == healthMan.maxHealth)
        {
            HeartOff();
        }
        else if (healthMan.currentHealth < healthMan.maxHealth)
        {
            HeartOn();
        }

        transform.Rotate(0, 0, 30 * Time.deltaTime);
    }

    public void HeartOn()
    {
        Heart[] hearts = FindObjectsOfType<Heart>();
        foreach (Heart h in hearts)
        {
            h.rend.material = needHealth;
        }
    }

    public void HeartOff()
    {
        Heart[] hearts = FindObjectsOfType<Heart>();
        foreach (Heart h in hearts)
        {
            h.rend.material = noNeedHealth;
        }
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
                pickUpSound.Play("Heal");
            }
            }
    }
}
