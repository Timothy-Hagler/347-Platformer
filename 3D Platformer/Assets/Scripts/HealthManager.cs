using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public float invincibilityLength;
    private float invincibilityCounter;

    public Renderer playerRenderer;
    private float flashCounter;
    public float flashLength = 0.1f;

    private bool isRespawning;
    private Vector3 respawnPoint;

    public float respawnLength;

    public PlayerController player;

    public GameManager gm;
    void Start()
    {
        currentHealth = maxHealth;

      //  player = FindObjectOfType<PlayerController>();

        respawnPoint = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                playerRenderer.enabled = !playerRenderer.enabled;
                flashCounter = flashLength;
            }

            if (invincibilityCounter <= 0)
            {
                playerRenderer.enabled = true;
            }
        }
    }

    public void HurtPlayer(int damage, Vector3 direction)
    {
        gm.changeHealth();
        if (invincibilityCounter <= 0)
        {
            currentHealth -= damage;
            gm.changeHealth();
            if (currentHealth <= 0)
            {
                Respawn();
                
            }
            else
            {
                player.KnockBack(direction * 2);

                invincibilityCounter = invincibilityLength;

                playerRenderer.enabled = false;

                flashCounter = flashLength;
            }
        }
    }

    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;
        gm.changeHealth();

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    public void Respawn()
    {
        player.transform.position = respawnPoint;
        

        //currentHealth = maxHealth;
        if (!isRespawning)
        {
            StartCoroutine("RespawnCo");
            
        }
    }

    public IEnumerator RespawnCo()
    {
        isRespawning = true;
        
        player.gameObject.SetActive(false);

        yield return new WaitForSeconds(respawnLength);
        isRespawning = false;

        player.gameObject.SetActive(true);
        player.transform.position = respawnPoint;
        currentHealth = maxHealth;

        invincibilityCounter = invincibilityLength;
        playerRenderer.enabled = false;
        flashCounter = flashLength;
        gm.changeHealth();
    }

    public void SetSpawnPoint(Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }
}
